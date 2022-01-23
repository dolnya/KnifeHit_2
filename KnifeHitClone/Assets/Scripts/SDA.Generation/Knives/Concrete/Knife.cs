using UnityEngine;
namespace SDA.Generation
{
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidbody2D;
        [SerializeField]
        private float speed;

        public Rigidbody2D Rigidbody2D;
        public void ThrowKnife(Knife knife)
        {
            rigidbody2D.AddForce(Vector2.up * (speed *Time.fixedDeltaTime), ForceMode2D.Impulse);
            
            Debug.Log("Throw Knife");
        }
    }
}
