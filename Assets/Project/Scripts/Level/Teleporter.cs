using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Teleporter exitTeleporter;

    public float exitOffset = 2.0f;


    private void OnTriggerEnter(Collider other)
    {
        // Check that it is the player
        if(other.GetComponent<Player>() != null)
        {
            // Check that we have a connecting teleport location
            if(exitTeleporter != null)
            {

                // Get the player
                Player player = other.GetComponent<Player>();

                // Move the player to the exit teleporter and be 1 unit in front of it
                player.transform.position = exitTeleporter.transform.position + (exitTeleporter.transform.forward * exitOffset);

                player.Teleport(exitTeleporter.transform.position + (exitTeleporter.transform.forward * exitOffset));

            }


        }

    }

}
