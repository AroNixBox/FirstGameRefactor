using UnityEngine;

namespace Enemy.Helper {
    public class TriggerEnterSensor : Sensor {
        private void Start() {
            Collider.isTrigger = true;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject == target.gameObject) {
                triggered = true;
            }
        }
    }
}