using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public AudioClip jumpSound; // Zıplama sesi için AudioClip

    private Rigidbody2D rb;
    private bool isGrounded;
    private AudioSource audioSource; // AudioSource referansı

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // AudioSource bileşenini al
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
    }

    void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Mevcut ses çalınıyorsa durdur
            }
            audioSource.clip = jumpSound; // Zıplama sesini ayarla
            audioSource.Play(); // Sesi çal
        }
    }
}
