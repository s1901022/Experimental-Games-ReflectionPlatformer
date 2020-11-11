using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerInteractions : MonoBehaviour
{
    public bool dead;
    private bool deathComplete;
    private scrPlayerMovement playerBase;
    private scrSwitchGravity playerMirror;
    private scrEntity EntityScript;
    private Rigidbody2D rb;

    private Vector3 startingPos;
    private GameObject[] EntityResets;

    void Start()
    {
        //Get references to player components
        EntityScript = GetComponent<scrEntity>();
        playerBase = GetComponent<scrPlayerMovement>();
        playerMirror = GetComponent<scrSwitchGravity>();
        rb = GetComponent<Rigidbody2D>();

        //initialise variables
        startingPos = transform.position;
        deathComplete = true;
    }

    void Update()
    {
        //simple check for death
        if (dead == true && deathComplete == false)
        {
            dead = false;
            deathComplete = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Death") 
        {
            dead = true;
            deathComplete = false;
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.position = startingPos;
            playerMirror.ResetRotation();
            playerMirror.Reset();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        
    }
}
