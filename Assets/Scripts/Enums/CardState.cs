namespace CM.Enums
{
    /// <summary>
    /// Represents the various states a card can be in within the game.
    /// </summary>
    public enum CardState 
    {
        // The card is in an uninitialized or default state.
        None,

        // The card is facing up, revealing its face.
        Front,

        // The card is facing down, showing its back.
        Back,

        // The card has been matched with another card.
        Matched
    }
}
