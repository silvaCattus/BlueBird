using UnityEngine;

namespace StateMachine.Boar
{
    public class EatTransition : Transition
    {
        [SerializeField] private EatState _eatState;
        private GameObject _target;

        void Start()
        {
        }

        private void FixedUpdate()
        {                
            if(_target != null)
                CheckDistanceToApple();
        }

        public void SetTarget(GameObject apple)
        {
            _target = apple;

        }

        private void CheckDistanceToApple()
        {
            if (Vector3.Distance(_target.transform.position, transform.position) <= 8f)
            {
                SetNeedTransition();

                _eatState.SetAndStopTarget(_target);

                Debug.Log(NeedTransit);
            }
        }
    }
}