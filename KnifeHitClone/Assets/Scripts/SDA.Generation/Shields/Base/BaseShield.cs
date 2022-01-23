using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] movementScheme;


        [SerializeField]
        private int knivesToWin;


        [SerializeField]
        private List<Knife> knifesInShield = new List<Knife>();

        private UnityAction onShieldHit;
        private UnityAction onWin;

        public virtual void Initialize(UnityAction onShieldHitCallback, UnityAction onWinCallback
            )
        {
            onShieldHit = onShieldHitCallback;
            onWin = onWinCallback;
        }
        public abstract void Rotate();

        public virtual void Dispose()
        {
            for (int i= knifesInShield.Count -1; i>=0; i--)
            {
                var knife = knifesInShield[i];
                Destroy(knife);
                knifesInShield.Remove(knife);
            }
            knifesInShield.Clear();
            onShieldHit = null;
            onWin = null;
            Destroy(this.gameObject);
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

            if (knifesInShield.Count == knivesToWin)
            {
                onWin.Invoke();
            }
            
            //else
            //{
            //    float mass = 1f;
            //    var knife = other.GetComponentInParent<Knife>();
            //    knife.Rigidbody2D.mass = mass;
            //    Debug.Log(other.gameObject.name);
            //    onShieldHit.Invoke();
            //}
        }
    }
}