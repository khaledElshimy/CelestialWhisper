using System.Collections;
using System.Collections.Generic;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;

namespace CM.MVC.Controllers
{
    public class GameController<M, V> : IController<IModel, IView> 
    where M : GameModel where V : GameView, new()
    {
        GameModel gameModel;
        GameView gameView;
        public IModel Model {get{return gameModel;} private set{Model = gameModel;} }
        public IView View {get{return gameView;} private set{View = gameView;} }


        public void Setup()
        {
            GameModel gameModel = Model as GameModel;
            GameView gameView = View as GameView;
        }

    }
}

