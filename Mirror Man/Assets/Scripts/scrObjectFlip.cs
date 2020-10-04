using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrObjectFlip : MonoBehaviour
{
    public bool grounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    private Rigidbody2D rb;
    private bool top;
    public GameObject mirror;
    public bool canFlip;
    public float height;
    public Transform reflectNormal;
    public float checkFlip;
    RaycastHit2D hitReflective;

    public GameObject prefabReflection;
    public GameObject myReflection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        reflectNormal = null;
        if (GameObject.Find("Player Reflection") == null)
        {
            myReflection = Instantiate(prefabReflection, transform.position, Quaternion.identity);
        }
        if (checkFlip < 0)
        {
            rb.gravityScale *= -1;
            canFlip = false;
        }
        else
        {
            checkFlip = 1f;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            canFlip = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFlip)
        {
            MirrorObject();
        }
        UpdateReflection();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
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

    void MirrorObject()
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
        else if (grounded == false)
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
            myReflection.SetActive(true);
            float distanceBetweenReflection = transform.position.y - reflectNormal.position.y;
            float reflectiveScale = reflectNormal.localScale.y / 2;

            if (transform.position.y > reflectNormal.position.y)
            {
                myReflection.transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y + myReflection.transform.localScale.y) - reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }
            else if (transform.position.y < reflectNormal.position.y)
            {
                myReflection.transform.position = new Vector3(transform.position.x, ((reflectNormal.position.y + myReflection.transform.localScale.y) - reflectiveScale) - distanceBetweenReflection, transform.position.z);
            }
        }
        else if (grounded == false)
        {
            myReflection.SetActive(false);
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
        top = !top;
    }
}
