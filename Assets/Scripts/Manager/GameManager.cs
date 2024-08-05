using System.Collections.Generic;
using CM.Factories;
using CM.MVC.Controllers;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameController<GameModel, GameView> gameController;

    private void Start()
    {   
        GameFactory gameFactory= new GameFactory();
        gameController = gameFactory.Create() as GameController<GameModel, GameView>;
    }
}
