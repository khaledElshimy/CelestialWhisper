using System.Collections;
using System.Collections.Generic;
using CM.Enums;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;

    private GameDifficulty  gameDifficulty = GameDifficulty.None;

    [SerializeField]
    private ToggleGroup difficultyToggleGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        gameDifficulty = GameManager.Instance.Settings.GetGameDifficulty();
        UpdateToggleGroup();
    }

    // Update is called once per frame
    void StartGame()
    {
        GameManager.Instance.EventManager.ChangeGameState(GameState.GamePlay);
    }

    public void SelectGameDifficulty(int gameDifficulty)
    {
        GameDifficulty difficulty = (GameDifficulty)gameDifficulty;
        if (this.gameDifficulty != difficulty) 
        {
            this.gameDifficulty = difficulty;
            GameManager.Instance.Settings.UpdateGameDifficulty(gameDifficulty);
        }
    }

    // Method to update the toggle group based on the current difficulty level
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
