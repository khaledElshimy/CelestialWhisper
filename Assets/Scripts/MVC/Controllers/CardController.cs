using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;
using UnityEngine.UI;
namespace CM.Controllers
{
    public class CardController<M, V> : IController<M, V> 
    where M : CardModel where V : CardView, new()
    {
        
        CardModel cardModel;
        CardView cardView;

        public IModel Model
        {
            get {return cardModel; }
            private set { cardModel = value as CardModel; }
        }

        public IView View
        {
            get { return cardView; }
            private set { cardView = value as CardView; }
        }
        

        public void Setup()
        {
            cardModel = new CardModel();
            cardView = new CardView();
        }

        private void DisableClick()
        {
            cardView.gameObject.GetComponent<Button>().enabled = false;
        }

        public void updateCardView(CardModel cardModel)
        {
            cardView.gameObject.name = cardModel.Name;
            cardView.UpdateCardView(cardModel.backSprite, false);
        }


        public void ChangeCardState(CardState cardState)
        {
            Debug.Log("" + cardState.ToString());
            if (cardState != cardModel.cardState && cardModel.cardState != CardState.Matched)
            {

                switch (cardState)
                {
                    case CardState.Back:
                        cardModel.cardState = cardState;
                        cardView.UpdateCardView(cardModel.backSprite, true);
                        break;
                    case CardState.Front:
                        cardModel.cardState = cardState;
                        cardView.UpdateCardView(cardModel.frontSprite, true);
                        break;
                    case CardState.Matched:
                        cardModel.cardState = cardState;
                        DisableClick();
                        break;
                    case CardState.None:
                    default:
                        break;
                }
            } 
        }

    }
}

