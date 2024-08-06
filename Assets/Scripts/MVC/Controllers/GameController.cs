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
    public class GameController<M, V> : IController<M, V> 
    where M : GameModel where V : GameView, new()
    {
        private GameModel gameModel;
        private GameView gameView;

        private List<CardController<CardModel, CardView>> cardControllers = new List<CardController<CardModel,CardView>>();
        
        public IModel Model
        {
            get { return gameModel; }
            private set { gameModel = value as GameModel; }
        }

        public IView View
        {
            get { return gameView; }
            private set { gameView = value as GameView; }
        }
        
        private List<CardController<CardModel, CardView> > cardFlipped = new List<CardController<CardModel, CardView> >();
        public void Setup()
        {
            gameModel = new GameModel();
            gameModel.InitializeData();
            gameView = new GameView();

            Transform parentTransform = Object.FindObjectOfType<Canvas>().transform;
            gameView.InitializeView("GameView", parentTransform);
            gameView.CreateGridLayout();
           
            CardFactory cardFactory = new CardFactory();
            foreach(var card in gameModel.cards) 
            {             
                CardController<CardModel,CardView> cardController= cardFactory.Create() as CardController<CardModel,CardView>;
                ((CardModel)cardController.Model).InitializeData(card);
                cardControllers.Add(cardController);
            }

            GameManager.Instance.EventManager.OnCardClicked += OnCardClicked;
            GameManager.Instance.EventManager.OnMatchUpdate += CheckGameEnded;
            gameView.PopulateCards(cardControllers);
        }

        public void OnCardClicked(IController<CardModel, CardView> controller)
        {
            CardController<CardModel, CardView> cardController = (CardController<CardModel, CardView>)controller;
            GameManager.Instance.StartCoroutine(Match(cardController));
        }
        public IEnumerator Match(CardController<CardModel, CardView> cardController)
        {
            if(cardFlipped.Count < 2)
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

                yield return new WaitForSeconds(2);
                if (cardFlipped.Count == 2)
                {
                    if(cardFlipped[0].Model.Id == cardFlipped[1].Model.Id)
                    {
                        int score = ++GameManager.Instance.ScoreModel.Match;
                        GameManager.Instance.EventManager.MatchUpdate(score);
                        cardFlipped[0].ChangeCardState(CardState.Matched);
                        cardFlipped[1].ChangeCardState(CardState.Matched);
                        cardFlipped.Clear();
                    }
                    else
                    {
                        GameManager.Instance.ScoreModel.Turns++;
                        GameManager.Instance.EventManager.TurnUpdate();
                        cardFlipped[0].ChangeCardState(CardState.Back);
                        cardFlipped[1].ChangeCardState(CardState.Back);
                        cardFlipped.Clear();
                    }
                }
            }
        }

        public void Destroy ()
        {
            cardControllers.Clear();
            gameModel.cards.Clear();
            foreach(Transform cardViewTransform in gameView.gameObject.transform) {
                GameObject.Destroy(cardViewTransform.gameObject);
            }
            GameObject.Destroy(gameView.gameObject);
            gameView = null;
            gameModel = null;
        }

        private void CheckGameEnded(int match)
        {
           if (match == cardControllers.Count / 2)
           {
                GameManager.Instance.EventManager.GameEndded();
           }
        }
    }
}

