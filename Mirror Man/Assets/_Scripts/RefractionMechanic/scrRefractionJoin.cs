using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRefractionJoin : MonoBehaviour {
    [SerializeField] GameObject Player;

    [SerializeField] GameObject JoinEmpty;

    Vector2 joinPoint;

    GameObject PlayerRightHalf;
    GameObject PlayerLeftHalf;

    private void Start() {
        // Get a reference to the position where the player will be joined back together
        joinPoint = JoinEmpty.transform.position;
    }

    // Start is called before the first frame update
    public void Ready()
    {
        PlayerRightHalf = GameObject.FindGameObjectWithTag("PlayerRightHalf");
        PlayerLeftHalf = GameObject.FindGameObjectWithTag("PlayerLeftHalf");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PlayerRightHalf" || collision.gameObject.tag == "PlayerLeftHalf") {
            // Destroy Split Players
            Destroy(PlayerRightHalf);
            Destroy(PlayerLeftHalf);
            Instantiate(Player, joinPoint, Quaternion.identity);
        }
    }
}
