using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 15f;
    public float jumpForce = 20f;
    public bool run = false;
    public bool isJump = false;
    public float move;
    float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    public bool isGrounded = false;

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

        anim.SetFloat("Speed", Mathf.Abs(move * speed));
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        
        // Переворот спрайта

        if (move > 0.1f) sprite.flipX = false;
        else if (move < -0.1f) sprite.flipX = true;
        
    }

    public float jumpTime = 50;
    float timeOfJump;

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isJump = true;
            timeOfJump = 0;
            isGrounded = false;
        }
    }
    public void HoldJump()
    {

        if (isJump)
        {
            rb.AddForce(new Vector2(0, jumpForce * (jumpTime - timeOfJump / jumpTime)));
            timeOfJump += 1f;
        }
        if( timeOfJump >= jumpTime) { isJump = false; }
    }
    public void Move()
    {
        speed = run ? runSpeed : walkSpeed;

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }


    //Проверка касания с землёй
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    */

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
