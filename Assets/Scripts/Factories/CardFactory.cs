using CM.MVC.Interfaces;
using CM.Factories.Interfaces;
using CM.MVC.Views;
using CM.MVC.Models;
using CM.Controllers;

namespace CM.Factories
{
    /// <summary>
    /// A factory class for creating instances of <see cref="CardController{CardModel, CardView}"/>.
    /// </summary>
    public class CardFactory : IFactory<CardModel, CardView, CardController<CardModel, CardView>>
    {
        /// <summary>
        /// Creates and returns a new instance of <see cref="CardController{CardModel, CardView}"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IController{CardModel, CardView}"/>.</returns>
        public IController<CardModel, CardView> Create()
        {
            // Create a new instance of the controller
            CardController<CardModel, CardView> cardController = new CardController<CardModel, CardView>();

            // Set up the controller
            cardController.Setup();

            // Initialize the model's data
            cardController.Model.InitializeData();

            return cardController;
        }
    }
}
