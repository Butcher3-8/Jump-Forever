using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Ses kaynağını atayın

    private void Start()
    {
        // Buton bileşenini al
        Button button = GetComponent<Button>();
        
        // Butona tıklama işlevi ekleyin
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    private void PlayClickSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Ses çal
        }
    }
}
