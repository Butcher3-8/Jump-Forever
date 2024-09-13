using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public Button soundButton; // Ses butonu
    public Sprite soundOnIcon; // Ses açık ikonu
    public Sprite soundOffIcon; // Ses kapalı ikonu
    public AudioSource clickSound; // Tıklama sesi için AudioSource

    private bool isSoundOn = true; // Sesin açık olup olmadığını belirten durum

    void Start()
    {
        // Ses butonuna işlev ekle
        soundButton.onClick.AddListener(OnSoundButtonClick);

        // Sesin mevcut durumuna göre butonun ikonunu ayarla
        UpdateSoundButtonIcon();
    }

    void OnSoundButtonClick()
    {
        // Tıklama sesini çal
        if (clickSound != null)
        {
            clickSound.Play();
        }

        // Ses açma/kapama işlevini çağır
        ToggleSound();
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn; // Ses durumunu değiştir
        UpdateAudioSources(); // Sesleri aç/kapat
        UpdateSoundButtonIcon(); // Buton ikonunu güncelle
    }

    void UpdateAudioSources()
    {
        // Bu scriptte seslerin yönetilmesi gerekiyorsa, örneğin:
        // foreach (AudioSource audioSource in audioSources)
        // {
        //     audioSource.mute = !isSoundOn; // Sesin durumuna göre mute ayarla
        // }
    }

    void UpdateSoundButtonIcon()
    {
        // Butonun mevcut durumuna göre ikonunu değiştir
        Image buttonImage = soundButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = isSoundOn ? soundOnIcon : soundOffIcon;
        }
    }

    public void OnBackButtonClick()
    {
        // "MainMenu" isimli sahneyi yükle
        SceneManager.LoadScene("MainMenu");
    }
}
