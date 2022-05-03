using UnityEngine;

namespace StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State _startingState;
        [SerializeField] private State _currentState;

        public State Current
        {
            get { return _currentState; }
        }

        void Start()
        {
            Reset();
        }

        public void Reset()
        {
            Transit(_startingState);
        }

        void Update()
        {
            if (_currentState == null)
                return;

            State next = _currentState.GetNext();
            if (next != null)
                Transit(next);
        }

        void Transit(State next)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = next;
            if (_currentState != null)
                _currentState.Enter();
        }
    }
}