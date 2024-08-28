using UnityEngine;

namespace Enemy.Helper {
    public class CollisionEnterAndExitSensor : CollisionEnterSensor {
        private void OnCollisionExit2D(Collision2D other) {
            if (!Application.isPlaying) return;

            if (other.gameObject == target.gameObject) {
                triggered = false;
            }
        }
    }
}