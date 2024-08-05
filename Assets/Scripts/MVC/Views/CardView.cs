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

        public void InitializeView(string name, Transform parentTransform)
        {
            // Create the GameObject
            gameObject = new GameObject(name); 
            //cardGameObject.transform.SetParent(container);
            cardImage = gameObject.AddComponent<Image>();
            if (parentTransform != null) 
            {
                gameObject.transform.SetParent(parentTransform);
            }
            gameObject.transform.localScale = Vector3.one;
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
