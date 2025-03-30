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
            "1.ID 1660700749 Nattavut Boontham Section 229H No.3 " +

            "(Create maps, decorate maps and game credits)" +

            "2.ID 1660706241 Nattapong Buphu Section 229H No.18 " +

            "(Make scripts and UI)" +


            "Assets : Free 3D Models  " +
           
            "Thankyou";
    }
}
