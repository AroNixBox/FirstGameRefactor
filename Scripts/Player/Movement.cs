using UnityEngine;

namespace Player {
    public class Movement : MonoBehaviour {
        [SerializeField] private float moveSpeed = 5f;

        #region Animation Hashes

        private const string PLAYER_IDLE = "Player_Idle";
        private const string PLAYER_WALK_UP = "Player_Walk_Up";

        #endregion

        private AudioSource _audioSource;
        private Camera _camera;
        private Rigidbody2D _rb;
        private Animator _animator;
    
        private string _currentAnimState;
        private Vector2 _moveDirection;
        private Vector2 _mousePosition;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            HandleInput();
            UpdateMousePosition();
            UpdateAnimationAndSound();
        }

        private void FixedUpdate() {
            MovePlayer();
            RotatePlayer();
        }

        private void HandleInput() {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");
            _moveDirection = new Vector2(moveX, moveY).normalized;
        }

        private void UpdateMousePosition() {
            if (_camera != null) {
                _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            } else {
                Debug.LogError("No Camera Found");
            }
        }

        private void UpdateAnimationAndSound() {
            if (_moveDirection != Vector2.zero) {
                ChangeAnimationState(PLAYER_WALK_UP);
                if (!_audioSource.isPlaying) {
                    _audioSource.Play();
                }
            } else {
                _audioSource.Stop();
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        private void MovePlayer() {
            _rb.velocity = _moveDirection * moveSpeed;
        }

        private void RotatePlayer() {
            var aimDirection = _mousePosition - _rb.position;
            var lookAtMouseRotation = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = lookAtMouseRotation;
        }

        private void ChangeAnimationState(string newState) {
            if (_currentAnimState != newState) {
                _animator.Play(newState);
                _currentAnimState = newState;
            }
        }
    }
}