using UnityEngine;
using BlueBird.Inputs;

namespace StateMachine.Boar
{
    public class RunState : State
    {
        [SerializeField] private Boar _boar;
        [SerializeField] private EatTransition _eatTransition;
        private GameObject _target;
        private float _speed = 20f;
        private bool _isMoving;

        private void Start()
        {
            _boar = GetComponent<Boar>();
            _boar.Agent.speed = _speed;
            _target = _boar.Target;
            Invoke(nameof(SetIsMoving), 5.5f);
            Invoke(nameof(SetRunAnimation), 5.5f);
        }

        private void FixedUpdate()
        {
            if(_isMoving)
                Move();
        }

        private void Move()
        {
            transform.LookAt(_target.transform);
            _boar.Agent.SetDestination(_target.transform.position);
        }

        private void SetRunAnimation()
        {
            _boar.Animator.SetBool("Run", true);
        }

        private void SetIsMoving()
        {
            _isMoving = !_isMoving;
        }
    }
}
