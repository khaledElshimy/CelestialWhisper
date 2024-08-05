using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
namespace CM.Controllers
{
    public class CardController<M, V> : IController<IModel, IView> 
    where M : CardModel where V : CardView, new()
    {
        CardModel cardModel;
        CardView cardView;
        public IModel Model {get{return cardModel;} private set{Model = cardModel;} }
        public IView View {get{return cardView;} private set{View = cardView;} }


        public void Setup()
        {
           CardModel cardModel = Model as CardModel;
           CardView cardView = View as CardView;
        }


        public void ChangeCardState(CardState cardState)
          {
        
              if (cardState == cardModel.cardState || cardModel.cardState == CardState.Matched) return;
              switch (cardModel.cardState)
              {
                  case CardState.Back:
                        cardModel.cardState = cardState;
                        cardView.UpdateCardView(cardModel.backSprite, true);
                  break;
                  case CardState.Front: 
                        cardModel.cardState= cardState;
                        cardView.UpdateCardView(cardModel.frontSprite, true);
                  break;
                  case CardState.Matched: 
                  cardModel.cardState = cardState;
                  break;
                  case CardState.None:
                  default:
                  break;
              }
          }

    }
}

