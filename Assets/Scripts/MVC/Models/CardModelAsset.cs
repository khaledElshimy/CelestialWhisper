using System;
using CM.Enums;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [CreateAssetMenu(fileName = "Card", menuName = "Card Matching Game/Card")]
    public class CardModelAsset: ScriptableObject
    {
        public int id;
        public string Name;
        public Sprite frontSprite;
        public Sprite backSprite;
        public CardState cardState;
    }
}