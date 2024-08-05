using CM.MVC.Interfaces;
using CM.Factories.Interfaces;
using UnityEngine;
using CM.MVC.Views;
using CM.MVC.Models;
using CM.Controllers;
using CM.MVC.Controllers;
using Unity.Mathematics;

namespace CM.Factories
{
    public class GameFactory<M, V, C> : IFactory<GameModel, GameView, GameController<GameModel, GameView>>
    {
        public IController<GameModel, GameView> Create(Transform container = null)
        {
            GameController<GameModel, GameView> gameController = new GameController<GameModel, GameView>();
            gameController.Setup();
            GameModel gameModel = gameController.Model as GameModel;
            gameModel.InitializeData();

            GameView gameView = gameController.View as GameView;
            gameView.InitializeView("GameView");
            
            if (container != null)
            {
                gameView.gameObject.transform.SetParent(container);
            }
            gameView.gameObject.transform.localPosition = Vector3.zero;
            gameView.gameObject.transform.localRotation = Quaternion.identity;
            return gameController;
        }
    }
}