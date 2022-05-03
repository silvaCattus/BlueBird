using UnityEngine;

namespace StateMachine.Boar
{
    public class SleepState : State
    {
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetTrigger("LieDown");
            GetComponent<GameOverTrigger>().enabled = false;
        }
    }
}