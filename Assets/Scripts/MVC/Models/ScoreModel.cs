using System;

namespace CM.MVC.Models
{
    /// <summary>
    /// Represents the score and turn data for the game.
    /// </summary>
    [Serializable]
    public class ScoreModel
    {
        /// <summary>
        /// The number of matches made in the game.
        /// </summary>
        public int Match;

        /// <summary>
        /// The number of turns taken in the game.
        /// </summary>
        public int Turns;
    }
}
