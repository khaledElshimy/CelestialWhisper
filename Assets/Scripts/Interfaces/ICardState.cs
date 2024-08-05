using CM.Enums;

namespace CM.Interfaces
{
    public interface ICardState 
    {
      CardState CardState{ get;}
      void changeState(CardState state);
    }
}
