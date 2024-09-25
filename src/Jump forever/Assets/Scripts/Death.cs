using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform player; // Oyuncunun transform'u
    public GameObject gameOverPanel; // GameOver paneli
    public GameObject pauseButton; // Duraklatma butonu
    public GameObject scoreText; // Skor metni
    private bool isGameOver = false;

    void Update()
    {
        // Oyuncunun Y pozisyonunu kontrol et
        if (player.position.y < -10 && !isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true; // Oyunun bittiğini işaretle
        gameOverPanel.SetActive(true); // GameOver panelini göster
        pauseButton.SetActive(false); // Duraklatma butonunu gizle
        scoreText.SetActive(false); // Skor metnini gizle
        Time.timeScale = 0; // Oyunu durdur
    }
}
