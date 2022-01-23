using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] movementScheme;


        [SerializeField]
        private List<Knife> knifesInShield = new List<Knife>();

        private UnityAction onShieldHit; 

        public virtual void Initialize(UnityAction callback)
        {
            onShieldHit = callback;
        }
        public abstract void Rotate();

        public virtual void Dispose()
        {
            onShieldHit = null;
        }
        

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name);

            var knife = other.GetComponentInParent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;
            knife.Rigidbody2D.isKinematic = true;
            knife.transform.position = new Vector3(0, 0, 0);
            knifesInShield.Add(knife);
            knife.transform.SetParent(this.transform);

            onShieldHit.Invoke();

        }
    }
}