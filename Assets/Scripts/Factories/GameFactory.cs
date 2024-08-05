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
        public IController<GameModel, GameView> Create()
{
    GameController<GameModel, GameView> gameController = new GameController<GameModel, GameView>();
    
    if (gameController == null)
    {
        Debug.LogError("Failed to create GameController.");
        return null;
    }

    gameController.Setup();
    
    return gameController;
}

    }
}