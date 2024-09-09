using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Puanın gösterileceği UI Text öğesi
    private int score = 0; // Puan değişkeni

    void Start()
    {
        // Puanı UI'de başlat
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // Puanı artır
        UpdateScoreText(); // UI'de güncelle
    }

    private void UpdateScoreText()
    {
        scoreText.text = "  " + score; // Puanı UI'de göster
    }
}
