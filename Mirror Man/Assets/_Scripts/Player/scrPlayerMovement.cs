using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerMovement : MonoBehaviour
{
    //Variables for Movement and direction
    [SerializeField]
    private int jumplimit;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private bool grounded = false;
    private int extraJumps;
    //Variables for collision detection
    public Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask ground;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    //Animation
    [SerializeField]
    private Sprite idle;
    [SerializeField]
    private Sprite run;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = jumplimit;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (rb.velocity.x != 0 && spriteRenderer.sprite != run)
        {
            spriteRenderer.sprite = run;
        }
        else
        {
            spriteRenderer.sprite = idle;
        }
        if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
        {
            AnimationControl();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (grounded == true)
        {
            extraJumps = jumplimit;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void AnimationControl()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public float GetJumpForce() { return jumpForce; }
    public bool GetGrounded() { return grounded; }
    public bool GetDirection() { return facingRight; }

    public void FlipJumpGrav() { jumpForce = jumpForce * -1; }
    public void SetDirection(bool a_isRightFace) { facingRight = a_isRightFace; }
}
