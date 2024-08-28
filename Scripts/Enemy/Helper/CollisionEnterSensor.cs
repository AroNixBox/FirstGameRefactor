using UnityEngine;

namespace Enemy.Helper {
    public class CollisionEnterSensor : Sensor {
        private void Start() {
            Collider.isTrigger = false;
        }
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject == target.gameObject) {
                triggered = true;
            }
        }
    }
}