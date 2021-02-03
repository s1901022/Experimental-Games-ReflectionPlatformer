using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRefractionSplit : MonoBehaviour {

    [SerializeField] GameObject player;

    // New Split Position
    private Vector2 splitPositionOne;
    private Vector2 splitPositionTwo;
    [SerializeField] private GameObject[] splitEmpty = new GameObject[2];

    [SerializeField] GameObject PlayerRightHalf, PlayerLeftHalf;

    [SerializeField] GameObject RefractionEnd;

    private void Start() {

        // Get a reference to the split points
        splitPositionOne = splitEmpty[0].gameObject.transform.position;
        splitPositionTwo = splitEmpty[1].gameObject.transform.position;
    }

    private void Update() {
        // THIS HAS BEEN ADDED DUE TO BEING ABLE TO GO BACK TO THE START AND SPAWN MORE SPLIT PLAYERS
        // Get a reference to the single player object
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag ==  "Player") {
            SplitPlayer();
        }
    }

    void SplitPlayer() {
        // Destroy Player
        Destroy(player);
        // Instantiate split players at the two split points
        GameObject.Instantiate(PlayerRightHalf, splitPositionOne, Quaternion.identity);
        GameObject.Instantiate(PlayerLeftHalf, splitPositionTwo, Quaternion.identity);
        PlayerRightHalf.GetComponent<scrEntity>().isSplit = true;
        PlayerLeftHalf.GetComponent<scrEntity>().isSplit = true;
        // This tells the refraction end prefab to get a reference to the newly made split players
        RefractionEnd.GetComponent<scrRefractionJoin>().Ready();
    }
}
