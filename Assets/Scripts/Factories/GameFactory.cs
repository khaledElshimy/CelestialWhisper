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
    public class GameFactory: IFactory<GameModel, GameView, GameController<GameModel, GameView>>
    {
        public IController<GameModel, GameView> Create(Transform container = null)
{
    GameController<GameModel, GameView> gameController = new GameController<GameModel, GameView>();
    
    if (gameController == null)
    {
        Debug.LogError("Failed to create GameController.");
        return null;
    }

    gameController.Setup();
    
    if (container != null)
    {
        gameController.View.gameObject.transform.SetParent(container);
        gameController.View.gameObject.transform.localPosition = Vector3.zero;
        gameController.View.gameObject.transform.localRotation = Quaternion.identity;
    }
    
    return gameController;
}

    }
}