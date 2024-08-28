using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player.Weapon {
    public class Fire : MonoBehaviour {
        [SerializeField] private Transform barrelEnd;
        
        private Instance _currentWeapon;
        private float _nextFire;
        private int _ammoAmount;

        private AudioSource _audioSource;
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }
        public void Init(Instance weapon) {
            _currentWeapon = weapon;
            // TODO
            _ammoAmount = (int)_currentWeapon.MaxBulletAmount;
        }

        public bool HasEnoughAmmo() {
            return _ammoAmount > _currentWeapon.BulletAmountAndSpread.Length;
        }
        
        public bool ShootDelayPassed() {
            return Time.time > _nextFire;
        }

        public void FireWeapon() {
            _nextFire = Time.time + _currentWeapon.FireRate;
            _audioSource.PlayOneShot(_currentWeapon.ShotClip);
            foreach (var bulletInstance in _currentWeapon.BulletAmountAndSpread) {
                var spawnedBullet = Instantiate(_currentWeapon.Bullet, barrelEnd.position, barrelEnd.rotation).GetComponent<Bullet>();
                spawnedBullet.Init(barrelEnd.up * _currentWeapon.BulletSpeed + new Vector3(0f, bulletInstance, 0f));
                _ammoAmount--;
            }
        }
        
        public async UniTaskVoid Reload() {
            var reloadTime = (int)_currentWeapon.ReloadTime * 1000; // Convert to milliseconds
            _audioSource.PlayOneShot(_currentWeapon.ReloadClip);
            await UniTask.Delay(reloadTime);
            _ammoAmount = (int)_currentWeapon.MaxBulletAmount;
        }
    }
}
