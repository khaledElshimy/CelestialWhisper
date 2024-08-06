using System;
using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;

public class EventManager 
{
    public event Action<GameState> OnGameStateChanged;
    public event Action<int> OnMatchUpdate;
    public event Action OnTurnpdate;
    public event Action OnGameEndded;

    
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

    public void MatchUpdate(int matchScore)
    {
        OnMatchUpdate?.Invoke(matchScore);
    }

    public void TurnUpdate()
    {
        OnTurnpdate?.Invoke();
    }

    public void GameEndded()
    {
        OnGameEndded?.Invoke();
    }
}