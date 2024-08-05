using System;
using UnityEngine;

namespace CM.Misc
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Card Matching Game/Settings")]
    public class GameSettings :ScriptableObject
    {
       [SerializeField]
       private int Width;
       [SerializeField]
       private int Height;

        public void UpdateGameSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public (int width, int height) GetGameSize()
        {
            return (Width, Height);
        }
    }
}

