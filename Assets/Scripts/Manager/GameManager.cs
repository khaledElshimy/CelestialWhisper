using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CM.Enums;
using CM.Factories;
using CM.Misc;
using CM.MVC.Controllers;
using CM.MVC.Models;
using CM.MVC.Views;
using CM.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace CM.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public EventManager EventManager{ get; private set; }

        [SerializeField]
        private MainMenuManager mainMenuManager;
    
        [SerializeField]
        private HudManager hudManager;

        [SerializeField]
        private ResetGameManager resetGameManager;

        public GameSettings Settings {get; private set;}
        public ScoreModel ScoreModel {get; set;}

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
            Settings = GameDataManager.Instance.LoadGameSettings();            
        }

        private void Start()
        {  
            EventManager =  new EventManager(); 
            ChangeGameState(GameState.MainMenu);     
            EventManager.OnGameStateChanged += ChangeGameState;
            EventManager.OnGameEndded += EndGame;
        }

        public void StartGame()
        {
            ScoreModel = new ScoreModel();
            GameFactory gameFactory= new GameFactory();
            gameController = gameFactory.Create() as GameController<GameModel, GameView>;
        }

        private void ChangeGameState(GameState state)
        {
            gameState = state;
            switch (state)
            {
                case GameState.MainMenu:
                if (gameController != null)
                    {
                        ClearGame();
                    }
                    mainMenuManager.gameObject.SetActive(true);
                    hudManager.gameObject.SetActive(false);
                    resetGameManager.gameObject.SetActive(false);
                break;

                case GameState.GamePlay:
                    hudManager.gameObject.SetActive(true);
                    mainMenuManager.gameObject.SetActive(false);
                    resetGameManager.gameObject.SetActive(false);
                    StartGame();
                break;
                case GameState.Reset:
                    GameDataManager.Instance.SaveGameSettings(Settings);
                    hudManager.gameObject.SetActive(false);
                    mainMenuManager.gameObject.SetActive(false);
                    resetGameManager.gameObject.SetActive(true);
                break;
            }
        }    

        private void EndGame()
        {
            ClearGame();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameEndSound);
            ChangeGameState(GameState.Reset);
        }

        private void ClearGame()
        {
            gameController.Destroy();
            gameController = null;
            ChangeGameState(GameState.Reset);
        }

        private void OnDestroy()
        {
            EventManager.OnGameStateChanged -= ChangeGameState;
        }
    }
}
