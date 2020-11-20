using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEntity : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 initialPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<scrPlayerInteractions>().dead == true)
        {
            Reset();            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Death")
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
    }
}
