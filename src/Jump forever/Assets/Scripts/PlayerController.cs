using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;   // Karakterin yatay hareket hızı
    public float jumpForce = 10f; // Zıplama kuvveti
    public Transform groundCheck; // Zemin kontrolü için bir referans
    public float groundCheckRadius = 0.2f; // Zemin kontrolü için yarıçap
    public LayerMask groundLayer; // Zemin katmanı

    private Rigidbody2D rb; // Karakterin Rigidbody2D bileşeni
    private bool isGrounded; // Karakterin zeminde olup olmadığını kontrol eder

    void Start()
    {
        // Rigidbody2D bileşenini al
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Zemin kontrolü: groundCheck pozisyonundaki bir çember ile zemin katmanını kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Yatay hareket
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Zıplama
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Karakterin rotasını kontrol et
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Sağ yön (0 derece)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            // Sol yön (180 derece)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Zeminle temas edildiğinde ve ayrıldığında
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
