using System.Collections; // IEnumerator ve Coroutine için gerekli
using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    public float destroyDelay = 2f; // Yok olma gecikmesi
    public Color flashColor = Color.red; // Kırmızı renk
    public float flashDuration = 0.2f; // Kırmızı renkte kalma süresi

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;

    private void Start()
    {
        // SpriteRenderer bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Orijinal rengi kaydet
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer karakter prefab'a zıplarsa, renk değişimini başlat
        if (collision.gameObject.CompareTag("Player") && !isFlashing)
        {
            StartCoroutine(FlashAndDestroy());
        }
    }

    private IEnumerator FlashAndDestroy()
    {
        isFlashing = true;

        // Renk değişimini başlat
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
        }

        // Kırmızı renk ile belirtilen süre boyunca kal
        yield return new WaitForSeconds(flashDuration);

        // Orijinal renge geri dön
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }

        // Belirtilen gecikme süresi sonunda yok ol
        yield return new WaitForSeconds(destroyDelay - flashDuration);

        Destroy(gameObject);
    }
}
