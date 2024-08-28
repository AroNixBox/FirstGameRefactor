using System.Collections.Generic;
using Extensions.FSM;
using UnityEngine;

namespace Enemy.States {
    public class Patrol : IState {
        private bool _isWaiting;
        private float _currentWaitTime;
        private readonly References _references;
        private int _currentWaypointIndex;
        private readonly List<Transform> _waypoints = new ();
        private readonly float _distanceToWaypointThreshold = 0.1f;

        public Patrol(References references) {
            _references = references;
            
            // Put all waypoints (childs from the parent) into the list
            foreach (Transform child in _references.WaypointsParent) {
                _waypoints.Add(child);
            }
            
            if(_waypoints.Count == 0) {
                Debug.LogError("No waypoints found for this enemy: " + _references.name, _references.gameObject);
            }
            
            // Because the parent of the waypoints is childed to the enemy, we need to unparent it
            // So the waypoints are not moving with the enemy
            _references.WaypointsParent.SetParent(null);
        }
        
        public void OnEnter() {
            _isWaiting = false;
        }

        public void Tick() {
            if (_isWaiting) {
                if (_currentWaitTime > 0) {
                    _currentWaitTime -= Time.deltaTime;
                    return;
                } else {
                    _isWaiting = false;
                }
            }

            if ((_references.transform.position - _waypoints[_currentWaypointIndex].position).sqrMagnitude < _distanceToWaypointThreshold) {
                _isWaiting = true;
                _currentWaitTime = _references.PatrolWaitTime;
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
                return;
            }

            var nextPatrolPointPosition = _waypoints[_currentWaypointIndex].position;
            // Move to the next waypoint as long as we haven't reached it
            _references.MoveTowards(nextPatrolPointPosition, _references.MoveSpeed);

            var selfPosition = _references.transform.position;
            var directionToNextPatrolPoint = (nextPatrolPointPosition - selfPosition).normalized;
            // Rotate
            var angleToPlayer = Mathf.Atan2(directionToNextPatrolPoint.y, directionToNextPatrolPoint.x);
            _references.SetRotation(angleToPlayer * Mathf.Rad2Deg);
        }

        public void OnExit() {
            // NO OP
        }

        public Color GizmoState() {
            throw new System.NotImplementedException();
        }
    }
}