using UnityEngine;
using System.Collections.Generic;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] movementScheme;


        [SerializeField]
        private List<Knife> knifesInShield = new List<Knife>();

        

        public abstract void Initialize();
        public abstract void Rotate();


        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name);

            var knife = other.GetComponent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;

            knife.transform.position = new Vector3(0, 0, 0);
            knifesInShield.Add(knife);
            knife.transform.SetParent(this.transform);


        }
    }
}