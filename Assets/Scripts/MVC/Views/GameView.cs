using System.Collections.Generic;
using CM.Factories;
using CM.MVC.Interfaces;
using CM.MVC.Models;
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

        public GameObject gameObject {get; private set;}


        public void InitializeView(string name)
        {
            gameObject = new GameObject(name);
        }
         
        public void AddCardView(CardView cardView)
        {
            cardViews.Add(cardView);
        }

        public void PopualeCards(List<CardView> cardViews)
        {
            
        }
        
        
    }
}
