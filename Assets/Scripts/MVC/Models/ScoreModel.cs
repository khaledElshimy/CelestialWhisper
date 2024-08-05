using System;
using CM.Misc;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [Serializable]
    public class ScoreModel 
    {
        public int Match;
        public int Turns;

        public void InitializeData()
        {
           var Score = GameDataManager.Instance.LoadScore() ;
           Match = Score.match;
           Turns = Score.turns;
        }
    }
}