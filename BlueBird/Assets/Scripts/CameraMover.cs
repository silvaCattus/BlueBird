using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _cameraRailWay;

    private Vector3 _newPosition;

    private float _speed = 0.05f;
    private float _yPos;
    private float _xPos;
    private float _newZPos;

    private float _ztargetOffset;

    private void Start()
    {
        _yPos = _cameraRailWay.transform.position.y;
        _xPos = _cameraRailWay.transform.position.x;
        _ztargetOffset = _target.transform.position.z - transform.position.z;
    }

    private void LateUpdate()
    {
        _newPosition = CalculateNewPosition();
        transform.position = Vector3.Lerp(transform.position, _newPosition, _speed);
    }

    private Vector3 CalculateNewPosition()
    {
        _newZPos = _target.transform.position.z - _ztargetOffset;
        return _newPosition = new Vector3(_xPos, _yPos, _newZPos);
    }
}
