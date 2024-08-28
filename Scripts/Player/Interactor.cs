using TMPro;
using UnityEngine;

namespace Player {
    public class Interactor : MonoBehaviour {
        [SerializeField] private UI.GameOver gameOver;
        [SerializeField] private TMP_Text keyDisplay;
        
        private float _currentKeys;

        private void Start() {
            UpdateKeyText();
        }
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.TryGetComponent(out Chest.Chest chest)) {
                chest.OpenChest(transform);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Door") && HasEnoughKeys()) {
                Destroy(collision.gameObject);
                _ = gameOver.EndGame();
            }
        }

        public void AddKey() {
            _currentKeys += 1f;
            UpdateKeyText();
        }
        private void UpdateKeyText() {
            keyDisplay.text = "Keys: " + _currentKeys;
        }
        private bool HasEnoughKeys() => _currentKeys >= 5f;
    }
}