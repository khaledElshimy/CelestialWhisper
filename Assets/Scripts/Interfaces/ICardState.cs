using CM.Enums;

namespace CM.Interfaces
{
    /// <summary>
    /// Defines the interface for managing the state of a card.
    /// </summary>
    public interface ICardState 
    {
        /// <summary>
        /// Gets the current state of the card.
        /// </summary>
        CardState CardState { get; }

        /// <summary>
        /// Changes the state of the card to the specified state.
        /// </summary>
        /// <param name="state">The new state to set for the card.</param>
        void ChangeState(CardState state);
    }
}
