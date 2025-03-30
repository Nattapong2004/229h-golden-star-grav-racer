using UnityEngine;

public class RotatingAttractor : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float attractionForce = 10f; 
    public float attractionRadius = 5f; 

    void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

       
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);
        foreach (Collider col in colliders)
        {
            if (col.attachedRigidbody != null && col.gameObject != gameObject)
            {
                
                Vector3 direction = (transform.position - col.transform.position).normalized;
                col.attachedRigidbody.AddForce(direction * attractionForce * Time.deltaTime, ForceMode.Acceleration);
            }
        }
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }
}
