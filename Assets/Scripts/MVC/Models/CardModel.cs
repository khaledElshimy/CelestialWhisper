using System;
using CM.Enums;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [Serializable]
    public class CardModel: IModel, IComparable
    {
        [SerializeField]
        private int id;
        public string Name;
        public Sprite frontSprite;
        public Sprite backSprite;
        public CardState cardState;

        public int Id => id;

        public void InitializeData()
        {
            id = 0;
            Name = "";
        }
        public void InitializeData( CardModelAsset cardModelAsset)
        {
            id = cardModelAsset.id;
            Name = cardModelAsset.Name;
            frontSprite = cardModelAsset.frontSprite;
            backSprite = cardModelAsset.backSprite;
            cardState = cardModelAsset.cardState;
        }

        public void InitializeData( CardModel cardModel)
        {
            id = cardModel.id;
            Name = cardModel.Name;
            frontSprite = cardModel.frontSprite;
            backSprite = cardModel.backSprite;
            cardState = cardModel.cardState;
        }

        public int CompareTo(object obj)
        {
            CardModel other = obj as CardModel;
            return id == other.id ? 1 : -1;
        }
    }
}