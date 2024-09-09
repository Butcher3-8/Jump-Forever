using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int scoreValue = 5; // Coin toplandığında eklenecek puan

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ScoreManager'i bul ve puanı artır
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue);
            }

            // Coin yok olmalı
            Destroy(gameObject);
        }
    }
}
