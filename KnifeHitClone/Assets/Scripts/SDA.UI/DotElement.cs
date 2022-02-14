using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace SDA.UI
{
    public class DotElement : MonoBehaviour
    {
        [SerializeField]
        private Image dotImage;


        public void MarkAsUnlocked()
        {
            dotImage.DOColor(Color.yellow, .5f);
        }
        public void MarkAsLocked()
        {
            dotImage.color = Color.cyan;
        }

    }
}