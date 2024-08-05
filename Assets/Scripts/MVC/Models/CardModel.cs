using System;
using CM.Enums;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [CreateAssetMenu(fileName = "Card", menuName = "Card Matching Game/Card")]
    [Serializable]
    public class CardModel: ScriptableObject, IModel
    {
        public int Id;
        public string Name;
        public Sprite frontSprite;
        public Sprite backSprite;
        public CardState cardState;

        public void InitializeData()
        {
            Id = 0;
            Name = "";
        }
    }
}