using System;
using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;

public class EventManager 
{
    public event Action<GameState> OnGameStateChanged;
    public event Action OnMatchUpdate;
    public event Action OnTurnpdate;
    
    public event Action<IController<CardModel, CardView>> OnCardClicked;



    public void ChangeGameState(GameState gameState)
    {
        OnGameStateChanged?.Invoke(gameState);
    }

    public void ClickCard(IController<CardModel, CardView> cardController)
    {
        Debug.Log("" + cardController.Model.Id);
        OnCardClicked?.Invoke(cardController);
    }

    public void MatchUpdate()
    {
        OnMatchUpdate?.Invoke();
    }

    public void TurnUpdate()
    {
        OnTurnpdate?.Invoke();
    }
}