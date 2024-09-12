using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton; // Start butonunu referans olarak alacağız
    public Button settingsButton; // Settings butonunu referans olarak alacağız

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

        // Settings butonuna işlev ekle
        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(OpenSettings);
        }
        else
        {
            Debug.LogError("Settings Button not assigned in the inspector.");
        }
    }

    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("SampleScene"); // "GameScene" yerine oyunun gerçek sahne adını yazın
    }

    public void OpenSettings()
    {
        // Ayarlar sahnesini yükle
        SceneManager.LoadScene("Settings"); // "SettingsScene" yerine ayarların olduğu sahne adını yazın
    }
}
