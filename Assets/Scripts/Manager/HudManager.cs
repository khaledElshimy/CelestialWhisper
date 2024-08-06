using System.Collections;
using System.Collections.Generic;
using CM.Enums;
using CM.MVC.Models;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private Text matchValueText;
     
    [SerializeField]
    private Text turnsValueText;

    private ScoreModel scoreModel;
     
     private void Start()
    {
        homeButton.onClick.AddListener(backToHome);
        scoreModel = new ScoreModel();
        scoreModel.InitializeData();
    }

    private void backToHome()
    {
        GameManager.Instance.EventManager.ChangeGameState(GameState.Reset);
    }
    private void OnEnable()
    {
        GameManager.Instance.EventManager.OnMatchUpdate += UpdateMatchValue;
        GameManager.Instance.EventManager.OnTurnpdate += UpdateTurnValue;
    }
    private void UpdateMatchValue()
    {
        matchValueText.text = "" + ++scoreModel.Match;
        scoreModel.SaveScore();
    }

    private void UpdateTurnValue()
    {
        turnsValueText.text = "" + ++scoreModel.Turns;
        scoreModel.SaveScore();
    }

    private void OnDisable()
    {
        matchValueText.text = "";
        turnsValueText.text = "";
        GameManager.Instance.EventManager.OnMatchUpdate -= UpdateMatchValue;
        GameManager.Instance.EventManager.OnTurnpdate -= UpdateTurnValue;
    }
}
