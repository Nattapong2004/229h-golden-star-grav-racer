using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    public float gravityMultiplier = 0.1f; 
    public float floatDrag = 0.5f;        
    public bool randomRotation = true;     


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (!rb.gameObject.GetComponent<GravityMemory>())
            {
                rb.gameObject.AddComponent<GravityMemory>();
            }

           
            rb.useGravity = false;
            rb.linearDamping = floatDrag;
            rb.angularDamping = floatDrag * 0.5f;

            if (randomRotation)
            {
                rb.AddTorque(new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f)),
                    ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            GravityMemory memory = rb.GetComponent<GravityMemory>();
            if (memory)
            {
                rb.useGravity = memory.originalUseGravity;
                rb.linearDamping = memory.originalDrag;
                rb.angularDamping = memory.originalAngularDrag;
                Destroy(memory);
            }
        }
    }
}

public class GravityMemory : MonoBehaviour
{
    public bool originalUseGravity;
    public float originalDrag;
    public float originalAngularDrag;

    void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        originalUseGravity = rb.useGravity;
        originalDrag = rb.linearDamping;
        originalAngularDrag = rb.angularDamping;
    }
}
