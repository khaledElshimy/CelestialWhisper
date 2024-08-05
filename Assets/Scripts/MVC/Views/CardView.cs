using CM.MVC.Interfaces;
using CM.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CM.MVC.Views
{
    public class CardView : MonoBehaviour,IView, IFlipable
    {
        public Image cardImage;
        
        public void Initialize()
        {
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
