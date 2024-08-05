using CM.MVC.Interfaces;
using CM.Factories.Interfaces;
using UnityEngine;
using CM.MVC.Views;
using CM.MVC.Models;
using CM.Controllers;

namespace CM.Factories
{
   public class CardFactory : IFactory<CardModel, CardView, CardController<CardModel, CardView>>
    {
        public IController<CardModel, CardView> Create(Transform container = null)
        {
             // Create a new instance of the controller
        CardController<CardModel, CardView> cardController = new CardController<CardModel, CardView>();
        cardController.Setup();
        CardModel model = cardController.Model as CardModel;
        
        CardView view = cardController.View as CardView;
        view.InitializeView("");

        // Optionally set up the view with a container if provided
        if (container != null)
        {
            view.gameObject.transform.SetParent(container, false);
        }

        return cardController;
        }
        
    }

}


