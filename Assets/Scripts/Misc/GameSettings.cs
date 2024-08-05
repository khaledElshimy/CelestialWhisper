using System;
using UnityEngine;

namespace CM.Misc
{
    public class GameSettings 
    {
       [SerializeField]
       private int Width;
       [SerializeField]
       private int Height;

        public void UpdateGameSize(int width, int height)
        {
            Width = width;
            Height = height;
            GameDataManager.Instance.SaveGameSettings(this);
        }

        public (int width, int height) GetGameSize()
        {
            return (Width, Height);
        }
    }
}

