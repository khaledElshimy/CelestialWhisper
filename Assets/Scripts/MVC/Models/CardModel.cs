using System;
using CM.Enums;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    /// <summary>
    /// Represents a card in the card matching game, including its data and state.
    /// </summary>
    [Serializable]
    public class CardModel : IModel
    {
        [SerializeField]
        private int id;

        /// <summary>
        /// The name of the card.
        /// </summary>
        public string Name;

        /// <summary>
        /// The sprite displayed on the front of the card.
        /// </summary>
        public Sprite frontSprite;

        /// <summary>
        /// The sprite displayed on the back of the card.
        /// </summary>
        public Sprite backSprite;

        /// <summary>
        /// The current state of the card.
        /// </summary>
        public CardState cardState;

        /// <summary>
        /// Gets the unique identifier for the card.
        /// </summary>
        public int Id => id;

        /// <summary>
        /// Initializes the card model with default values.
        /// </summary>
        public void InitializeData()
        {
            id = 0;
            Name = "";
        }

        /// <summary>
        /// Initializes the card model with data from a <see cref="CardModelAsset"/>.
        /// </summary>
        /// <param name="cardModelAsset">The asset containing card data.</param>
        public void InitializeData(CardModelAsset cardModelAsset)
        {
            id = cardModelAsset.id;
            Name = cardModelAsset.Name;
            frontSprite = cardModelAsset.frontSprite;
            backSprite = cardModelAsset.backSprite;
            cardState = cardModelAsset.cardState;
        }

        /// <summary>
        /// Initializes the card model with data from another <see cref="CardModel"/>.
        /// </summary>
        /// <param name="cardModel">The card model to copy data from.</param>
        public void InitializeData(CardModel cardModel)
        {
            id = cardModel.id;
            Name = cardModel.Name;
            frontSprite = cardModel.frontSprite;
            backSprite = cardModel.backSprite;
            cardState = cardModel.cardState;
        }
    }
}
