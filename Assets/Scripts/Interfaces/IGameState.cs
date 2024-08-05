using CM.Enums;

namespace CM.Interfaces
{
    public interface IGameState 
    {
      void Show(GameState state);
      void Hide(GameState state);
    }
}
