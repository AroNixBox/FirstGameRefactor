using UnityEngine;

namespace Enemy.Helper {
    public class TriggerEnterAndExitSensor : TriggerEnterSensor {
        private void OnTriggerExit2D(Collider2D other) {
            if (!Application.isPlaying) return;

            if (other.gameObject == target.gameObject) {
                triggered = false;
            }
        }
    }
}