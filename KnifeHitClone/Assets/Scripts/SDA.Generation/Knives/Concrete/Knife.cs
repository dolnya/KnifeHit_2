using UnityEngine;
using UnityEngine.Events;

namespace SDA.Generation
{
    public class Knife : MonoBehaviour
    {
        private UnityAction onLose;

        [SerializeField]
        private Rigidbody2D rigidbody2D;
        [SerializeField]
        private float speed;

        public Rigidbody2D Rigidbody2D => rigidbody2D;


        public void InitKnife(UnityAction onLoseCallback)
        {
            this.onLose = onLoseCallback;
        }

        public void Deinit()
        {
            this.onLose = null;
        }

        public void ThrowKnife()
        {
            rigidbody2D.AddForce(Vector2.up * (speed * Time.fixedDeltaTime),
                ForceMode2D.Impulse);

            Debug.Log("Throw Knife");
        }
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Knife"))
            {
                onLose?.Invoke();
                onLose = null;
            }
        }

        public void DestroyKnife()
        {
            Destroy(this.gameObject);
        }

    }
}
