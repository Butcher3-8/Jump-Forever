using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float bounceForce = 10f; // Zıplama gücü
    public Color specialColor = Color.green; // Özel renk
    public bool isSpecialPlatform = false; // Özel platform olup olmadığını belirler

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (isSpecialPlatform && spriteRenderer != null)
        {
            // Özel platform ise, rengini değiştir
            spriteRenderer.color = specialColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Karaktere zıplama gücü uygula
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(0f, bounceForce), ForceMode2D.Impulse);
            }
        }
    }
}
