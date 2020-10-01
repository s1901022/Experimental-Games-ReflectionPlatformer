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

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<scrPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
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
            if ((transform.position.y > 0 && Mathf.Sign(rb.gravityScale) < 0) || (transform.position.y < 0 && Mathf.Sign(rb.gravityScale) > 0))
            {
                transform.position = Vector3.Reflect(transform.position, mirror.transform.up);
            }
            else if ((transform.position.y >= 0 && Mathf.Sign(rb.gravityScale) >= 0) || (transform.position.y < 0 && Mathf.Sign(rb.gravityScale) < 0))
            {
                transform.position = Vector3.Reflect(transform.position, mirror.transform.up);
                rb.gravityScale *= -1;
                rotation();
            }
            canFlip = false;
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
