using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject character1Prefab;
    public GameObject character2Prefab;
    public GameObject character3Prefab;

    private GameObject selectedCharacterPrefab;

    void Start()
    {
        // Seçilen karakteri PlayerPrefs'ten al
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", "Character1");

        // Seçilen karakter prefabını belirle
        switch (selectedCharacterName)
        {
            case "Character1":
                selectedCharacterPrefab = character1Prefab;
                break;
            case "Character2":
                selectedCharacterPrefab = character2Prefab;
                break;
            case "Character3":
                selectedCharacterPrefab = character3Prefab;
                break;
            default:
                selectedCharacterPrefab = character1Prefab;
                break;
        }

        // Seçilen karakteri oyun sahnesine ekle
        if (selectedCharacterPrefab != null)
        {
            Instantiate(selectedCharacterPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
