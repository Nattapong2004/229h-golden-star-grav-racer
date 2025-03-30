using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Text creditsText; // ลาก CreditsText มาใส่ใน Inspector

    void Start()
    {
        // ตั้งค่าข้อความ Credit
        creditsText.text =
            "ทีมพัฒนาเกม:\n\n" +
            "1. รหัส 12345 ชื่อ-นามสกุล Section 01 เลขที่ 1 - โปรแกรมเมอร์\n" +
            "2. รหัส 67890 ชื่อ-นามสกุล Section 01 เลขที่ 2 - ออกแบบเกม\n" +
            "3. รหัส 54321 ชื่อ-นามสกุล Section 01 เลขที่ 3 - ทดสอบเกม\n\n" +
            "Assets ที่ใช้:\n" +
            "- เสียงจาก FreeSound.org\n" +
            "- ภาพจาก Unity Asset Store\n\n" +
            "ขอบคุณที่เล่นเกมของเรา!";
    }
}
