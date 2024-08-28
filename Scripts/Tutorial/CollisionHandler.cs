using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Tutorial {
    [RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
    public class CollisionHandler : MonoBehaviour {
        [SerializeField] private GameObject areaDoor;
        [SerializeField] private AudioClip auditieOrders;
        private BoxCollider2D _collider;
        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _collider = GetComponent<BoxCollider2D>();
        }

        private void Start() {
            _collider.isTrigger = true;
        }

        private async void OnTriggerEnter2D(Collider2D collision) {
            if (collision.TryGetComponent(out Player.Health health)) {
                _audioSource.PlayOneShot(auditieOrders);
                await OpenDoor(); // Wait for the AuioClip to finish playing
                Destroy(areaDoor);
                Destroy(gameObject);
            }
        }

        private async UniTask OpenDoor() {
            var waitTime = auditieOrders.length * 1000;
            await UniTask.Delay((int) waitTime);
        }
    }
}
