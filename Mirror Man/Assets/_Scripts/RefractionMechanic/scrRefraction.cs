using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRefraction : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // New Split Position
    private Vector2 splitPositionOne;
    private Vector2 splitPositionTwo;
    [SerializeField] 
    private GameObject[] splitEmpty =  new GameObject[2];

    [SerializeField]
    GameObject playerTopHalf, PlayerBottomHalf;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        splitPositionOne = splitEmpty[0].gameObject.transform.position;
        splitPositionTwo = splitEmpty[1].gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "")
        {
            return;
        }
        else
        {
            SplitPlayer();
        }
    }

    void SplitPlayer()
    {
        
    }
}
