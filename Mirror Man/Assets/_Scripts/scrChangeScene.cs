using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrChangeScene : MonoBehaviour
{
    public string sceneToLoad;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Stage_Loader.LoadSceneSafe(sceneToLoad);
        }
    }
}
