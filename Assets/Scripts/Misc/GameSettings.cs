using System;
using UnityEngine;

namespace CM.Misc
{
    public class GameSettings 
    {
       private int Width = 2;
       private int Height = 2;

        public void UpdateGameSize(int width, int height)
        {
            Width = width;
            Height = height;
            GameDataManager.Instance.SaveGameSettings(this);
        }

        public int GetGameSize()
        {
            return Width * Height;
        }
    }
}

