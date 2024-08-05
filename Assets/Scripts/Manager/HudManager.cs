using System.Collections;
using System.Collections.Generic;
using CM.Enums;
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
     
     private void Start()
    {
        homeButton.onClick.AddListener(backToHome);
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
    private void UpdateMatchValue(int match)
    {
        matchValueText.text = "" + match;
    }

    private void UpdateTurnValue(int turn)
    {
        turnsValueText.text = "" + turn;
    }

    private void OnDisable()
    {
        matchValueText.text = "";
        turnsValueText.text = "";
        GameManager.Instance.EventManager.OnMatchUpdate -= UpdateMatchValue;
        GameManager.Instance.EventManager.OnTurnpdate -= UpdateTurnValue;
    }
}
