using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CM.Misc;
using CM.MVC.Models;
using UnityEngine;

namespace CM.Managers
{
    /// <summary>
    /// Manages game data including saving and loading settings, and retrieving card models.
    /// </summary>
    public class GameDataManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the GameDataManager.
        /// </summary>
        public static GameDataManager Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Saves game settings to a file in persistent data path.
        /// </summary>
        /// <param name="gameSettings">The game settings to save.</param>
        public void SaveGameSettings(GameSettings gameSettings)
        {
            string json = JsonUtility.ToJson(gameSettings);
            string path = Path.Combine(Application.persistentDataPath, Configurations.SETTINGS_FILE_NAME);

            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Loads game settings from a file in persistent data path.
        /// </summary>
        /// <returns>The loaded game settings, or a default settings instance if the file is not found.</returns>
        public GameSettings LoadGameSettings()
        {
            string path = Path.Combine(Application.persistentDataPath, Configurations.SETTINGS_FILE_NAME);
             
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                GameSettings settings = JsonUtility.FromJson<GameSettings>(json);
                return settings;
            }
            else
            {
                Debug.Log($"File not found at {path}, a default settings have returned");
            }
            
            return new GameSettings();
        }

        /// <summary>
        /// Retrieves a shuffled list of card models for the game.
        /// </summary>
        /// <returns>A shuffled list of card models.</returns>
        public List<CardModel> GetCardsList()
        {
            // Load all CardModel Scriptable Objects in the "Cards" folder
            List<CardModelAsset> allCards = Resources.LoadAll<CardModelAsset>(Configurations.CARDS_RESOURCES_PATH).ToList();
            List<CardModel> cards = new List<CardModel>();

            if (allCards == null || allCards.Count == 0)
            {
                Debug.LogError("No cards found in the Resources/Data/Cards folder!");
            }

            // Iterate through each card asset in the loaded list, Initialize the card model with data from the card asset
            foreach (var cardAsset in allCards) 
            {
                CardModel cardModel = new CardModel();
                cardModel.InitializeData(cardAsset);  
                cards.Add(cardModel);
            }
             
            // Shuffle the list of card models to randomize their order
            cards.Shuffle();
          
            // Get the number of cards needed for the game based on the game size setting
            int gameSize = GameManager.Instance.Settings.GetGameSize();

            // Select a subset of card models from the shuffled list, ensuring the number of cards is appropriate for the game size
            List<CardModel> selectedCards = cards.GetRange(0, Math.Min(Mathf.CeilToInt(gameSize / 2), allCards.Count));

            // Duplicate the selected cards to create pairs, then combine them into a single list
            List<CardModel> gameCards = selectedCards.SelectMany(item => new List<CardModel> { item, item }).ToList();

            // Shuffle the final list of game cards to ensure random distribution of pairs
            gameCards.Shuffle();
            
            return gameCards;
        }
    }
}
