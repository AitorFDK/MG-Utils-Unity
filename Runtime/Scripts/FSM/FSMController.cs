using System;
using System.Collections.Generic;
using UnityEngine;

namespace MendiGames.Utils.FSM
{
    public class FSMController<T> : MonoBehaviour where T : Enum
    {
         protected Dictionary<T, FSMState<T>> states;
        protected FSMState<T> currentState;

        public FSMController()
        {
            states = new Dictionary<T, FSMState<T>>();
        }

        public FSMState<T> GetState(T stateId)
        {
            return states.ContainsKey(stateId) ? states[stateId] : null;
        }
        
        public void SetCurrentState(FSMState<T> state)
        {
            currentState?.Exit();
            currentState = state;
            currentState?.Enter();
        }


        public void Add(FSMState<T> state)
        {
            states.Add(state.id, state);
        }

        public void Add(T stateId, FSMState<T> state)
        {
            states.Add(stateId, state);
        }


        void Update()
        {
            currentState?.Update();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }
    }
}