using Extensions.FSM;
using UnityEngine;

namespace Enemy.States {
    public class Attack : IState {
        private readonly References _references;
        private System.DateTime _lastCheckTime;
        public Attack(References references) {
            _references = references;
        }
        
        public void OnEnter() {
            _lastCheckTime = System.DateTime.Now;
            
            ExecuteAttack();
        }


        public void Tick() {
            if (!((System.DateTime.Now - _lastCheckTime).TotalSeconds >= _references.TimeTillNewAttack)) {
                return;
            }
            
            _lastCheckTime = System.DateTime.Now;
            
            // No additional check for attack sensor needed
            // this is handled by the state machine

            ExecuteAttack();
        }

        private void ExecuteAttack() {
            switch (_references.EnemyType) {
                case References.Type.BaseZombie:
                    _references.PlayerHealth.TakeDamage(_references.AttackDamage);
                    break;
                case References.Type.RangeZombie:
                    var bullet = _references.SpawnActor(_references.Projectile.gameObject, _references.transform.position, _references.transform.rotation);
                    bullet.GetComponent<Bullet>().Init(_references.PlayerHealth.transform, _references.BulletSpeed);
                    break;
                default:
                    Debug.LogError("Unknown enemy type");
                    break;
            }
        }

        public void OnExit() {
            // NO OP
        }

        public Color GizmoState() {
            throw new System.NotImplementedException();
        }
    }
}