using System.Collections;
using System.Collections.Generic;
using CM.Enums;
using CM.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
    public class ResetGameManager : MonoBehaviour
    {
        public Button playButton;


        void Start()
        {
            playButton.onClick.AddListener(RestartGame);
        }

        void RestartGame()
        {
            GameManager.Instance.EventManager.ChangeGameState(GameState.GamePlay);
        }
    }
}
