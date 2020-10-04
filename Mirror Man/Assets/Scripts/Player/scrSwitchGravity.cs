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

    public GameObject prefabReflection;
    public GameObject playerReflection;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player Reflection") == null)
        {
            playerReflection = Instantiate(prefabReflection, transform.position, Quaternion.identity);
        }


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
            MirrorPlayer();  
        }
        UpdateReflection();
    }

    void DetectTerrain()
    {
        if (checkFlip == 1f)
        {
            hitReflective = Physics2D.Raycast(transform.position - new Vector3(0f, transform.localScale.y, 0f), Vector2.down);
        }
        else if (checkFlip == -1f)
        {
            hitReflective = Physics2D.Raycast(transform.position + new Vector3(0f, transform.localScale.y + 1, 0f), Vector2.down);
        }
        reflectNormal = hitReflective.transform;
    }

    void MirrorPlayer()
    {
        rb.velocity = new Vector2(0.0f, 0.0f);
        canFlip = false;

        DetectTerrain();

        if (hitReflective.collider != null && hitReflective.collider.tag == "Reflective")
        {
            float distanceBetweenReflection = transform.position.y - reflectNormal.position.y;
            float reflectiveScale = reflectNormal.localScale.y / 2;

            if (transform.position.y > reflectNormal.position.y)
            {
                transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y - transform.localScale.y) + reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }
            else if (transform.position.y < reflectNormal.position.y)
            {
                transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y + transform.localScale.y) - reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }
            checkFlip *= -1;
            rb.gravityScale *= -1;
            Rotation();
        }
        else if (player.grounded == false)
        {
            Debug.Log("Nope goodbye");
            checkFlip *= -1;
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    void UpdateReflection()
    {
        DetectTerrain();
        if (hitReflective.collider != null && hitReflective.collider.tag == "Reflective")
        {
            playerReflection.SetActive(true);
            float distanceBetweenReflection = transform.position.y - reflectNormal.position.y;
            float reflectiveScale = reflectNormal.localScale.y/2;

            if (transform.position.y > reflectNormal.position.y)
            {
                playerReflection.transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y + playerReflection.transform.localScale.y) - reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }
            else if (transform.position.y < reflectNormal.position.y)
            {
                playerReflection.transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y + playerReflection.transform.localScale.y) - reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }           
        }
        else if (player.grounded == false)
        {
            playerReflection.SetActive(false);
        }
    }

    void Rotation()
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