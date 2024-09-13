using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public Button character1SelectButton;
    public Button character2SelectButton;
    public Button character3SelectButton;
    public Button startButton;
    public Button backButton;

    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    private GameObject selectedCharacter;
    private GameObject[] characterButtons;

    void Start()
    {
        // Başlangıçta "Start" ve "Back" butonlarını gizle
        startButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        // Karakter butonlarına işlev ekleyin
        character1SelectButton.onClick.AddListener(() => SelectCharacter(character1));
        character2SelectButton.onClick.AddListener(() => SelectCharacter(character2));
        character3SelectButton.onClick.AddListener(() => SelectCharacter(character3));
        startButton.onClick.AddListener(StartGame);
        backButton.onClick.AddListener(GoBack);

        // Karakter butonlarını bir diziye alın
        characterButtons = new GameObject[] { character1SelectButton.gameObject, character2SelectButton.gameObject, character3SelectButton.gameObject };
    }

    void SelectCharacter(GameObject character)
    {
        selectedCharacter = character;

        // Seçilen karaktere göre butonları güncelle
        foreach (var button in characterButtons)
        {
            button.SetActive(false); // Seçim yapıldığında tüm karakter butonlarını gizle
        }
        startButton.gameObject.SetActive(true); // "Start" butonunu göster
        backButton.gameObject.SetActive(true); // "Back" butonunu göster
    }

    void StartGame()
    {
        if (selectedCharacter != null)
        {
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacter.name); // Seçilen karakteri kaydet
            SceneManager.LoadScene("SampleScene"); // Oyun sahnesine geçiş yap
        }
    }

    void GoBack()
    {
        // Seçilen karakteri sıfırla
        selectedCharacter = null;

        // "Start" ve "Back" butonlarını gizle
        startButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        // Karakter seçim butonlarını geri getir
        foreach (var button in characterButtons)
        {
            button.SetActive(true);
        }
    }
}
