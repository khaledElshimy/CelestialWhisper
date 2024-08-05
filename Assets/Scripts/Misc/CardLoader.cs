using System.Collections.Generic;
using CM.MVC.Models;
using UnityEngine;

namespace CM.Misc
{
    public class CardLoader : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<CardModel> GetShuffeledCard(int width, int height)
        {
            int gameSize = width * height / 2;
            // Load all CardModel Scriptable Objects in the "Cards" folder
            CardModel[] allCards = Resources.LoadAll<CardModel>("Data/Cards");
            List<CardModel>  cards = new List<CardModel>();
            if (allCards == null || allCards.Length == 0)
            {
                Debug.LogError("No cards found in the Resources/Cards folder!");
                return null;
            }

            // Shuffle the sorted cards using Fisher-Yates shuffle
            Shuffle(allCards);

            // Debug: Print the shuffled card names
            foreach (var card in allCards)
            {
                Debug.Log($"Shuffled card: {card.Id} with value: {card.Id}");
            }

            for (int i = 0; i < gameSize; i++)
            {
                cards.Add(allCards[i]);
            }
            return cards;           
        }

        private void Shuffle<T>(IList<T> list)
        {
            System.Random rang = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rang.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}

