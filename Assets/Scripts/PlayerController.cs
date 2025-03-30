using UnityEngine;

public class PlayController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 20f;      // แรงเคลื่อนที่
    public float turnTorque = 50f;     // แรงบิดสำหรับเลี้ยว
    public float brakeForce = 15f;     // แรงเบรก
    public float maxSpeed = 30f;       // ความเร็วสูงสุด

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;
    private bool isBraking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.down * 0.5f;  // ลดจุดศูนย์ถ่วง
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleSteering();
        HandleBraking();
        LimitSpeed();
        Debug.Log($"Turn Input: {turnInput}");
    }

    void HandleMovement()
    {
        Vector3 force = transform.forward * moveInput * moveForce;
        rb.AddForce(force, ForceMode.Force);
    }

    void HandleSteering()
    {
        // เลี้ยวได้ดีเมื่อรถกำลังเคลื่อนที่
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            float turnMultiplier = Mathf.Clamp01(rb.linearVelocity.magnitude / 5f);
            Vector3 torque = Vector3.up * turnInput * turnTorque * turnMultiplier;
            rb.AddTorque(torque, ForceMode.Force);

        }
    }

    void HandleBraking()
    {
        if (isBraking)
        {
            rb.AddForce(-rb.linearVelocity.normalized * brakeForce, ForceMode.Force);
        }
    }

    void LimitSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
