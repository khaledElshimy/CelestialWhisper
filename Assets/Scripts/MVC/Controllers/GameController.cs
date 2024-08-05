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
            gameView.InitializeView("GameView");
            CardFactory cardFactory = new CardFactory();
            foreach(var card in gameModel.cards) 
            {         
                Debug.Log($"Card {card.Name}");     
                CardController<CardModel,CardView> cardController= cardFactory.Create(gameView.gameObject.transform) as CardController<CardModel,CardView>;
                cardController.updateCard(card);
            }
        }
    }
}

