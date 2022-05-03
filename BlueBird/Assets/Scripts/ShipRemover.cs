using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ship"))
            Destroy(other.gameObject);
    }
}
