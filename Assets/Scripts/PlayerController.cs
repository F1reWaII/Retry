using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    VideoPlayer videoPlayer;

    public float speed;
    public float jumpForce;

    public int jumpAmount = 0;

    public static bool dubleJump = false;

    private bool isGrounded;


    public Collider2D PointCheck;

    public LayerMask GroundLayer;
    
    public GameObject Monster;


    private Animator _animator;

    private bool _facingRight = true;
    
    // Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        videoPlayer= GetComponent<VideoPlayer>();
    }

    // Update
    private void Update()
    {
        Control();
    }

    // OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
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

        if(_facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (_facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if(moveInput != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else if(moveInput == 0)
        {
            _animator.SetBool("isWalking", false);
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
        
        Invoke(nameof(ReloadScene), 3);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
