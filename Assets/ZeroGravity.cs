using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    [Header("การตั้งค่า")]
    public float gravityMultiplier = 0.1f; // ค่าความแรงโน้มถ่วง (0 = ไร้น้ำหนัก)
    public float floatDrag = 0.5f;        // แรงต้านในพื้นที่
    public bool randomRotation = true;     // ให้วัตถุหมุนแบบสุ่มหรือไม่

    [Header("เอฟเฟกต์")]
    public ParticleSystem floatingParticles;
    public AudioClip zeroGSound;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // เก็บค่าเดิมไว้คืนค่าเมื่อออกจากโซน
            if (!rb.gameObject.GetComponent<GravityMemory>())
            {
                rb.gameObject.AddComponent<GravityMemory>();
            }

            // ตั้งค่าฟิสิกส์ใหม่
            rb.useGravity = false;
            rb.linearDamping = floatDrag;
            rb.angularDamping = floatDrag * 0.5f;

            // เพิ่มเอฟเฟกต์
            if (floatingParticles) Instantiate(floatingParticles, other.transform.position, Quaternion.identity);
            if (zeroGSound) AudioSource.PlayClipAtPoint(zeroGSound, transform.position);

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
                // คืนค่าฟิสิกส์เดิม
                rb.useGravity = memory.originalUseGravity;
                rb.linearDamping = memory.originalDrag;
                rb.angularDamping = memory.originalAngularDrag;
                Destroy(memory);
            }
        }
    }
}

// สคริปต์สำหรับจำค่าตั้งต้น
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
