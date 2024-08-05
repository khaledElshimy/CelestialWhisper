using System.Collections;
using System.Collections.Generic;
using CM.Controllers;
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
        GameModel gameModel;
        GameView gameView;
        public IModel Model {get{return gameModel;} private set{} }
        public IView View {get{return gameView;} private set{} }

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
                Debug.Log($"Card {card.Name}");     
                CardController<CardModel,CardView> cardController= cardFactory.Create() as CardController<CardModel,CardView>;
                gameView.AddCardView(cardController.View, cardController.Model);
                cardController.updateCard(card);
            }
        }
    }
}

