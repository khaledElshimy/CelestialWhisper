using CM.Enums;
using CM.Factories;
using CM.Misc;
using CM.MVC.Controllers;
using CM.MVC.Models;
using CM.MVC.Views;
using CM.UI;
using UnityEngine;

namespace CM.Managers
{
    /// <summary>
    /// Manages the game state, settings, and interactions between different game components.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the GameManager.
        /// </summary>
        public static GameManager Instance;

        /// <summary>
        /// Event manager for handling game events.
        /// </summary>
        public EventManager EventManager { get; private set; }

        [SerializeField]
        private MainMenuManager mainMenuManager;

        [SerializeField]
        private HudManager hudManager;

        [SerializeField]
        private ResetGameManager resetGameManager;

        /// <summary>
        /// Game settings loaded from data.
        /// </summary>
        public GameSettings Settings { get; private set; }

        /// <summary>
        /// Model that holds the score information.
        /// </summary>
        public ScoreModel ScoreModel { get; set; }

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
            EventManager = new EventManager(); 
            ChangeGameState(GameState.MainMenu);     
            EventManager.OnGameStateChanged += ChangeGameState;
            EventManager.OnGameEnded += EndGame;
        }

        /// <summary>
        /// Starts a new game by initializing the score model and creating a game controller.
        /// </summary>
        public void StartGame()
        {
            ScoreModel = new ScoreModel();
            GameFactory gameFactory = new GameFactory();
            gameController = gameFactory.Create() as GameController<GameModel, GameView>;
        }

        /// <summary>
        /// Changes the game state and updates the active game components accordingly.
        /// </summary>
        /// <param name="state">The new game state to switch to.</param>
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

        /// <summary>
        /// Ends the current game, clears the game state, and switches to the reset state.
        /// </summary>
        private void EndGame()
        {
            ClearGame();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameEndSound);
            ChangeGameState(GameState.Reset);
        }

        /// <summary>
        /// Clears the current game by destroying the game controller and switching to the reset state.
        /// </summary>
        private void ClearGame()
        {
            gameController.Dispose();
            gameController = null;
            ChangeGameState(GameState.Reset);
        }

        private void OnDestroy()
        {
            EventManager.OnGameEnded -= EndGame;
            EventManager.OnGameStateChanged -= ChangeGameState;
        }
    }
}
