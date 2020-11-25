using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D rb;

    [SerializeField]
    private GameObject trigger;
    private scrButton triggerScript;

    void Start()
    {
        //Get Trigger
        triggerScript = trigger.transform.GetChild(0).gameObject.GetComponent<scrButton>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerScript.flag == true)
        {
            rb.enabled = false;
            spriteRenderer.enabled = false;            
        }
        else
        {
            rb.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}
