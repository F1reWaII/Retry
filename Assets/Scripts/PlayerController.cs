using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public static bool dubleJump = false;

    private bool isGrounded;

    public int jumpAmount = 0;

    public Collider2D PointCheck;

    public LayerMask GroundLayer;
    
    public GameObject Monster;

    public VideoPlayer videoPlayer;
    
    // Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update
    private void Update()
    {
        Control();
    }

    // OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded(collision);
        if (collision.gameObject == Monster)
        {
            AfterDead();
        }
    }

    // Control
    private void Control()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        DubleJump();
    }

    private void IsGrounded(Collision2D collision)
    {
        if (PointCheck.IsTouchingLayers(GroundLayer))
        {
            isGrounded = true;
        }
        if (PointCheck.IsTouchingLayers(GroundLayer))
        {
            if (jumpAmount < 2 && dubleJump)
            {
                isGrounded = true;
            }
        }
    }

    private void DubleJump()
    {
        if (dubleJump == false)
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
                isGrounded = false;
            }
        }

        if (dubleJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpAmount <= 1 && isGrounded)
            {
                rb.velocity = (Vector2.up * 0);
                rb.AddForce(Vector2.up * jumpForce);
                jumpAmount = jumpAmount + 1;
            }
        }

        if (jumpAmount > 1)
        {
            jumpAmount = 0;
            isGrounded = false;
        }
    }
    private void AfterDead()
    {
        videoPlayer.Play();
    }

}
