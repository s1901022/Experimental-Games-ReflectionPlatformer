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
    public bool grounded = false;
    private int extraJumps;
    //Variables for collision detection
    public Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask ground;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private scrEntity m_entity;
    private scrSwitchGravity m_mirror;

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
        m_entity = GetComponent<scrEntity>();
        m_mirror = GetComponent<scrSwitchGravity>();
    }

    void FixedUpdate()
    {
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
        if (!m_entity.GetDead())
        {
            if (m_entity.GetGrounded())
            {
                extraJumps = jumplimit;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && m_entity.GetGrounded())
            {
                rb.velocity = Vector2.up * jumpForce;
                Debug.Log("JUMPING");
            }
        }       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Death" && !m_entity.GetDead())
        {
            if (m_mirror.isFlipped % 2 != 0) {

                m_mirror.ResetForNextTry();
                m_mirror.ResetRotation();
                m_mirror.Reset();
            }
        }
    }

    //This will need to be removed and replaced with unitys animation system when ready
    public void AnimationControl()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //Getters
    public float GetJumpForce() { return jumpForce; }
    public bool GetDirection() { return facingRight; }
    //Setters
    public void FlipJumpGrav() { jumpForce = jumpForce * -1; }
    public void SetDirection(bool a_isRightFace) { facingRight = a_isRightFace; }
}
