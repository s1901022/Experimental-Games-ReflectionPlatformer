using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    GameObject[] borders = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        borders[0] = GameObject.FindGameObjectWithTag("BarrierTop");
        borders[1] = GameObject.FindGameObjectWithTag("BarrierBottom");
        borders[2] = GameObject.FindGameObjectWithTag("BarrierLeft");
        borders[3] = GameObject.FindGameObjectWithTag("BarrierRight");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = this.gameObject.transform.position;

        float halfScreenWidth = 9;
        float halfScreenHeight = Screen.height / 2;

        // X-AXIS
        if (((playerPosition.x <= cameraPosition.x - halfScreenWidth) || (playerPosition.x >= cameraPosition.x + halfScreenWidth))
            && ((cameraPosition.x - halfScreenWidth <= borders[3].transform.position.x) || (cameraPosition.x + halfScreenWidth >= borders[2].transform.position.x))) {
            // Set the cameras position to move towards the players x position
            gameObject.transform.position = Vector3.MoveTowards(transform.position,
                                                                new Vector3(playerPosition.x, transform.position.y, transform.position.z),
                                                                Time.deltaTime * 4.0f);
        } else {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        // Y-AXIS
        if (((playerPosition.y <= cameraPosition.y - halfScreenHeight) || (playerPosition.y >= cameraPosition.y + halfScreenHeight))
            && ((cameraPosition.y - halfScreenHeight <= borders[0].transform.position.y) || (cameraPosition.y + halfScreenHeight >= borders[1].transform.position.y))) {
            // Set the cameras position to move towards the players x position
            gameObject.transform.position = Vector3.MoveTowards(transform.position,
                                                                new Vector3(transform.position.x, playerPosition.y, transform.position.z),
                                                                Time.deltaTime * 2.5f);
        }
    }
}
