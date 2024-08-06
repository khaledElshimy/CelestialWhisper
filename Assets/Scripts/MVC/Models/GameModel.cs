using System;
using System.Collections.Generic;
using CM.Managers;
using CM.MVC.Interfaces;


namespace CM.MVC.Models
{
    /// <summary>
    /// Represents the model for the game, containing game data and state.
    /// </summary>
    [Serializable]
    public class GameModel : IModel
    {
        /// <summary>
        /// The list of card models used in the game.
        /// </summary>
        public List<CardModel> cards;

        /// <summary>
        /// Indicates whether the game has ended.
        /// </summary>
        public bool gameEnded = false;

        /// <summary>
        /// Gets the unique identifier for the model. (Currently fixed as 0)
        /// </summary>
        public int Id => 0;

        /// <summary>
        /// Initializes the game model by loading the list of cards from the data manager.
        /// </summary>
        public void InitializeData()
        {   
            cards = GameDataManager.Instance.GetCardsList();
        }
    }
}
