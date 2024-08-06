using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;
using UnityEngine.UI;

namespace CM.Controllers
{
    /// <summary>
    /// Manages the card's model and view, handling its state changes and updates.
    /// </summary>
    /// <typeparam name="M">The type of the card model.</typeparam>
    /// <typeparam name="V">The type of the card view.</typeparam>
    public class CardController<M, V> : IController<M, V> 
    where M : CardModel where V : CardView, new()
    {
        private CardModel cardModel;
        private CardView cardView;

        /// <summary>
        /// Gets the model associated with this controller.
        /// </summary>
        public IModel Model
        {
            get { return cardModel; }
            private set { cardModel = value as CardModel; }
        }

        /// <summary>
        /// Gets the view associated with this controller.
        /// </summary>
        public IView View
        {
            get { return cardView; }
            private set { cardView = value as CardView; }
        }

        /// <summary>
        /// Sets up the card controller, initializing its model and view.
        /// </summary>
        public void Setup()
        {
            cardModel = new CardModel();
            cardView = new CardView();
        }

        /// <summary>
        /// Disables the card's click functionality by disabling its associated button.
        /// </summary>
        private void DisableClick()
        {
            cardView.gameObject.GetComponent<Button>().enabled = false;
        }

        /// <summary>
        /// Updates the card view with the specified model data.
        /// </summary>
        /// <param name="cardModel">The model containing card data to update the view.</param>
        public void updateCardView(CardModel cardModel)
        {
            cardView.gameObject.name = cardModel.Name;
            cardView.UpdateCardView(cardModel.backSprite, false);
        }

        /// <summary>
        /// Changes the state of the card and updates its view accordingly.
        /// </summary>
        /// <param name="cardState">The new state of the card.</param>
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
