using System;
using UnityEngine;

namespace Enemy {
    public class Health : MonoBehaviour {
        private References _references;
        private int _currentHealth;
        private bool _hasHealthChanged;
        

        private void Awake() {
            _references = GetComponent<References>();
        }

        private void Start() {
            _references.HealthBar.maxValue = _references.MaxHealth;
            _currentHealth = (int)_references.MaxHealth;
            _references.HealthBar.value = _currentHealth;
        }

        public void TakeDamage(int damageAmount) {
            // reduce health
            _currentHealth -= damageAmount;
            _references.HealthBar.value -= damageAmount;
            _hasHealthChanged = true;
        }
        
        public Boolean IsDead() {
            return _currentHealth <= 0;
        }
        
        public Boolean HasHealthChanged() {
            if(_hasHealthChanged) {
                _hasHealthChanged = false;
                return true;
            }
            return false;
        }
    }
}