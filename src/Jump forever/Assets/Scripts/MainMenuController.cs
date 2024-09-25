using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton; // Start butonunu referans olarak alacağız

    void Start()
    {
        // Start butonuna işlev ekle
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }   
        else
        {
            Debug.LogError("Start Button not assigned in the inspector.");
        }
    } // Burada eksik olan } eklendi

    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("SampleScene"); // "SampleScene" yerine oyunun gerçek sahne adını yazın
    }
}
