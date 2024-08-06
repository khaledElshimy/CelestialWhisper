using CM.MVC.Interfaces;
using CM.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using CM.Controllers;
using CM.MVC.Models;

namespace CM.MVC.Views
{
    public class CardView : IView, IFlipable
    {
        public Image cardImage;
        public GameObject gameObject {get; private set;}
        private float flipDuration = 0.5f;
        
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
            if (animate)
            {
                cardImage.sprite =  sprite;
                Flip();

            }
            else
            {
                cardImage.sprite =  sprite;
            }
        }

        public void Flip()
        {   
            GameManager.Instance.StartCoroutine(FlipCardAnimation());
        }
        
        private IEnumerator FlipCardAnimation()
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

            float elapsedTime = 0f;
            Quaternion startRotation = rectTransform.rotation;
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 180, 0);

            while (elapsedTime < flipDuration)
            {
                rectTransform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / flipDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rectTransform.rotation = endRotation;
        }
    }
}
