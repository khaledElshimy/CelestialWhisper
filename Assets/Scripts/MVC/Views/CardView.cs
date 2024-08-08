using CM.MVC.Interfaces;
using CM.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CM.Managers;

namespace CM.MVC.Views
{
    /// <summary>
    /// Represents the visual component of a card in the game.
    /// </summary>
    public class CardView : IView, IFlipable
    {
        /// <summary>
        /// The Image component of the card.
        /// </summary>
        public Image cardImage;

        /// <summary>
        /// The GameObject associated with this view.
        /// </summary>
        public GameObject gameObject { get; private set; }

        private float flipDuration = 0.5f;
        private Sprite currenSprite;

        /// <summary>
        /// Initializes the view by creating and setting up the GameObject.
        /// </summary>
        /// <param name="name">The name of the GameObject.</param>
        /// <param name="parentTransform">The parent transform to attach the GameObject to.</param>
        public void InitializeView(string name, Transform parentTransform)
        {
            // Create the GameObject
            gameObject = new GameObject(name); 
            // Add an Image component
            cardImage = gameObject.AddComponent<Image>();
            // Set parent transform if provided
            if (parentTransform != null) 
            {
                gameObject.transform.SetParent(parentTransform);
            }
            gameObject.transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Updates the card's image with an optional flip animation.
        /// </summary>
        /// <param name="sprite">The sprite to display on the card.</param>
        /// <param name="animate">Whether to animate the card flip.</param>
        public void UpdateCardView(Sprite sprite, bool animate)
        {
            if (animate)
            {
                currenSprite = sprite;
                Flip();
            }
            else
            {
                cardImage.sprite = sprite;
            }
        }

        /// <summary>
        /// Starts the flip animation for the card.
        /// </summary>
        public void Flip()
        {   
            GameManager.Instance.StartCoroutine(FlipCardAnimation());
        }
        
        /// <summary>
        /// Handles the animation of flipping the card.
        /// </summary>
        /// <returns>An IEnumerator for coroutine processing.</returns>
        private IEnumerator FlipCardAnimation()
        {
            float elapsedTime = 0f;
            Quaternion startRotation = cardImage.transform.rotation;
            Quaternion midRotation = startRotation * Quaternion.Euler(0, 90, 0); // Rotate to 90 degrees
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 180, 0); // Rotate to 180 degrees
            SoundManager.Instance.PlaySound(SoundManager.Instance.flipSound);

            // Animate rotation to 90 degrees
            while (elapsedTime < flipDuration / 2)
            {
                cardImage.transform.rotation = Quaternion.Slerp(startRotation, midRotation, elapsedTime / (flipDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Set the sprite to the new one
            cardImage.transform.rotation = midRotation;
            cardImage.sprite = currenSprite; 

            elapsedTime = 0f;
            // Animate rotation to 180 degrees
            while (elapsedTime < flipDuration / 2)
            {
                cardImage.transform.rotation = Quaternion.Slerp(midRotation, endRotation, elapsedTime / (flipDuration / 2));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            // Ensure final rotation
            cardImage.transform.rotation = endRotation;
        }
    }
}
