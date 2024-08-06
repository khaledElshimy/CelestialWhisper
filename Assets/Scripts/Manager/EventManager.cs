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
        /// Event triggered when the game ends.
        /// </summary>
        public event Action OnGameEnded;

        /// <summary>
        /// Event triggered when a card is clicked.
        /// </summary>
        public event Action<IController<CardModel, CardView>> OnCardClicked;

        /// <summary>
        /// Changes the game state and triggers the <see cref="OnGameStateChanged"/> event.
        /// </summary>
        /// <param name="gameState">The new game state.</param>
        public void ChangeGameState(GameState gameState)
        {
        OnGameStateChanged?.Invoke(gameState);
        }

        /// <summary>
        /// Handles a card click and triggers the <see cref="OnCardClicked"/> event.
        /// </summary>
        /// <param name="cardController">The card controller associated with the clicked card.</param>
        public void ClickCard(IController<CardModel, CardView> cardController)
        {
        Debug.Log("" + cardController.Model.Id);
        OnCardClicked?.Invoke(cardController);
        }

        /// <summary>
        /// Updates the match score and triggers the <see cref="OnMatchUpdate"/> event.
        /// </summary>
        /// <param name="matchScore">The updated match score.</param>
        public void MatchUpdate(int matchScore)
        {
        OnMatchUpdate?.Invoke(matchScore);
        }

        /// <summary>
        /// Updates the turn and triggers the <see cref="OnTurnUpdate"/> event.
        /// </summary>
        public void TurnUpdate()
        {
        OnTurnUpdate?.Invoke();
        }

        /// <summary>
        /// Ends the game and triggers the <see cref="OnGameEnded"/> event.
        /// </summary>
        public void GameEnded()
        {
        OnGameEnded?.Invoke();
        }
    }
}
