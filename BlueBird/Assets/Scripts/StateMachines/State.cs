using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class State : MonoBehaviour
    {
        [SerializeField, Tooltip("List of transitions from this state.")]
        List<Transition> transitions = new List<Transition>();

        public virtual State GetNext()
        {
            foreach (var transition in transitions)
            {
                if (transition.NeedTransit)
                    return transition.TargetState;
            }

            return null;
        }

        public virtual void Exit()
        {
            if (enabled)
            {
                foreach (var transition in transitions)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }

        public virtual void Enter()
        {
            if (!enabled)
            {
                enabled = true;
                foreach (var transition in transitions)
                {
                    transition.enabled = true;
                }
            }
        }

        protected virtual void FixedUpdate()
        {
        }
    }
}