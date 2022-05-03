using UnityEngine;

namespace StateMachine.Dog
{
    public class WatchdogState : State
    {
        [SerializeField] private Transform[] _distinationsPoint;
        [SerializeField] private string[] _animParamsForRandomPlay;
        [SerializeField] private Dog _dog;

        private System.Random _rand;
        private Vector3 _targetPos;

        private float _speed = 0.15f;
        private int _distinationsNumber;
        private int _animParamsNumber;
        private int _playingAnim;
        private bool _isMoving;

        private void Start()
        {
            _rand = new System.Random();
            _distinationsNumber = _distinationsPoint.Length;
            _animParamsNumber = _animParamsForRandomPlay.Length;
        }

        protected override void FixedUpdate()
        {
            if (_isMoving)
            {
                Move();

                if (Vector3.Distance(transform.position, _targetPos) < 1)
                    SetDistination();
            }
        }

        //ÂÛÇÛÂÀÅÒÑß ÂÊÎÍÖÅ ÀÍÈÌÀÖÈÈ "Idle"
        public void PlayRandomAnimation()
        {
            _playingAnim = _rand.Next(0, _animParamsNumber);
            if (_animParamsForRandomPlay[_playingAnim] != null)
            {
                _dog.Animator.SetBool(_animParamsForRandomPlay[_playingAnim].ToString(), true);
                Invoke(nameof(StopPlayingRandomAnimation), 6f);
            }
        }

        public void StopPlayingRandomAnimation()
        {
            _dog.Animator.SetBool(_animParamsForRandomPlay[_playingAnim].ToString(), false);
        }

        //ÂÛÇÛÂÀÅÒÑß ÂÍÀ×ÀËÅ ÀÍÈÌÀÖÈÈ "Go walk"
        //È ÂÊÎÍÖÅ ÀÍÈÌÀÖÈÈ "Stop walk"
        public void SetIsMoving()
        {
            SetDistination();
            _isMoving = !_isMoving;
        }

        private void SetDistination()
        {
            var num = _rand.Next(0, _distinationsNumber);
            _targetPos = _distinationsPoint[num].position;
        }

        private void Move()
        {
            _dog.DogParentObj.transform.LookAt(_targetPos);

            var movement = _dog.DogParentObj.transform.TransformDirection(0, 0, 1);
            movement *= _speed;
            _dog.Controller.Move(movement);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _dog.BoolAnimationNumber; i++)
            {
                _dog.Animator.SetBool(_dog.BoolAnimParameters[i].name, false);
            }
            _isMoving = false;
        }
    }
}
