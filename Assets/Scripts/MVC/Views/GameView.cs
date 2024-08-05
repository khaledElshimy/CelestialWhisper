using System.Collections.Generic;
using CM.MVC.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CM.MVC.Views
{
    public class GameView : IView
    {
        [SerializeField]
        private Transform cardsContainer;
        [SerializeField]
        private List<IView> cardViews = new List<IView>();
        [SerializeField]
        private Text score;

        public GameObject gameObject => throw new System.NotImplementedException();

        public void Initialize()
        {

        }
         
        public void AddCardView(CardView cardView)
        {
            cardViews.Add(cardView);
        }
        
        
    }
}
