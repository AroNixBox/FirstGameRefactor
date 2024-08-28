using System;
using UnityEngine;

namespace Enemy.Helper {
    [RequireComponent(typeof(Collider2D))]
    public abstract class Sensor : MonoBehaviour {
        [SerializeField] protected Transform target;
        protected Collider2D Collider;
        protected bool triggered;

        private void Awake() {
            Collider = GetComponent<Collider2D>(); 
        }

        public bool Triggered() {
            return triggered;
        }
    }
}
