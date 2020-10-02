using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private scrPlayerMovement player;
    private bool top;
    public GameObject mirror;
    public bool canFlip;
    public float height;
    public Transform reflectNormal;
    public float checkFlip;
    RaycastHit2D hitReflective;   

    // Start is called before the first frame update
    void Start()
    {
        checkFlip = 1f;
        player = GetComponent<scrPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        reflectNormal = null;
    }

    // Update is called once per frame
    void Update()
    { 
        if (player.grounded)
        {
            canFlip = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFlip)
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            canFlip = false;
            if (checkFlip == 1f)
            {
                hitReflective = Physics2D.Raycast(transform.position - new Vector3(0f, transform.localScale.y, 0f), Vector2.down);
            }
            else if (checkFlip == -1f)
            {
                hitReflective = Physics2D.Raycast(transform.position + new Vector3(0f, transform.localScale.y, 0f), Vector2.down);
            }
            reflectNormal = hitReflective.transform;
            Vector2 size = hitReflective.collider.gameObject.GetComponent<BoxCollider2D>().bounds.size;
            height = size.y;
            Debug.Log("h: " + height);

            if (hitReflective.collider != null && hitReflective.collider.tag == "Reflective")
            {
                float distanceBetweenReflection = transform.position.y - reflectNormal.position.y;
                float reflectiveScale = height / 2;

                if (transform.position.y > reflectNormal.position.y)
                {
                    transform.position = new Vector3(transform.position.x, (reflectNormal.position.y - reflectiveScale) - distanceBetweenReflection, transform.position.z);
                }
                else if (transform.position.y < reflectNormal.position.y)
                {
                    transform.position = new Vector3(transform.position.x, (reflectNormal.position.y + reflectiveScale) - distanceBetweenReflection, transform.position.z);
                }

                Debug.Log("First check");
                Debug.Log(reflectNormal.position.y);
                Debug.Log("dist " + distanceBetweenReflection);

                checkFlip *= -1;
                rb.gravityScale *= -1;
                rotation();
            }
            else if (player.grounded == false)
            {
                Debug.Log("Nope goodbye");
                checkFlip *= -1;
                rb.gravityScale *= -1;
                rotation();
            }
        }        
    }

    void rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        player.facingRight = !player.facingRight;
        player.jumpForce = player.jumpForce * -1;
        top = !top;
    }
}
