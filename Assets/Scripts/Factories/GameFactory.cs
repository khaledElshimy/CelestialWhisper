using CM.MVC.Interfaces;
using CM.Factories.Interfaces;
using UnityEngine;
using CM.MVC.Views;
using CM.MVC.Models;
using CM.MVC.Controllers;

namespace CM.Factories
{
    /// <summary>
    /// A factory class for creating instances of <see cref="GameController{GameModel, GameView}"/>.
    /// </summary>
    public class GameFactory : IFactory<GameModel, GameView, GameController<GameModel, GameView>>
    {
        /// <summary>
        /// Creates and returns a new instance of <see cref="GameController{GameModel, GameView}"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IController{GameModel, GameView}"/> or null if creation fails.</returns>
        public IController<GameModel, GameView> Create()
        {
            // Create a new instance of the GameController
            GameController<GameModel, GameView> gameController = new GameController<GameModel, GameView>();

            // Check if the controller was created successfully
            if (gameController == null)
            {
                Debug.LogError("Failed to create GameController.");
                return null;
            }

            // Set up the controller
            gameController.Setup();

            return gameController;
        }
    }
}
