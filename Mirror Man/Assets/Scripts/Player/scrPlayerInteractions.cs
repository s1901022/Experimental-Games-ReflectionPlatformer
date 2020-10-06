using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerInteractions : MonoBehaviour
{
    private scrPlayerMovement playerBase;
    private scrSwitchGravity playerMirror;
    private Rigidbody2D rb;

    private Vector3 startingPos;

    void Start()
    {
        playerBase = GetComponent<scrPlayerMovement>();
        playerMirror = GetComponent<scrSwitchGravity>();
        rb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Death") 
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.position = startingPos;
            playerMirror.Reset();
        }
    }
}
