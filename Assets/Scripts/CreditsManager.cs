using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public TextMeshProUGUI creditsText; // ลาก CreditsText มาใส่ใน Inspector

    void Start()
    {
        // ตั้งค่าข้อความ Credit
        creditsText.text =
            "1.ID 1660706241 Nattapong Buphu Section 229H No.18" +
            "()"+
            "2. รหัส 67890 ชื่อ-นามสกุล Section 01 เลขที่ 2 - ออกแบบเกม\n" +
            
            "Assets : " +
           
            "Tankyou";
    }
}
