using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // Oluşturmak istediğiniz prefab
    public float minX; // X ekseninde minimum pozisyon
    public float maxX; // X ekseninde maksimum pozisyon
    public float initialSpawnHeight; // İlk oluşturulma yüksekliği
    public float spawnHeightIncrement = 1f; // Her yeni prefab'ın yükseklik artışı
    public float spawnInterval = 2f; // Prefab'ların oluşturulma aralığı

    private float currentSpawnHeight; // Mevcut yüksekliği takip eder
    private float timer;

    void Start()
    {
        currentSpawnHeight = initialSpawnHeight;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0f;
        }
    }

    void SpawnPrefab()
    {
        // Rastgele X pozisyonunu hesapla
        float randomX = Random.Range(minX, maxX);

        // Prefab'ı oluştur
        Instantiate(prefab, new Vector3(randomX, currentSpawnHeight, 0), Quaternion.identity);

        // Yüksekliği artır
        currentSpawnHeight += spawnHeightIncrement;
    }
}
