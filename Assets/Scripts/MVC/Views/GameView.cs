using System.Collections.Generic;
using CM.Controllers;
using CM.Managers;
using CM.MVC.Interfaces;
using CM.MVC.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CM.MVC.Views
{
    /// <summary>
    /// Represents the view for the game grid, including card layout and score display.
    /// </summary>
    public class GameView : IView
    {
        [SerializeField]
        private List<IView> cardViews = new List<IView>();

        [SerializeField]
        private Text score;

        /// <summary>
        /// The GameObject associated with this view.
        /// </summary>
        public GameObject gameObject { get; private set; }

        private float gameViewWidth;
        private float gameViewHeight;

        /// <summary>
        /// Initializes the view by creating and setting up the GameObject.
        /// </summary>
        /// <param name="name">The name of the GameObject.</param>
        /// <param name="parentTransform">The parent transform to attach the GameObject to.</param>
        public void InitializeView(string name, Transform parentTransform)
        {
            // Create the GameObject
            gameObject = new GameObject(name);
            
            RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
            rectTransform.SetParent(parentTransform);
            rectTransform.anchorMin = new Vector2(0.0f, 0.0f); // Anchor to the bottom-left corner
            rectTransform.anchorMax = new Vector2(1f, 1); // Stretch to the top-right corner
            rectTransform.pivot = new Vector2(0.5f, 0.5f); // Pivot in the center

            // Set size and position
            rectTransform.sizeDelta = parentTransform.GetComponent<RectTransform>().sizeDelta;
            rectTransform.localScale = Vector3.one; 
            rectTransform.anchoredPosition = Vector2.zero;

            // Set padding values
            float left = 100;
            float top = 100;
            float right = 100;
            float bottom = 100;
            rectTransform.offsetMin = new Vector2(left, bottom); // left and bottom padding
            rectTransform.offsetMax = new Vector2(-right, -top); // right and top padding

            gameViewWidth = rectTransform.rect.width - (left + right);
            gameViewHeight = rectTransform.rect.height - (top + bottom);
        }

        /// <summary>
        /// Creates a grid layout for displaying cards.
        /// </summary>
        public void CreateGridLayout()
        {
            int gameSize = GameManager.Instance.Settings.GetGameSize();
            int cols = Mathf.FloorToInt(Mathf.Sqrt(gameSize)); // Number of columns
            cols = cols % 2 != 0 ? cols + 1 : cols; // Ensure even number of columns
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

        /// <summary>
        /// Populates the view with card components.
        /// </summary>
        /// <param name="cards">A list of card controllers to populate the view with.</param>
        public void PopulateCards(List<CardController<CardModel, CardView>> cards)
        {
            foreach (var card in cards)
            {
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
