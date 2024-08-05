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
    [SerializeField]
    private Transform GameViewParent;

    private void Start()
    {   
        GameFactory gameFactory= new GameFactory();
        gameController = gameFactory.Create(GameViewParent) as GameController<GameModel, GameView>;
    }
}
