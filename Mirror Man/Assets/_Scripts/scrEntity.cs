using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEntity : MonoBehaviour
{
    [SerializeField]
    private GameObject groundC;

    Rigidbody2D rb;
    Vector3 initialPosition;
    private GameObject groundCheck;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private float C_Offset;
    private bool m_dead;

    private bool grounded = false;

    public bool isSplit = false;

    public enum physicsObjectType
    {
        RigidBody,
        Locked,
        None
    }
    [SerializeField]
    private physicsObjectType physicsType;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        // This has been added so that it checks if it is grounding the refraction left half player OR a normal / right half player
        if (gameObject.tag == "PlayerLeftHalf") {
            groundCheck = Instantiate(groundC, new Vector3(transform.position.x, -transform.position.y - ((transform.localScale.y / 2) + C_Offset), transform.position.z), Quaternion.identity);

        } else {
            groundCheck = Instantiate(groundC, new Vector3(transform.position.x, transform.position.y - ((transform.localScale.y / 2) + C_Offset), transform.position.z), Quaternion.identity);
        }
        groundCheck.transform.parent = gameObject.transform;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, ground);
        switch (physicsType)
        {
            case physicsObjectType.Locked:
                {
                    if (!grounded)
                    {
                        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    }
                    else if (grounded == true)
                    {
                        rb.constraints = RigidbodyConstraints2D.None;
                        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                    
                    break;
                }
            case physicsObjectType.None:
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    break;
                }
            case physicsObjectType.RigidBody:
                {
                    break;
                }
            default:
                {
                    SwapPhysicsSystem(physicsObjectType.RigidBody);
                    break;
                }
        }
        if (isSplit == false) {
            if (GameObject.FindWithTag("Player").GetComponent<scrEntity>().m_dead == true) {
                Reset();
            }
        } else {
            if (GameObject.FindWithTag("PlayerRightHalf").GetComponent<scrEntity>().m_dead == true
            || GameObject.FindWithTag("PlayerLeftHalf").GetComponent<scrEntity>().m_dead == true) {
                Reset();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Death" && !m_dead)
        {
            Reset();
        }
    }

    public void Reset()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        transform.position = initialPosition;
        var flippableEntity = GetComponent<scrObjectFlip>();
        if (flippableEntity != null)
        {
            flippableEntity.Rotation();
            flippableEntity.Reset();
        }
        m_dead = false;
    }

    public void SwapPhysicsSystem(physicsObjectType a_NewType)
    {
        rb.constraints = RigidbodyConstraints2D.None;
        physicsType = a_NewType;
    }

    public bool GetGrounded() { return grounded; }
    public bool GetDead() { return m_dead; }
    public void SetDead() { m_dead = !m_dead; }
}
