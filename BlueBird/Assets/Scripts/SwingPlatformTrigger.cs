using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwingPlatformTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 _centerOfMass;
    public event Action<Vector3> _onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _onTriggerEnter != null)
            _onTriggerEnter(_centerOfMass);
    }
}
