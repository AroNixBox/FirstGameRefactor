using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class Health : MonoBehaviour {
        // Just UI GameOver Handler, weird name yea..
        [SerializeField] private UI.GameOver gameOver;
        [SerializeField] private Slider healthBar;

        [SerializeField] private float maxHealth = 100f;

        private float _currentHealth;

        private void Start() {
            //Setup Healthbar
            healthBar.maxValue = maxHealth;
            _currentHealth = maxHealth;
            healthBar.value = _currentHealth;
        }

        public void TakeDamage(float damageAmount) {
            _currentHealth = Mathf.Clamp(_currentHealth - damageAmount, 0, maxHealth);
            healthBar.value = _currentHealth;

            if (_currentHealth <= 0f) {
                _currentHealth = 0f;
                gameOver.EnableGameLostScreen();
                
                // Pause the game
                Time.timeScale = 0f;
            }
        }
    }
}
