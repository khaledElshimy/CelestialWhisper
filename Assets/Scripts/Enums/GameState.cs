namespace CM.Enums
{
    /// <summary>
    /// Represents the various states of the game.
    /// </summary>
    public enum GameState 
    {
        // The game is in an uninitialized or default state.
        None,

        // The game is currently at the main menu.
        MainMenu,

        // The game is currently being played.
        GamePlay,

        // The game is in the process of being reset.
        Reset
    }
}
