using System.Collections;
using System.Collections.Generic;
using CM.Enums;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void StartGame()
    {
        GameManager.Instance.EventManager.ChangeGameState(GameState.GamePlay);
    }
}
