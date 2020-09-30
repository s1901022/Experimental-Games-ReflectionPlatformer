using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerMovement : MonoBehaviour
{
    public int jumplimit;
    private int extraJumps;

    public float moveSpeed;
    public float jumpForce;
    private float moveInput;

    public bool facingRight = true;
    private bool grounded = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = jumplimit;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if ((facingRight == false && moveInput > 0) || (facingRight == true && moveInput < 0))
        {
            animationControl();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

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

    void animationControl()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
