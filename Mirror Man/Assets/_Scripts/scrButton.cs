using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrButton : MonoBehaviour
{
    public bool flag;
    public bool flagDefault;
    public bool alwaysSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Handle Death and respawning
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Entity")
        {
            if (flag == flagDefault)
            {
                flag = !flag;
            }           
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (alwaysSet == false)
        {
            flag = flagDefault;
        }
    }
}
