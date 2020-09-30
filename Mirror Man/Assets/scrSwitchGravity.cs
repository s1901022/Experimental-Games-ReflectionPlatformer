using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private scrPlayerMovement player;
    private bool top;
    public GameObject mirror;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<scrPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = Vector3.Reflect(transform.position, mirror.transform.up);
            //transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
            rb.gravityScale *= -1;
            rotation();
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
