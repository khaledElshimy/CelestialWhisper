using System;
using CM.Managers;
using UnityEngine;

namespace CM.Misc
{
    [Serializable]
    public class GameSettings 
    {
       public int gameDifficulty;
       public int Width = 2;
       public int Height = 2;
        private static readonly (int Width, int Height)[] DifficultySizes = 
        {
            (2, 2),  // Level 1
            (3, 3),  // Level 2
            (4, 4),  // Level 3
            (5, 5),  // Level 4
            (5, 6)   // Level 5
        };
        public void UpdateGameSize(int width, int height)
        {
            Width = width;
            Height = height;
            GameDataManager.Instance.SaveGameSettings(this);
        }

        public void UpdateGameDifficulty(int difficulty)
        {
            gameDifficulty = difficulty;
            if (gameDifficulty >= 1 && gameDifficulty <= DifficultySizes.Length)
            {
                Width = DifficultySizes[gameDifficulty - 1].Width;
                Height = DifficultySizes[gameDifficulty - 1].Height;
            }
            GameDataManager.Instance.SaveGameSettings(this);
            // update Width and height
        }

        public int GetGameSize()
        {
            return Width * Height;
        }

        public GameDifficulty GetGameDifficulty()
        {
            return (GameDifficulty)gameDifficulty;
        }
    }
}

