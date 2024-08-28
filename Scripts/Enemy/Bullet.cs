using Player;
using UnityEngine;

namespace Enemy {
    public class Bullet : MonoBehaviour {
        private Transform _target;
        public void Init(Transform target, float movementForce) {
            _target = target;
            GetComponent<Rigidbody2D>().AddForce((_target.position - transform.position).normalized * movementForce);
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject == _target.gameObject) {
                _target.GetComponent<Player.Health>().TakeDamage(5);
                Destroy(gameObject);
            } else if(collision.gameObject.CompareTag("Wall")) {
                Destroy(gameObject);
            }
        }
    }
}
