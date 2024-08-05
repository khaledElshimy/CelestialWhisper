using CM.MVC.Interfaces;
using CM.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CM.MVC.Views
{
    public class CardView : IView, IFlipable
    {
        public Image cardImage;
        public GameObject gameObject {get; private set;}
        
        public void InitializeView(string name)
        {
            // Create the GameObject
            gameObject = new GameObject(name);
            //cardGameObject.transform.SetParent(container);
            cardImage = gameObject.AddComponent<Image>();
        }

        public void UpdateCardView(Sprite sprite, bool animate)
        {
            cardImage.sprite =  sprite;
            if (animate)
            {
                Flip();
            }
        }

        public void Flip()
        {   
        }
       
    }
}
