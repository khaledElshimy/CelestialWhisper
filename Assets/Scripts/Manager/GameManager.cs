using System.Collections.Generic;
using System.Diagnostics;
using CM.Enums;
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

    public EventManager EventManager{ get; private set; }

    [SerializeField]
    private MainMenuManager mainMenuManager;
   
    [SerializeField]
    private HudManager hudManager;

    public GameSettings Settings {get; private set;}
    GameSettings gameSettings;
    private GameController<GameModel, GameView> gameController;
    private GameState gameState = GameState.None;
    
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
        EventManager =  new EventManager(); 
        Settings = GameDataManager.Instance.LoadGameSettings();
        ChangeGameState(GameState.MainMenu);     
        EventManager.OnChangeGameState += ChangeGameState;
    }

    public void StartGame()
    {
        GameFactory gameFactory= new GameFactory();
        gameController = gameFactory.Create() as GameController<GameModel, GameView>;
    }

    private void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                gameState = state;
                mainMenuManager.gameObject.SetActive(true);
                hudManager.gameObject.SetActive(false);
            break;

            case GameState.GamePlay:
                gameState = state;
                hudManager.gameObject.SetActive(true);
                mainMenuManager.gameObject.SetActive(false);
                StartGame();
            break;
            case GameState.Reset:
                hudManager.gameObject.SetActive(true);
            break;
        }
    }

    private void OnDestroy()
    {
        EventManager.OnChangeGameState -= ChangeGameState;
    }
}
