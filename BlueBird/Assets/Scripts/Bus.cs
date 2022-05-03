using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bus : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finish;
    [SerializeField] private Transform _targetPoint;

    private Rigidbody _rb;
    private float _speed = 5f;
    private bool _isMoving;

    private void Start()
    {
        _finish.Finished += SetIsMoving;
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            MoveToBusStation();

        if (Vector3.Distance(_targetPoint.position, transform.position) < 1.5f)
            _speed /= 1.5f;

        if (Vector3.Distance(_targetPoint.position, transform.position) < 0.2f)
            _isMoving = false;
    }

    private void SetIsMoving()
    {
        _isMoving = true;
    }

    private void MoveToBusStation()
    {
        transform.LookAt(_targetPoint);
        _rb.AddForce(Vector3.forward * _speed);
    }

    private void OnDisable()
    {
        _finish.Finished -= SetIsMoving;
    }
}
