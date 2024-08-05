using CM.Enums;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [CreateAssetMenu(fileName = "Card", menuName = "Card Matching Game/Card")]
    public class CardModel: ScriptableObject, IModel
    {
        public int Id;
        public Sprite frontSprite;
        public Sprite backSprite;
        public CardState cardState;

    }
}