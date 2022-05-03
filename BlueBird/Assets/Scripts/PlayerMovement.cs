using UnityEngine;
using System;

namespace BlueBird.Inputs
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Inventory))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(10, 150)]
        private float _speed = 50f;
        [SerializeField] private Transform _centerOffMass;
        [SerializeField] GameObject _prefabApple;

        private Inventory _inventory;
        private Animator _animator;
        private Rigidbody _rb;
        private SphereCollider _sphereCollider;
        private Vector3 _movement;

        public bool _isJumping { get; private set; }
        private float _waitingTimer;

        public event Action<GameObject> AppleIsThrown;

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _sphereCollider = GetComponent<SphereCollider>();
            SetLowerCenterOfMass();
        }

        private void FixedUpdate()
        {
            _animator.SetFloat("speed", _rb.velocity.magnitude);

            if (_rb.velocity.magnitude < 0.1f)
                TimerOn();
            else if (_rb.velocity.magnitude > 0.1f)
                ResetTimer();
        }

        private void TimerOn()
        {
            _waitingTimer += Time.deltaTime;
            _animator.SetFloat("timer", _waitingTimer);
        }

        private void ResetTimer()
        {
            _waitingTimer = 0;
            _animator.SetFloat("timer", _waitingTimer);
        }

        public void Move(Vector3 direction)
        {
            _movement = direction * _speed;
            _rb.AddForce(_movement);
        }

        public void SetCentralCenterOffMass()
        {
            _rb.centerOfMass = _sphereCollider.center;
        }

        public void SetLowerCenterOfMass()
        {
            _rb.centerOfMass = _centerOffMass.localPosition;
        }

        //INVOKE FROM "RollEnter" ANIMATION
        public void RollEnter()
        {
            _animator.SetBool("roll", true);
            SetLowerCenterOfMass();        }

        //INVOKE FROM "RollExit" ANIMATION
        public void RollExit()
        {
            _animator.SetBool("roll", false);
            SetLowerCenterOfMass();        }

        public void Jump()
        {
            if (!_isJumping)
            {
                _rb.AddForce(Vector3.up * 56, ForceMode.Impulse);
                _animator.SetBool("jump", true);
                _isJumping = true;
                SetLowerCenterOfMass();
            }
        }

        public void Throw(float force, Vector3 direction, Items itemName)
        {
            if(force < 7)
                force = 7;
            else if(force > 13)
                force = 13;

            if (itemName == Items.Apple)
            {
                var obj = Instantiate(_prefabApple);
                obj.transform.position = transform.position + new Vector3(direction.x, 1, direction.z);
                obj.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
                AppleIsThrown(obj);
            }

            _inventory.UseItem(itemName);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 3 && _isJumping)
            {
                _isJumping = false;
                _animator.SetBool("jump", false);
                SetCentralCenterOffMass();
            }
        }

#if UNITY_EDITOR

        [ContextMenu("Reset values")]
        public void ResetVs()
        {
            _speed = 100f;
        }

#endif
    }
}