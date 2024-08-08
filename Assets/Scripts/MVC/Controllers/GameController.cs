using System;
using System.Collections;
using System.Collections.Generic;
using CM.Controllers;
using CM.Enums;
using CM.Factories;
using CM.Managers;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;

namespace CM.MVC.Controllers
{
    /// <summary>
    /// Manages the game's state, including handling card interactions and managing the game model and view.
    /// </summary>
    /// <typeparam name="M">The type of the game model.</typeparam>
    /// <typeparam name="V">The type of the game view.</typeparam>
    public class GameController<M, V> : IDisposable, IController<M, V> 
    where M : GameModel where V : GameView, new()
    {
        private GameModel gameModel;
        private GameView gameView;

        private List<CardController<CardModel, CardView>> cardControllers = new List<CardController<CardModel, CardView>>();
        
        /// <summary>
        /// Gets the model associated with this controller.
        /// </summary>
        public IModel Model
        {
            get { return gameModel; }
            private set { gameModel = value as GameModel; }
        }

        /// <summary>
        /// Gets the view associated with this controller.
        /// </summary>
        public IView View
        {
            get { return gameView; }
            private set { gameView = value as GameView; }
        }
        
        private List<CardController<CardModel, CardView>> cardFlipped = new List<CardController<CardModel, CardView>>();

        /// <summary>
        /// Sets up the game controller, initializes the game model and view, and populates the game with cards.
        /// </summary>
        public void Setup()
        {
            gameModel = new GameModel();
            gameModel.InitializeData();
            gameView = new GameView();

            Transform parentTransform = GameObject.FindObjectOfType<Canvas>().transform;
            gameView.InitializeView("GameView", parentTransform);
            gameView.CreateGridLayout();
           
            CardFactory cardFactory = new CardFactory();
            foreach (var card in gameModel.cards) 
            {             
                CardController<CardModel, CardView> cardController = cardFactory.Create() as CardController<CardModel, CardView>;
                ((CardModel)cardController.Model).InitializeData(card);
                cardControllers.Add(cardController);
            }

            GameManager.Instance.EventManager.OnCardClicked += OnCardClicked;
            GameManager.Instance.EventManager.OnCardMatchingEnd += CheckGameEnded;
            gameView.PopulateCards(cardControllers);
        }

        /// <summary>
        /// Handles card click events and starts the matching process.
        /// </summary>
        /// <param name="controller">The card controller associated with the clicked card.</param>
        public void OnCardClicked(IController<CardModel, CardView> controller)
        {
            CardController<CardModel, CardView> cardController = (CardController<CardModel, CardView>)controller;
            GameManager.Instance.EventManager.CardMatchingStart();    
            GameManager.Instance.StartCoroutine(Match(cardController));
        }

        /// <summary>
        /// Processes the matching logic for flipped cards.
        /// </summary>
        /// <param name="cardController">The card controller of the currently flipped card.</param>
        /// <returns>An enumerator for coroutine processing.</returns>
        public IEnumerator Match(CardController<CardModel, CardView> cardController)
        {
            if (cardFlipped.Count < 2)
            {
                CardModel cardModel = cardController.Model as CardModel;
                if (cardModel != null) 
                {
                    if (cardModel.cardState == CardState.Back)
                    {
                        cardController.ChangeCardState(CardState.Front);
                        cardFlipped.Add(cardController);
                    }
                }

                yield return new WaitForSeconds(1);
                if (cardFlipped.Count == 2)
                {
                    if (cardFlipped[0].Model.Id == cardFlipped[1].Model.Id)
                    {
                        int score = ++GameManager.Instance.ScoreModel.Match;
                        GameManager.Instance.EventManager.MatchUpdate(score);
                        cardFlipped[0].ChangeCardState(CardState.Matched);
                        cardFlipped[1].ChangeCardState(CardState.Matched);
                        cardFlipped.Clear();
                        SoundManager.Instance.PlaySound(SoundManager.Instance.matchSound);
                    }
                    else
                    {
                        GameManager.Instance.ScoreModel.Turns++;
                        GameManager.Instance.EventManager.TurnUpdate();
                        cardFlipped[0].ChangeCardState(CardState.Back);
                        cardFlipped[1].ChangeCardState(CardState.Back);
                        cardFlipped.Clear();
                        SoundManager.Instance.PlaySound(SoundManager.Instance.mismatchSound);
                    }
                }
            }    
            GameManager.Instance.EventManager.CardMatchingEnd();
        }

        /// <summary>
        /// Cleans up the game controller by clearing card controllers and destroying game objects.
        /// </summary>
        public void Dispose()
        {
            foreach (CardController<CardModel, CardView> controller in cardControllers) 
            {
                controller.Dispose();
            }

            gameModel.cards.Clear();
            cardControllers.Clear();
            GameObject.Destroy(gameView.gameObject);
            gameView = null;
            gameModel = null;

            GameManager.Instance.EventManager.OnCardClicked -= OnCardClicked;
            GameManager.Instance.EventManager.OnCardMatchingEnd -= CheckGameEnded;
        }

        /// <summary>
        /// Checks if the game has ended based on the number of matches.
        /// </summary>
        /// <param name="match">The number of matches made so far.</param>
        private void CheckGameEnded()
        {
            if (GameManager.Instance.ScoreModel.Match == cardControllers.Count / 2)
            {
                GameManager.Instance.EventManager.GameEnded();
            }
        }
    }
}
