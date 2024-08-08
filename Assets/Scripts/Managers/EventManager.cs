using System;
using CM.Enums;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using CM.MVC.Views;
using UnityEngine;

namespace CM.Managers
{
        /// <summary>
        /// Manages game events and notifications, including state changes, card interactions, and updates.
        /// </summary>
        public class EventManager 
        {
        /// <summary>
        /// Event triggered when the game state changes.
        /// </summary>
        public event Action<GameState> OnGameStateChanged;

        /// <summary>
        /// Event triggered when the match score is updated.
        /// </summary>
        public event Action<int> OnMatchUpdate;

        /// <summary>
        /// Event triggered when a turn is updated.
        /// </summary>
        public event Action OnTurnUpdate;

        /// <summary>
        /// Event triggered when start checking if two cards are matiching or not.
        /// </summary>
        public event Action OnCardMatchingStart;

        /// <summary>
        /// Event triggered when end checking if two cards are matiching or not.
        /// </summary>
        public event Action OnCardMatchingEnd;

        /// <summary>
        /// Event triggered when the game ends.
        /// </summary>
        public event Action OnGameEnded;

        /// <summary>
        /// Event triggered when a card is clicked.
        /// </summary>
        public event Action<IController<CardModel, CardView>> OnCardClicked;

        /// <summary>
        /// Triggers the <see cref="OnGameStateChanged"/> event.
        /// </summary>
        /// <param name="gameState">The new game state.</param>
        public void ChangeGameState(GameState gameState)
        {
            OnGameStateChanged?.Invoke(gameState);
        }

        /// <summary>
        /// Triggers the <see cref="OnCardClicked"/> event.
        /// </summary>
        /// <param name="cardController">The card controller associated with the clicked card.</param>
        public void ClickCard(IController<CardModel, CardView> cardController)
        {
            OnCardClicked?.Invoke(cardController);
        }

        /// <summary>
        /// Triggers the <see cref="OnMatchUpdate"/> event.
        /// </summary>
        /// <param name="matchScore">The updated match score.</param>
        public void MatchUpdate(int matchScore)
        {
            OnMatchUpdate?.Invoke(matchScore);
        }

        /// <summary>
        /// Triggers the <see cref="OnTurnUpdate"/> event.
        /// </summary>
        public void TurnUpdate()
        {
            OnTurnUpdate?.Invoke();
        }

        /// <summary>
        /// Triggers the <see cref="OnGameEnded"/> event.
        /// </summary>
        public void GameEnded()
        {
            OnGameEnded?.Invoke();
        }

        /// <summary>
        /// Triggers the <see cref="OnCardMatchingStart"/> event.
        /// </summary>
        public void CardMatchingStart()
        {
            OnCardMatchingStart?.Invoke();
        }

        /// <summary>
        /// Triggers the <see cref="OnCardMatchingEnd"/> event.
        /// </summary>
        public void CardMatchingEnd()
        {
            OnCardMatchingEnd?.Invoke();
        }
    }
}
