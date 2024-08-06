using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CM.Enums;
using CM.Managers;
using CM.MVC.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CM.UI
{
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

        private void backToHome()
        {
            GameManager.Instance.EventManager.ChangeGameState(GameState.MainMenu);
        }
        private void OnEnable()
        {
            GameManager.Instance.EventManager.OnMatchUpdate += UpdateMatchValue;
            GameManager.Instance.EventManager.OnTurnpdate += UpdateTurnValue;
        }
        private void UpdateMatchValue(int match)
        {
            matchValueText.text = "" + GameManager.Instance.ScoreModel.Match;
        }

        private void UpdateTurnValue()
        {
            turnsValueText.text = "" + GameManager.Instance.ScoreModel.Turns;
        }

        private void OnDisable()
        {
            matchValueText.text = "";
            turnsValueText.text = "";
            GameManager.Instance.EventManager.OnMatchUpdate -= UpdateMatchValue;
            GameManager.Instance.EventManager.OnTurnpdate -= UpdateTurnValue;
        }  
    }
}
