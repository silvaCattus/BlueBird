using UnityEngine;

namespace BlueBird.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private FinishTrigger _finish;
        [Range(0, 4)] private float _throwForce;

        private PlayerMovement _playerMovement;
        private Vector3 _movement;
        private Vector3 _mousePosition;
        private Inventory _inventory;
        private Items _throwingItem;

        private bool _isJumpButtonDown;
        private bool _isGettingInputs;
        private bool _needImpulse;
        private bool _timerOn;

        private void Start()
        {
            _inventory = GetComponent<Inventory>();
            _playerMovement = GetComponent<PlayerMovement>();
            _finish.Finished += StopGetInputValues;
            _isGettingInputs = true;
        }

        private void Update()
        {
            if (_isGettingInputs)
            {
                var hor = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
                var vert = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

                _movement = new Vector3(hor, 0, vert).normalized;

                if (Input.GetButtonDown(GlobalStringVars.JUMP))
                    _isJumpButtonDown = true;

                if (_timerOn)
                    ClickTimerOn();

                if (Input.GetButtonDown(GlobalStringVars.FIRE) && CheckInventory())
                    _timerOn = true;
                else if (Input.GetButtonUp(GlobalStringVars.FIRE) && _timerOn)
                {
                    _timerOn = false;
                    _needImpulse = true;
                    _mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                }
            }
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_movement);

            if (_isJumpButtonDown)
            {
                _isJumpButtonDown = false;
                _playerMovement.Jump();
            }

            if(_needImpulse == true)
            {
                SendImpulseToPlayerMovement();
                _needImpulse = false;
                _throwForce = 0;
            }
        }

        private void SendImpulseToPlayerMovement()
        {
            _throwForce *= 40;

            var transformInViewportPoint = Camera.main.WorldToViewportPoint(transform.position);
            var dir = new Vector3(_mousePosition.x - transformInViewportPoint.x, 0, _mousePosition.y - transformInViewportPoint.y);
            dir.Normalize();
            dir.y = 0.5f;
            _playerMovement.Throw(_throwForce, dir, _throwingItem);
        }

        private void ClickTimerOn()
        {
            _throwForce += Time.deltaTime;
        }

        private bool CheckInventory()
        {
            _throwingItem = _inventory._activeToolName;
            _inventory.InventoryDict.TryGetValue(_inventory._activeToolName, out int number);
            if (number > 0 && _inventory.ActiveToolIsThrowable)
                return true;

            return false;
        }

        private void StopGetInputValues()
        {
            _isGettingInputs = false;
        }

        private void OnDisable()
        {
            _finish.Finished -= StopGetInputValues;
        }
    }
}
