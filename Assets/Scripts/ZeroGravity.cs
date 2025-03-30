using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb) rb.useGravity = false;
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb) rb.useGravity = true;
    }
}