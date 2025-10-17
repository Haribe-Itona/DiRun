using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool isGrounded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        if (rb == null) Debug.LogError("Rigidbody2D не найден!");
        if (anim == null) Debug.LogWarning("Animator не найден!");
        if (sprite == null) Debug.LogWarning("SpriteRenderer не найден!");
    }

    void Update()
    {
        // Движение влево/вправо
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Анимации
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
            anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        }

        // Переворот спрайта
        if (sprite != null)
        {
            if (move > 0.1f) sprite.flipX = false;
            else if (move < -0.1f) sprite.flipX = true;
        }
    }

    //Проверка касания с землёй
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
