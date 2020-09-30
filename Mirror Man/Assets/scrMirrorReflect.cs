using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMirrorReflect : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject reflectedObject;

    void Start()
    {
        Vector3 castPoint = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        RaycastHit2D[] hit = Physics2D.CircleCastAll(castPoint, 5.0f, Vector2.up, Mathf.Infinity);

        // If it hits something...
        Debug.Log("Did Hit");
        foreach (RaycastHit2D objectHit in hit)
        {
            if (objectHit != null && objectHit.collider.tag == "reflect")
            {
                print("Hitting exactly object with tag I want");
                originalObject = objectHit.collider.gameObject;
                if (GameObject.Find(originalObject.name + "(Clone)") == null)
                {
                    reflectedObject = Instantiate(originalObject, originalObject.transform.position, Quaternion.identity);
                }
                if (GameObject.Find(originalObject.name + "(Clone)") != null)
                { 
                    reflectedObject.transform.position = Vector3.Reflect(originalObject.transform.position, transform.up);
                }                                
            }
        }        
        
        // Makes the reflected object appear opposite of the original object,
        // mirrored along the z-axis of the world
        
    }
}
