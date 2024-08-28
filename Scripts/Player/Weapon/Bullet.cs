using UnityEngine;

namespace Player.Weapon {
    public class Bullet : MonoBehaviour {
        public void Init(Vector2 direction) {
            GetComponent<Rigidbody2D>().AddForce(direction);
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.TryGetComponent<Enemy.Health>(out var health)) {
                health.TakeDamage(25);
                Destroy(gameObject);
            } else if (collision.gameObject.CompareTag("Wall")) {
                Destroy(gameObject);
            }
        }
    }
}
