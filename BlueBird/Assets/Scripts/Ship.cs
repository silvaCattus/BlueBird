using UnityEngine;

public class Ship : MonoBehaviour
{
    private float _speed = 0.3f;

    void FixedUpdate()
    {
       Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce((other.transform.position - transform.position).normalized * 400f, ForceMode.Impulse);
        }
    }
}