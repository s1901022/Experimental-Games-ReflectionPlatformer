using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    GameObject[] borders;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = this.gameObject.transform.position;
        // X-AXIS
        if (playerPosition.x > (cameraPosition.x - 10) || playerPosition.x < (cameraPosition.x + 10)) {
            // Set the cameras position to move towards the players x position
            gameObject.transform.position = Vector3.MoveTowards(transform.position,
                                                                new Vector3(playerPosition.x, transform.position.y, transform.position.z),
                                                                Time.deltaTime * 0.5f);
        }

        // Y-AXIS
        if (playerPosition.y > (cameraPosition.y + 5) || playerPosition.y < (cameraPosition.y - 5)) {
            // Set the cameras position to move towards the players x position
            gameObject.transform.position = Vector3.MoveTowards(transform.position,
                                                                new Vector3(transform.position.x, playerPosition.y, transform.position.z),
                                                                Time.deltaTime * 0.5f);
        }
    }
}
