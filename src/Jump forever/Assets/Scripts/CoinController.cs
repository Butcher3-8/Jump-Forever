using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer çarpışan nesne player ise (Player tag'ı ile kontrol edebilirsiniz)
        if (other.CompareTag("Player"))
        {
            // Coin yok olmalı
            Destroy(gameObject);
        }
    }
}
