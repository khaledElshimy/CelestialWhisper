using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CM.MVC.Models;
using UnityEngine;

namespace CM.Misc
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

        public void SaveGameData(List<CardModel> cardList)
        {
            string json = JsonUtility.ToJson(new CardDataListWrapper{cardDataList = cardList});
            string path = Path.Combine(Application.persistentDataPath, Configurations.CARDS_FILE_NAME);

            File.WriteAllText(path, json);
            Debug.Log($"Game Model saved at {path}");
        }

        public void SaveGameSettings(GameSettings gameSettings)
        {
            string json = JsonUtility.ToJson(gameSettings);
            string path = Path.Combine(Application.persistentDataPath, Configurations.SETTINGS_FILE_NAME);

            File.WriteAllText(path, json);
            Debug.Log($"Game Settings saved at {path}");
        }

        public void SaveGameScore(ScoreModel scoreModel)
        {
            string json = JsonUtility.ToJson(scoreModel);
            string path = Path.Combine(Application.persistentDataPath, Configurations.SCORE_FILE_NAME);

            File.WriteAllText(path, json);
            Debug.Log($"Game Score saved at {path}");
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
                Debug.LogError($"File not found at {path}");
            }
            
            return null;
        }
        public int LoadScore()
        {
            string path = Path.Combine(Application.persistentDataPath, Configurations.SCORE_FILE_NAME);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                ScoreModel scoreModel = JsonUtility.FromJson<ScoreModel>(json);
                Debug.Log($"Score loaded from {path}");
                return scoreModel.Score;
            }
            else
            {
                Debug.LogError($"File not found at {path}");
            }

            return 0;
        }
        public List<CardModel> LoadCards()
        {
            string path = Path.Combine(Application.persistentDataPath, Configurations.CARDS_FILE_NAME);
             List<CardModel> cards = new List<CardModel>();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                CardDataListWrapper datawrapper = JsonUtility.FromJson<CardDataListWrapper>(json);
                if (datawrapper == null)
                {
                    cards = GetCardsList();
                }
                Debug.Log($"CardData list loaded from {path}");
                cards = datawrapper.cardDataList;
            }
            else
            {
                Debug.LogError($"File not found at {path}");
                cards = GetCardsList();
            }
            return cards;
        }


        private  List<CardModel> GetCardsList()
        {
            // Load all CardModel Scriptable Objects in the "Cards" folder
            List<CardModel> allCards = Resources.LoadAll<CardModel>("Cards").ToList();

            if (allCards == null || allCards.Count == 0)
            {
                Debug.LogError("No cards found in the Resources/Cards folder!");
                return null;
            }

            allCards.Shuffle();
            return allCards;
        }

        [Serializable]
        private class CardDataListWrapper
        {
            public List<CardModel> cardDataList;
        }
    }
}
