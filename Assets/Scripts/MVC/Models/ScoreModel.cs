using System;
using CM.Misc;
using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    [Serializable]
    public class ScoreModel : ScriptableObject, IModel
    {
        public int Score {get;set;}

        public void InitializeData()
        {
             Score = GameDataManager.Instance.LoadScore() ;
        }
    }
}