using UnityEngine;

public class WaterPusherOut : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * 20f);
        }
    }
}
