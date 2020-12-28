using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRefraction : MonoBehaviour {
    [SerializeField]
    GameObject player;

    // New Split Position
    private Vector2 splitPositionOne;
    private Vector2 splitPositionTwo;
    [SerializeField]
    private GameObject[] splitEmpty = new GameObject[2];

    [SerializeField]
    GameObject playerTopHalf, PlayerBottomHalf;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");

        splitPositionOne = splitEmpty[0].gameObject.transform.position;
        splitPositionTwo = splitEmpty[1].gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag ==  "Player") {
            SplitPlayer();
        }
    }

    void SplitPlayer() {
        Destroy(player);
        GameObject.Instantiate(playerTopHalf, splitPositionOne, Quaternion.identity);
        GameObject.Instantiate(PlayerBottomHalf, splitPositionTwo, Quaternion.identity);
    }
}
