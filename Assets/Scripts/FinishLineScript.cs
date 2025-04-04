using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameObject exitButtonUI; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            exitButtonUI.SetActive(true); 
            Time.timeScale = 0f; 
        }
    }

    
    public void LoadNextScene()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Credits"); 
    }
}