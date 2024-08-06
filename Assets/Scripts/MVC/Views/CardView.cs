using CM.MVC.Interfaces;
using CM.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using CM.Controllers;
using CM.MVC.Models;
using CM.Managers;

namespace CM.MVC.Views
{
    public class CardView : IView, IFlipable
    {
        public Image cardImage;
        public GameObject gameObject {get; private set;}
        private float flipDuration = 0.5f;

        private Sprite currenSprite;
        
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
                currenSprite =  sprite;
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
            float elapsedTime = 0f;
            Quaternion startRotation = cardImage.transform.rotation;
            Quaternion midRotation = startRotation * Quaternion.Euler(0, 90, 0); // Rotate to 90 degrees
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 180, 0); // Rotate to 180 degrees
            SoundManager.Instance.PlaySound(SoundManager.Instance.flipSound);
            while (elapsedTime < flipDuration / 2)
            {
                cardImage.transform.rotation = Quaternion.Slerp(startRotation, midRotation, elapsedTime / (flipDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cardImage.transform.rotation = midRotation;
            cardImage.sprite = currenSprite; // Switch the sprite

            elapsedTime = 0f;
            while (elapsedTime < flipDuration / 2)
            {
                cardImage.transform.rotation = Quaternion.Slerp(midRotation, endRotation, elapsedTime / (flipDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
                yield return null;

            cardImage.transform.rotation = endRotation;
        }
    }
}
