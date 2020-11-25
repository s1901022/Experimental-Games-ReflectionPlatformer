using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGameControl : MonoBehaviour
{
    private GameObject mPlayer;
    private GameObject mCamera;

    public GameObject GetPlayer() { return mPlayer; }
    public GameObject GetCamera() { return mCamera; }

    void Start()
    {
        mPlayer = GameObject.Find("Player");
        mCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
