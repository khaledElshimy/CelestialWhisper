using System.Collections.Generic;
using CM.Factories;
using CM.Misc;
using CM.MVC.Controllers;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    //private MainM _gameManager;
    
    public GameSettings Settings {get; private set;}
    GameSettings gameSettings;
    private GameController<GameModel, GameView> gameController;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {   
        Settings = GameDataManager.Instance.LoadGameSettings();
        
        GameFactory gameFactory= new GameFactory();
        gameController = gameFactory.Create() as GameController<GameModel, GameView>;
    }
}
