using System.Collections.Generic;
using CM.Misc;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    public class GameModel : ScriptableObject,  IModel
    {
        public List<CardModel> cards;
      
        public void InitializeData()
        {   
            GameSettings settings = Resources.Load<GameSettings>("Data/Settings");
            var gameSize = settings.GetGameSize();
            CardLoader cardLoader= new CardLoader();
            cards = cardLoader.GetShuffeledCard(gameSize.width, gameSize.height);
        }
    }
}

