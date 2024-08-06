using System;
using CM.Enums;
using CM.Managers;
using UnityEngine;

namespace CM.Misc
{
    /// <summary>
    /// Holds and manages the game settings, including difficulty and grid size.
    /// </summary>
    [Serializable]
    public class GameSettings 
    {
        /// <summary>
        /// The current game difficulty level.
        /// </summary>
        public int gameDifficulty;

        /// <summary>
        /// The width of the game grid.
        /// </summary>
        public int Width = 2;

        /// <summary>
        /// The height of the game grid.
        /// </summary>
        public int Height = 2;

        private static readonly (int Width, int Height)[] DifficultySizes = 
        {
            (2, 2),  // Level 1
            (3, 3),  // Level 2
            (4, 4),  // Level 3
            (5, 5),  // Level 4
            (5, 6)   // Level 5
        };

        /// <summary>
        /// Updates the game grid size.
        /// </summary>
        /// <param name="width">The new width of the game grid.</param>
        /// <param name="height">The new height of the game grid.</param>
        public void UpdateGameSize(int width, int height)
        {
            Width = width;
            Height = height;
            GameDataManager.Instance.SaveGameSettings(this);
        }

        /// <summary>
        /// Updates the game difficulty and adjusts grid size accordingly.
        /// </summary>
        /// <param name="difficulty">The new difficulty level.</param>
        public void UpdateGameDifficulty(int difficulty)
        {
            gameDifficulty = difficulty;
            if (gameDifficulty >= 1 && gameDifficulty <= DifficultySizes.Length)
            {
                Width = DifficultySizes[gameDifficulty - 1].Width;
                Height = DifficultySizes[gameDifficulty - 1].Height;
            }
            GameDataManager.Instance.SaveGameSettings(this);
        }

        /// <summary>
        /// Calculates the total game size based on width and height.
        /// </summary>
        /// <returns>The total size of the game grid.</returns>
        public int GetGameSize()
        {
            return Width * Height;
        }

        /// <summary>
        /// Retrieves the current game difficulty.
        /// </summary>
        /// <returns>The current game difficulty level.</returns>
        public GameDifficulty GetGameDifficulty()
        {
            return (GameDifficulty)gameDifficulty;
        }
    }
}
