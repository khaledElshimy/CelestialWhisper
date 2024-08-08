using CM.Enums;
using CM.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
    /// <summary>
    /// Manages the HUD (Heads-Up Display) elements of the game, including match and turn information.
    /// </summary>
    public class HudManager : MonoBehaviour
    {
        [SerializeField]
        private Button homeButton;

        [SerializeField]
        private Text matchValueText;
        
        [SerializeField]
        private Text turnsValueText;

        private void Start()
        {
            homeButton.onClick.AddListener(backToHome);
        }

        /// <summary>
        /// Navigates back to the main menu when the home button is clicked.
        /// </summary>
        private void backToHome()
        {
            GameManager.Instance.EventManager.ChangeGameState(GameState.MainMenu);
        }

        private void OnEnable()
        {
            // Subscribe to event updates for match and turn values
            GameManager.Instance.EventManager.OnMatchUpdate += UpdateMatchValue;
            GameManager.Instance.EventManager.OnTurnUpdate += UpdateTurnValue;
        }

        /// <summary>
        /// Updates the match value displayed in the HUD.
        /// </summary>
        /// <param name="match">The current match value to display.</param>
        private void UpdateMatchValue(int match)
        {
            matchValueText.text = "" + GameManager.Instance.ScoreModel.Match;
        }

        /// <summary>
        /// Updates the turn value displayed in the HUD.
        /// </summary>
        private void UpdateTurnValue()
        {
            turnsValueText.text = "" + GameManager.Instance.ScoreModel.Turns;
        }

        private void OnDisable()
        {
            // Clear displayed values and unsubscribe from event updates
            matchValueText.text = "";
            turnsValueText.text = "";
            GameManager.Instance.EventManager.OnMatchUpdate -= UpdateMatchValue;
            GameManager.Instance.EventManager.OnTurnUpdate -= UpdateTurnValue;
        }  
    }
}
