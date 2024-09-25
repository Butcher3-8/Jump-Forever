using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Çarpılan Nesne: " + other.gameObject.name); // Çarpılan nesnenin adını göster

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin'e çarptı!");
            GameObject startGround = GameObject.FindGameObjectWithTag("Start");
            if (startGround != null)
            {
                Destroy(startGround);
                Debug.Log("Zemin yok edildi!");
            }
        }
    }
}
    