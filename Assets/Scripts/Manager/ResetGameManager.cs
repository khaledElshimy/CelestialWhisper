using CM.Enums;
using CM.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
    /// <summary>
    /// Manages the reset game interface, including restarting the game.
    /// </summary>
    public class ResetGameManager : MonoBehaviour
    {
        /// <summary>
        /// Button to restart the game.
        /// </summary>
        public Button playButton;

        /// <summary>
        /// Initializes the manager by setting up the button listener.
        /// </summary>
        void Start()
        {
            playButton.onClick.AddListener(RestartGame);
        }

        /// <summary>
        /// Restarts the game by changing the game state to gameplay.
        /// </summary>
        void RestartGame()
        {
            GameManager.Instance.EventManager.ChangeGameState(GameState.GamePlay);
        }
    }
}
