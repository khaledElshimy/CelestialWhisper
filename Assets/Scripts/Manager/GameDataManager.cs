using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CM.Misc;
using CM.MVC.Models;
using UnityEngine;

namespace CM.Managers
{
    public class GameDataManager : MonoBehaviour
    {
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

        public void SaveGameSettings(GameSettings gameSettings)
        {
            string json = JsonUtility.ToJson(gameSettings);
            string path = Path.Combine(Application.persistentDataPath, Configurations.SETTINGS_FILE_NAME);

            File.WriteAllText(path, json);
            Debug.Log($"Game Settings saved at {path}");
        }

        public GameSettings LoadGameSettings()
        {
            string path = Path.Combine(Application.persistentDataPath, Configurations.SETTINGS_FILE_NAME);
             
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                GameSettings settings = JsonUtility.FromJson<GameSettings>(json);
                Debug.Log($"Settings loaded from {path}");
                return settings;
            }
            else
            {
                Debug.Log($"File not found at {path}, a default settings have returned");
            }
            
            return new GameSettings();
        }

        public List<CardModel> GetCardsList()
        {
            // Load all CardModel Scriptable Objects in the "Cards" folder
            List<CardModelAsset> allCards = Resources.LoadAll<CardModelAsset>(Configurations.CARDS_RESOURCES_PATH).ToList();
             List<CardModel> cards = new List<CardModel>();

            if (allCards == null || allCards.Count == 0)
            {
                Debug.LogError("No cards found in the Resources/Data/Cards folder!");
            }

            foreach(var cardAsset in allCards) {
                CardModel cardModel = new CardModel();
                cardModel.InitializeData(cardAsset);  
                cards.Add(cardModel);
            }

            cards.Shuffle();
            int gameSize = GameManager.Instance.Settings.GetGameSize();
    
            List<CardModel> selectedCards = cards.GetRange(0, Math.Min(Mathf.CeilToInt(gameSize/2), allCards.Count));
            List<CardModel> gameCards = selectedCards.SelectMany(item => new List<CardModel> { item, item }).ToList();
           
            gameCards.Shuffle();
            return gameCards;
        }
    }
}
