using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.MVC.Models
{
    public class ScoreModel : ScriptableObject, IModel
    {
        public int Score {get;set;}

        public void InitializeData()
        {
             
        }
    }
}