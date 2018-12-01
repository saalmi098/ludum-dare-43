using UnityEngine;

public class KnightController : MonoBehaviour {

    Rigidbody2D rb = null;

    // MOVEMENT
    public float moveSpeed;
    private float moveInput;

    // JUMPING
    public float jumpForce;
    public float jumpTime;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private float jumpTimeCounter;
    private bool isJumping;

    // ANIMATION
    public Animator animator;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
       
    }

    void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        FlipDirection();

        rb.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FlipDirection()
    {
        if (moveInput > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpForce);
            animator.SetBool("IsJumping", true);
        }
        //else if (isGrounded)
        //{
        //    animator.SetBool("IsJumping", false);
        //}

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Vector2.up.y * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
            //animator.SetBool("IsJumping", false);
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
