using System.Collections;
using System.Collections.Generic;
using CM.Controllers;
using CM.Enums;
using CM.Factories;
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

            Debug.Log($"Controllers  {cardControllers.Count} cards");
            GameManager.Instance.EventManager.OnCardClicked += OnCardClicked;
            gameView.PopulateCards(cardControllers);
        }

        public void OnCardClicked(IController<CardModel, CardView> controller)
        {
            CardController<CardModel, CardView> cardController = (CardController<CardModel, CardView>)controller;
            GameManager.Instance.StartCoroutine(Match(cardController));
        }
        public IEnumerator Match(CardController<CardModel, CardView> cardController)
        {
            Debug.Log("1");
            if(cardFlipped.Count < 2)
            {
                CardModel cardModel = cardController.Model as CardModel;
                 Debug.Log($"1 {cardModel.cardState}  {((CardModel)cardController.Model).cardState}");
                if (cardModel != null) 
                {
                                Debug.Log($"2 {cardModel.cardState}");

                    if (cardModel.cardState == CardState.Back)
                    {
                                    Debug.Log("3");

                        cardController.ChangeCardState(CardState.Front);
                                    Debug.Log("4");

                        cardFlipped.Add(cardController);
                    }
                }
                yield return new WaitForSeconds(3);
                if (cardFlipped.Count == 2)
                {
                     Debug.Log("5");

                    if(cardFlipped[0].Model.Id == cardFlipped[1].Model.Id)
                    {
                                    Debug.Log("6");

                        GameManager.Instance.EventManager.MatchUpdate();
                        cardFlipped[0].ChangeCardState(CardState.Matched);
                        cardFlipped[1].ChangeCardState(CardState.Matched);
                        cardFlipped.Clear();
                    }
                    else
                    {
                                    Debug.Log("7");

                        GameManager.Instance.EventManager.TurnUpdate();
                        cardFlipped[0].ChangeCardState(CardState.Back);
                        cardFlipped[1].ChangeCardState(CardState.Back);
                        cardFlipped.Clear();
                    }
                }
            }
        }
    }
}

