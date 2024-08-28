using System;
using Extensions.FSM;
using UnityEngine;

namespace Enemy.States {
    public class Hurt : IState {
        private References _references;
        // Placeholder because this state doesn't have any logic
        private bool _stateLogicFinished;
        public Hurt (References references) {
            _references = references;
        }
        public void OnEnter() {
            // Could add a hurt animation here/ Sound - None available
            _stateLogicFinished = true;
        }

        public void Tick() {
            
        }

        public void OnExit() {
            _stateLogicFinished = false;
        }
        
        public Boolean StateLogicFinished() {
            return _stateLogicFinished;
        }

        public Color GizmoState() {
            throw new System.NotImplementedException();
        }
    }
}