using UnityEngine;

namespace StateMachine.Dog
{
    public class SleepingState : State
    {
        [SerializeField] private Dog _dog;

        void Start()
        {
        }

        private void OnEnable()
        {
            _dog.Animator.SetBool("Sleep", true);
            _dog.SetIsSleeping();
        }

        private void OnDisable()
        {
            _dog.Animator.SetBool("Sleep", false);
            _dog.SetIsSleeping();
        }
    }
}