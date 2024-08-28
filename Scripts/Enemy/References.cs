using Enemy.Helper;
using Player;
using UnityEngine;

namespace Enemy {
    public class References : MonoBehaviour {
        // Sounds
        [field: SerializeField] public AudioClip BaseZombieSound { get; private set; }
        [field: SerializeField] public AudioClip RangeZombieSound { get; private set; }
        [field: SerializeField] public AudioClip BaseZombieDeathSound { get; private set; }
        [field: SerializeField] public AudioClip RangeZombieDeathSound { get; private set; }
        
        // If meele enemy 0, if ranged
        [field: SerializeField] public float DistanceToPlayer { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; } = 80;
        [field: SerializeField] public Type EnemyType { get; private set; }
        [field: SerializeField] public uint MaxHealth { get; private set; } = 100;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 2f;
        [field: SerializeField] public float AttackDamage { get; private set; } = 10f;
        [field: SerializeField] public float TimeTillNewAttack { get; private set; } = 1f;
        [field: SerializeField] public float PatrolWaitTime { get; private set; } = 0.5f;
        // All Waypoints should be children of this object
        [field: SerializeField] public Transform WaypointsParent { get; private set; }
        [field: SerializeField] public Bullet Projectile { get; private set; }
        
        public const string ANIM_ENEMY_DEATH = "Enemy_Death";
        public const string ANIM_RANGED_ENEMY_DEATH = "Ranged_Enemy_Death";
        
        public Player.Health PlayerHealth { get; private set; }
        public Health Health { get; private set; }
        public UnityEngine.UI.Slider HealthBar { get; private set; }
        private AudioSource _audioSource;
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        
        [field: SerializeField] public Sensor AttackSensor { get; private set; }
        [field: SerializeField] public Sensor WakeUpSensor { get; private set; }
        
        private bool _isInAttackRange;
        private bool _inWakeUpRange;
        
        public enum Type {
            BaseZombie,
            RangeZombie
        }
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _animator = gameObject.GetComponent<Animator>();
            HealthBar = GetComponentInChildren<UnityEngine.UI.Slider>();
            Health = GetComponent<Health>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            PlayerHealth = ReferenceHolder.Instance.Player;
            
            // Play zombie sound
            _audioSource.clip = EnemyType == Type.BaseZombie ? BaseZombieSound : RangeZombieSound;
            _audioSource.Play();
        }
        
        public void MoveTowards(Vector2 targetPosition, float speed) {
            var direction = (targetPosition - (Vector2)transform.position).normalized;
            // No multiplication with Time.deltaTime needed, because we are setting the velocity directly on the rb
            _rigidbody2D.velocity = direction * speed;
        }
        public void SetRotation(float zRotation) {
            transform.rotation = Quaternion.Euler(0, 0, zRotation);
        }

        public void PlayClip(AudioClip clip, bool loop) {
            _audioSource.loop = loop;
            _audioSource.clip = clip;
            _audioSource.Play();
        }
        public float GetClipLength() {
            return _audioSource.clip.length;
        }
        public void PlayAnimation(string stateName) {
            _animator.Play(stateName);
        }
        public void DestroySelf() {
            Destroy(gameObject);
        }
        public GameObject SpawnActor(GameObject unitPrefab, Vector3 position, Quaternion rotation) {
            var spawnedActor = Instantiate(unitPrefab, position, rotation);
            return spawnedActor;
        }

        #region Debugging

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, DistanceToPlayer);
        }

        #endregion
    }
}
