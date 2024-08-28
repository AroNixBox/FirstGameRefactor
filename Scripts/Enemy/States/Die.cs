using System.Collections;
using Extensions.FSM;
using UI;
using UnityEngine;

namespace Enemy.States {
    public class Die : IState {
        private readonly References _references;
        
        public Die(References references) {
            _references = references;
        }
        
        public void OnEnter() {
            // TODO: Notify the player, that the enemy is dead, player gives himself a point
            ScoreManager.Instance.AddPoint();
            
            // Play death Anim
            var deathAnim = _references.EnemyType == References.Type.BaseZombie ? 
                References.ANIM_ENEMY_DEATH 
                : References.ANIM_RANGED_ENEMY_DEATH;
            
            _references.PlayAnimation(deathAnim);
            
            // Play death sound
            _references.PlayClip(_references.EnemyType == References.Type.BaseZombie ? 
                _references.BaseZombieDeathSound 
                : _references.RangeZombieDeathSound, false);
            
            _references.StartCoroutine(WaitForClipEnd());
            
            return;
            IEnumerator WaitForClipEnd() {
                var clipLength = _references.GetClipLength();
                yield return new WaitForSeconds(clipLength);
                _references.DestroySelf();
            }
        }
        

        public void Tick() {
            // NO OP
        }

        public void OnExit() {
            // NO OP
        }

        public Color GizmoState() {
            throw new System.NotImplementedException();
        }
    }
}