using System;
using Enemy.States;
using UnityEngine;
using Extensions.FSM;
using TMPro;

namespace Enemy {
    public class Brain : MonoBehaviour {
        [SerializeField] private TMP_Text debugText;
        
        private string _lastStateName;
        private StateMachine _stateMachine;
        private References _references;

        private void Awake() {
            _references = GetComponent<References>();
        }

        private void Start() {
            #if !UNITY_EDITOR
            if (debugText != null) {
                Destroy(debugText.gameObject);
            }
            #endif
            
            _stateMachine = new StateMachine();
            
            // Short version of Statemachine Methods:
            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            void Any(IState to, Func<bool> condition) => _stateMachine.AddAnyTransition (to, condition);
            
            var patrol = new Patrol(_references);
            var attack = new Attack(_references);
            var hurt = new Hurt(_references);
            var die = new Die(_references);
            var walk = new Walk(_references);
            
            At(patrol, walk, () => _references.WakeUpSensor.Triggered());
            At(patrol, hurt, () => _references.Health.HasHealthChanged());

            At(walk, attack, () => _references.AttackSensor.Triggered());
            At(walk, hurt, () => _references.Health.HasHealthChanged());
            
            At(attack, hurt, () => _references.Health.HasHealthChanged());
            At(attack, walk, () => !_references.AttackSensor.Triggered());
            
            At(hurt, walk, () => hurt.StateLogicFinished() && !_references.AttackSensor.Triggered());
            At(hurt, attack, () => hurt.StateLogicFinished() && _references.AttackSensor.Triggered());
            
            Any(die, () => _references.Health.IsDead());
            
            // Start the state machine
            _stateMachine.SetState(patrol);
        }
        
        private void Update() {
            _stateMachine.Tick();
            
            // Debug SM
            if(!debugText) { return; }
            var currentStateName = _stateMachine.GetCurrentStateName();
            if (currentStateName == _lastStateName) { return; }

            debugText.text = currentStateName;
            _lastStateName = currentStateName;
        }
    }
}
