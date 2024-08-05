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
        public IController<CardModel, CardView> Create()
        {
             // Create a new instance of the controller
        CardController<CardModel, CardView> cardController = new CardController<CardModel, CardView>();
        cardController.Setup();
        CardModel model = cardController.Model as CardModel;
        
        CardView view = cardController.View as CardView;

        return cardController;
        }

    }

}


