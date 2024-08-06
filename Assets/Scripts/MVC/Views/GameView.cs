using System.Collections.Generic;
using CM.Controllers;
using CM.Factories;
using CM.Managers;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CM.MVC.Views
{
    public class GameView : IView
    {
        [SerializeField]
        private List<IView> cardViews = new List<IView>();
        [SerializeField]
        private Text score;

        public GameObject gameObject {get; private set;}

        private float gameViewWidth;
        private float gameViewHeight;


        public void InitializeView(string name, Transform parentTransform)
        {
            gameObject = new GameObject(name);
            
            RectTransform rectTransform = gameObject.AddComponent<RectTransform>();

           // Image image = gameObject.AddComponent<Image>();
           // image.color = new Color(0.2f, 0.2f, 0.2f, 1.0f); // Light grey color

            rectTransform.SetParent(parentTransform);
            rectTransform.anchorMin = new Vector2(0.0f, 0.0f); // Center of the screen
            rectTransform.anchorMax = new Vector2(1f, 1);
            rectTransform.pivot = new Vector2(0.5f, 0.5f); // Pivot in the center
            // Set left, top, right, bottom values

            rectTransform.sizeDelta = parentTransform.GetComponent<RectTransform>().sizeDelta;
            rectTransform.localScale = Vector3.one; 
            rectTransform.anchoredPosition = Vector2.zero;

            // Set left, top, right, bottom values
            float left = 100;
            float top = 100;
            float right = 100;
            float bottom = 100;
            rectTransform.offsetMin = new Vector2(left, bottom); // left and bottom
            rectTransform.offsetMax = new Vector2(-right, -top); // right and top

            gameViewWidth = rectTransform.rect.width - (left + right);
            gameViewHeight = rectTransform.rect.height - (top + bottom);
           
        }

        public void CreateGridLayout()
        {

            int gameSize = GameManager.Instance.Settings.GetGameSize();
            int cols = Mathf.FloorToInt(Mathf.Sqrt(gameSize)); // Number of columns
            cols = cols % 2 != 0 ? cols + 1 : cols;
            int rows = Mathf.CeilToInt((float)gameSize / cols); // Number of rows
            
            float cellWidth = gameViewWidth / cols;
            float cellHeight = gameViewHeight / rows;
            float cellSize = Mathf.Min(cellWidth, cellHeight); // Ensure cellWidth == cellHeight

            // Adjust rows and cols to fit the square cells
            cellWidth = cellSize;
            cellHeight = cellSize;

            GridLayoutGroup gridLayoutGroup = gameObject.AddComponent<GridLayoutGroup>();

            // Set cell size
            gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);

            // Optional: Set spacing, padding, etc.
            gridLayoutGroup.spacing = new Vector2(50, 50);
            gridLayoutGroup.padding = new RectOffset(20, 20, 20, 20);
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
            gridLayoutGroup.constraintCount = cols;
        }
         
        public void PopulateCards(List<CardController<CardModel, CardView> > cards)
        {
            foreach(var card in cards) {
            CardModel cardModel = card.Model as CardModel;
            
            card.View.InitializeView(cardModel.Name, this.gameObject.transform);
            card.updateCardView(cardModel);
            Button button = card.View.gameObject.AddComponent<Button>();
            button.onClick.AddListener(() => GameManager.Instance.EventManager.ClickCard(card));
            cardViews.Add(card.View);
            }
          
        } 
    }
}
