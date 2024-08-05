using System;
using System.Collections.Generic;
using CM.Misc;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [Serializable]
    public class GameModel : ScriptableObject,  IModel
    {
        public List<CardModel> cards;
        
        public void InitializeData()
        {   
            cards = GameDataManager.Instance.LoadCards();
        }
    }
}

