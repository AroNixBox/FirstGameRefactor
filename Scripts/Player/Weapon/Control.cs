using UnityEngine;

namespace Player.Weapon {
    public class Control : MonoBehaviour {
        [SerializeField] private Instance[] weapons;
        private int _highestWeaponIndex;
        private int _selectedWeaponIndex;
        private Fire _selectedWeapon;
        private void Start() {
            _highestWeaponIndex = weapons.Length - 1;
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                SwitchWeapon();
            } 
            
            if(_selectedWeapon == null) { return; }
            
            if (Input.GetButtonDown("Fire1") && _selectedWeapon.ShootDelayPassed() && _selectedWeapon.HasEnoughAmmo()) {
                _selectedWeapon.FireWeapon();
            } else if (Input.GetKeyDown(KeyCode.R)) {
                _selectedWeapon.Reload().Forget();
            }
        }
        
        private void SwitchWeapon() {
            if(_selectedWeapon != null) {
                Destroy(_selectedWeapon.gameObject);
            }
            
            _selectedWeapon = Instantiate(weapons[_selectedWeaponIndex].Weapon.gameObject, 
                transform.position, transform.rotation).GetComponent<Fire>();
            
            // Position the weapon correctly
            _selectedWeapon.transform.SetParent(transform);
            _selectedWeapon.transform.localPosition = weapons[_selectedWeaponIndex].PositionOffset;
            
            // Setup the weapon
            _selectedWeapon.Init(weapons[_selectedWeaponIndex]);

            if(_selectedWeaponIndex == _highestWeaponIndex) {
                _selectedWeaponIndex = 0;
            } else {
                _selectedWeaponIndex++;
            }
        }
    }
}
