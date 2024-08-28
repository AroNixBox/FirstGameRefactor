using Extensions.FSM;
using UnityEngine;

namespace Enemy.States {
    public class Walk : IState{
        private readonly References _references;
        private Vector3 _directionToPlayer;
        private float _angleToPlayer;
        
        public Walk(References references) {
            _references = references;
        }
        public void OnEnter() {
            // NO OP
        }

        public void Tick() {
            // Cache values
            var playerPosition = _references.PlayerHealth.transform.position;
            var selfPosition = _references.transform.position;

            // Move
            var directionToPlayer = (playerPosition - selfPosition).normalized;
            var targetPosition = playerPosition - directionToPlayer * _references.DistanceToPlayer;
            _references.MoveTowards(targetPosition, _references.MoveSpeed);
            
            // Rotate
            _angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x);
            _references.SetRotation(_angleToPlayer * Mathf.Rad2Deg); 
        }

        public void OnExit() {
            // NO OP
        }

        public Color GizmoState() {
            throw new System.NotImplementedException();
        }
    }
}