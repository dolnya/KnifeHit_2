using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class KnifeAmmoDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image image;


        public void MarkAsUnlocked()
        {
            image.color = Color.white;
        }
        public void MarkAsLocked()
        {
            image.DOColor(Color.black, .3f);
        }


    }
}