using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    public float destroyDelay = 0.1f; // Zıplama sonrası yok olma gecikmesi

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer karakter prefab'a zıplarsa, prefab'ı yok et
        if (collision.gameObject.CompareTag("Player"))
        {
            // Zıplama sonrası bir gecikme ile prefab'ı yok et
            Destroy(gameObject, destroyDelay);
        }
    }
}