using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public GameObject gameOverPanel; // Game Over Paneli
    public LayerMask groundLayer;
    public AudioClip jumpSound; // Zıplama sesi için AudioClip


    private Rigidbody2D rb;
    private bool isGrounded;
    private AudioSource audioSource; // AudioSource referansı
    private float previousYPosition;
    private float fallCheckTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // AudioSource bileşenini al

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Başlangıçta mevcut y pozisyonunu kaydet
        previousYPosition = transform.position.y;
      
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Yatay hareket
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Zıplama
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJumpSound(); // Zıplama sesi çal
        }

      



 

    void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound); // Zıplama sesini oynat
        }
    }
}

}
