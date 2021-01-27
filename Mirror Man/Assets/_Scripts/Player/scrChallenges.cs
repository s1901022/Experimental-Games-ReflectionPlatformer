using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrChallenges : MonoBehaviour
{
    int iJumps = 0;
    int iFlips = 0;

    // Update is called once per frame
    void Update()
    {
            // This can be changed to W once inputs have been changed

        // This checks if the player has jumped, but to stop it from constantly being added to if the button is held down
        // it adds one once the button has been unpressed
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            iJumps++;
        }
        // This checks if the floor below the player is reflective and they have pressed the flip button
        if (Input.GetKeyUp(KeyCode.Space) && GetComponent<scrSwitchGravity>().GetReflectionPoint().collider.tag == "Reflective")
        {
            iFlips++;
        }
    }
}
