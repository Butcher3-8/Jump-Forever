using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gamePausePanel; // Game Pause Panel
    public Button pauseButton; // Pause Button
    public Button resumeButton; // Resume Button
    public Button restartButton; // Restart Button
    public Button mainMenuButton; // Ana Menü Butonu

    private bool isPaused = false;

    void Start()
    {
        // Başlangıçta paneli kapalı yap
        gamePausePanel.SetActive(false);

        // Butonlara işlev ekle
  
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu); // Ana menü butonuna işlev ekle
    }

    void Update()
    {
        // İsteğe bağlı olarak, Escape tuşuna basıldığında duraklatma işlemi yapabilirsiniz
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Oyunu duraklat
        Time.timeScale = 0f;
        gamePausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false); // Duraklatma menüsünü gösterirken butonu gizle
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;
        gamePausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true); // Duraklatma menüsü kapatıldığında butonu tekrar göster
        isPaused = false;
    }

    public void RestartGame()
    {
        // Oyunu yeniden başlat
        Time.timeScale = 1f; // Oyunun hızını geri getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
    }

    public void GoToMainMenu()
    {
        // Ana menüye git
        Time.timeScale = 1f; // Oyun zamanını geri getir
        SceneManager.LoadScene("MainMenu"); // MainMenu sahnesini yükle
    }
}
