using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingLogic : MonoBehaviour {

    // Array of directions
    /*
     * Square cycle: Up, right, down, left
     * 
     */
    public Vector3[] directions;

    public float timeToChangeDirection = 1.0f;

    public float movementSpeed;


    private int directionIndex;
    private float directionTimer;

	// Use this for initialization
	void Start () {

        // index
        directionIndex = 0;

        // set countdown timer
        directionTimer = timeToChangeDirection;

	}
	
	// Update is called once per frame
	void Update () {

        directionTimer -= Time.deltaTime;

        // when enough time passes, change direction
        if(directionTimer <= 0)
        {
            // reset countdown timer
            directionTimer = timeToChangeDirection;

            // update direction index
            directionIndex++;

            // see if we need to loop around
            if(directionIndex >= directions.Length)
            {
                directionIndex = 0;
            }

        }

        // Set direction 
        GetComponent<Rigidbody>().velocity = new Vector3(
            directions[directionIndex].x * movementSpeed,
            GetComponent<Rigidbody>().velocity.y,
            directions[directionIndex].z * movementSpeed
            );

		
	}
}
