using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject player = null;

    // Update is called once per frame
    void Update()
    {
        // find the Player
        this.findPlayer();
        // follow the Player
        this.followPlayer();
    }

    // finds and assigns a reference for the Player
    void findPlayer()
    {
        // if the player has not been found
        if (player == null)
        {
            // find the player
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            return;
        }

    }

    // follows the player's position
    void followPlayer()
    {
        // updates the camera position to the player position
        Vector3 updatedCameraPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        // sets this camera's position equal to the player position
        this.transform.position = updatedCameraPosition;
    }
}
