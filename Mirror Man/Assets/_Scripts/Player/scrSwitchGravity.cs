using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scrSwitchGravity : MonoBehaviour
{
    private scrEntity m_entity;
    private Rigidbody2D rb;
    private scrPlayerMovement player;
    private bool top;
    public GameObject mirror;
    private bool canFlip;
    public float height;
    public Transform reflectNormal;
    public float initialFlipDirection;
    private float inititalJumpForce;
    public float checkFlip;
    public RaycastHit2D hitReflective;

    public GameObject prefabReflection;
    public GameObject playerReflection;

    public GameObject normalMap;
    public GameObject invertedMap;

    // Even = Normal, Odd = Flipped
    public int isFlipped = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<scrPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        m_entity = GetComponent<scrEntity>();
        if (GameObject.Find("Player Reflection") == null)
        {
            playerReflection = Instantiate(prefabReflection, transform.position, Quaternion.identity);
        }        
        Reset();
        inititalJumpForce = player.GetJumpForce();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (m_entity.GetGrounded() == true)
        {
            canFlip = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFlip)
        {
            MirrorPlayer();
            isFlipped++;
        }
        UpdateReflection();
    }

    void DetectTerrain()
    {
        if (checkFlip == 1f)
        {
            hitReflective = Physics2D.Raycast(transform.position - new Vector3(0f, transform.localScale.y, 0f), Vector2.up);
        }
        else if (checkFlip == -1f)
        {
            hitReflective = Physics2D.Raycast(transform.position + new Vector3(0f, transform.localScale.y, 0f), Vector2.down);
        }
        reflectNormal = hitReflective.transform;
    }

    public void MirrorPlayer()
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
                transform.position = new Vector3(transform.position.x, (distanceBetweenReflection - reflectNormal.position.y) * -1, transform.position.z);
            }
            else if (transform.position.y < reflectNormal.position.y)
            {
                transform.position = new Vector3(transform.position.x, (distanceBetweenReflection - reflectNormal.position.y) * -1, transform.position.z);
            }
            checkFlip *= -1;
            rb.gravityScale *= -1;
            normalMap.GetComponent<scrTileAlphaFlip>().AlphaFlip(normalMap.GetComponent<scrTileAlphaFlip>().GetInitialAlpha()*-1);
            invertedMap.GetComponent<scrTileAlphaFlip>().AlphaFlip(normalMap.GetComponent<scrTileAlphaFlip>().GetInitialAlpha() * -1);
            Rotation();
        }
        else if (m_entity.GetGrounded() == false)
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
                playerReflection.transform.position = new Vector3(transform.position.x, (distanceBetweenReflection-reflectNormal.position.y)*-1, transform.position.z);
            }
            else if (transform.position.y < reflectNormal.position.y)
            {
                playerReflection.transform.position = new Vector3(transform.position.x, (distanceBetweenReflection - reflectNormal.position.y) * -1, transform.position.z);
            }           
        }
        else if (m_entity.GetGrounded() == false)
        {
            playerReflection.SetActive(false);
        }
        playerReflection.transform.localScale = transform.localScale;
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            playerReflection.transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            playerReflection.transform.eulerAngles = Vector3.zero;
        }
        player.SetDirection(!player.GetDirection());
        player.FlipJumpGrav();
        top = !top;

        player.AnimationControl();
        
    }

    public void Reset()
    {
        checkFlip = initialFlipDirection;
        reflectNormal = null;
        
        if (initialFlipDirection < 0f && rb.gravityScale > 0)
        {
            rb.gravityScale *= -1;
            return;
        }
        if (initialFlipDirection > 0f && rb.gravityScale < 0)
        {
            rb.gravityScale *= -1;
            return;
        }       
    }

    public void ResetRotation()
    {
        while (player.GetJumpForce() != inititalJumpForce)
        {
            Rotation();
        }
    }

    public RaycastHit2D GetReflectionPoint()    { return hitReflective; }
}