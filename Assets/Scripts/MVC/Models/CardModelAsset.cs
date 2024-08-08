using CM.Enums;
using UnityEngine;

namespace CM.MVC.Models
{
    /// <summary>
    /// Represents the data asset for a card in the card matching game.
    /// </summary>
    [CreateAssetMenu(fileName = "Card", menuName = "Card Matching Game/Card")]
    public class CardModelAsset : ScriptableObject
    {
        /// <summary>
        /// The unique identifier for the card.
        /// </summary>
        public int id;

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
    }
}
