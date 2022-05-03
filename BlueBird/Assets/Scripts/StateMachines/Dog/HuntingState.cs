using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Dog
{
    public class HuntingState : State
    {
        [SerializeField] private Dog _dog;
        private float _speed = 0.5f;

        void Start()
        {
        }

        private void OnEnable()
        {
            _dog.Animator.SetBool("Run", true);
        }

        protected override void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _dog.DogParentObj.transform.LookAt(_dog.Target.transform);

            var movement = _dog.DogParentObj.transform.TransformDirection(0, 0, 1);
            movement *= _speed;
            _dog.Controller.Move(movement);
        }

        private void OnDisable()
        {
            _dog.Animator.SetBool("Run", false);
        }
    }
}