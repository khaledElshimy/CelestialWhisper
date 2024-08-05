using System;
using CM.Enums;

public class EventManager 
{
    public event Action<GameState> OnChangeGameState;
    public event Action<int> OnMatchUpdate;
    public event Action<int> OnTurnpdate;


    public void ChangeGameState(GameState gameState)
    {
        OnChangeGameState?.Invoke(gameState);
    }

    public void MatchUpdate(int match)
    {
        OnMatchUpdate?.Invoke(match);
    }

    public void TurnUpdate(int turn)
    {
        OnTurnpdate?.Invoke(turn);
    }
}