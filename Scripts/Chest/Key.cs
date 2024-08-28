using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Chest {
    public class Key : MonoBehaviour {
        [SerializeField] private float moveSpeed = 4f;
    
        public void Init(Transform playerTransform) {
            MoveTowardsPlayer(playerTransform).Forget();
        }

        // Move the Key towards the player
        private async UniTaskVoid MoveTowardsPlayer(Transform playerTransform) {
            while ((transform.position - playerTransform.position).sqrMagnitude >= 0.01f) {
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    playerTransform.position, 
                    moveSpeed * Time.deltaTime);
                
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.TryGetComponent(out Player.Interactor interactor)) {
                interactor.AddKey();
                Destroy(gameObject);
            }
        }
    }
}