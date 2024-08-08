using CM.Enums;
using CM.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
    /// <summary>
    /// Manages the main menu interface, including difficulty selection and game start.
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        /// <summary>
        /// Button to start the game.
        /// </summary>
        public Button playButton;

        private GameDifficulty gameDifficulty = GameDifficulty.None;

        [SerializeField]
        private ToggleGroup difficultyToggleGroup;

        /// <summary>
        /// Initializes the menu by setting up button listeners and updating the difficulty selection.
        /// </summary>
        void Start()
        {
            // Add a listener to the play button to start the game when clicked
            playButton.onClick.AddListener(StartGame);

            // Load and set the current game difficulty
            gameDifficulty = GameManager.Instance.Settings.GetGameDifficulty();
            UpdateToggleGroup();
        }

        /// <summary>
        /// Changes the game state to gameplay when the play button is clicked.
        /// </summary>
        void StartGame()
        {
            GameManager.Instance.EventManager.ChangeGameState(GameState.GamePlay);
        }

        /// <summary>
        /// Updates the game difficulty setting based on user selection.
        /// </summary>
        /// <param name="gameDifficulty">The difficulty level selected by the user.</param>
        public void SelectGameDifficulty(int gameDifficulty)
        {
            GameDifficulty difficulty = (GameDifficulty)gameDifficulty;
            if (this.gameDifficulty != difficulty) 
            {
                this.gameDifficulty = difficulty;
                GameManager.Instance.Settings.UpdateGameDifficulty(gameDifficulty);
            }
        }

        /// <summary>
        /// Updates the toggle group to reflect the current game difficulty level.
        /// </summary>
        private void UpdateToggleGroup()
        {
            int difficulty = (int)gameDifficulty;
            if (difficultyToggleGroup == null)
                return;

            var toggles = difficultyToggleGroup.GetComponentsInChildren<Toggle>();
            if (toggles.Length < difficulty)
                return;

            int index = difficulty - 1;
            if (index >= 0 && index < toggles.Length)
            {
                toggles[index].isOn = true;
            }
        }
    }
}
