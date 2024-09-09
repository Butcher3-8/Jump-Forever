using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    
    public GameObject stepPrefab; // Oluşturmak istediğiniz step prefab'ı
    public GameObject coinPrefab; // Coin prefab'ınız
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

        // Step prefab'ını oluştur
        GameObject step = Instantiate(stepPrefab, new Vector3(randomX, currentSpawnHeight, 0), Quaternion.identity);

        // Step prefab'ının üstüne coin'leri spawn et
        SpawnCoinsOnStep(step);

        // Yüksekliği artır
        currentSpawnHeight += spawnHeightIncrement;
    }

    void SpawnCoinsOnStep(GameObject step)
    {
        // Step prefab'ının BoxCollider2D bileşenini al
        BoxCollider2D stepCollider = step.GetComponent<BoxCollider2D>();
        if (stepCollider != null)
        {
            Vector2 stepSize = stepCollider.size;
            Vector2 stepCenter = stepCollider.bounds.center;

            // Her step üzerine coin spawn et
            for (int i = 0; i < 1; i++) // Örnek olarak her step üzerine 3 coin
            {
                // Rastgele bir pozisyon oluşturun
                Vector2 randomPosition = new Vector2(
                    Random.Range(stepCenter.x - stepSize.x / 2, stepCenter.x + stepSize.x / 2),
                     stepCenter.y + stepSize.y / 2 + 0.2f // Coin'in step'in üstünden 0.2f yükseklikte spawn edileceği
                );

                // Coin oluşturun ve step'in çocuğu yapın
                GameObject coin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
                coin.transform.parent = step.transform;
            }
        }
    }
}
