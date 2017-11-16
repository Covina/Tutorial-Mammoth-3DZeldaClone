using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public Player player;

    public Vector3 cameraOffset;

    public float focusSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        {


            transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraOffset, focusSpeed * Time.deltaTime);

            // if there was a telportation, instantly move the camera
            if(player.JustTeleported)
            {
                transform.position = player.transform.position + cameraOffset;
            }


        }
        
            
	}
}
