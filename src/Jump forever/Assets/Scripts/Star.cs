using UnityEngine;

public class StartPointController : MonoBehaviour
{
    public GameObject startPoint; // Kaybolacak başlangıç noktası

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer çarpılan obje "Ground" tag'ine sahipse
        if (collision.CompareTag("Ground"))
        {
            // Başlangıç noktasını kaybet
            if (startPoint != null)
            {
                startPoint.SetActive(false);
            }
        }
    }
}