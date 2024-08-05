using System;
using CM.Enums;

public class EventManager 
{
    public static event Action<GameState> OnChangeGameState;

    public void ChangeGameState(GameState gameState)
    {
        OnChangeGameState?.Invoke(gameState);
    }
}