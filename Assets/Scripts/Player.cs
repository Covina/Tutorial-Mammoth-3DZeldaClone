using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Movement Speed
    public float movementSpeed = 3.5f;

    // Jumping force
    public float jumpingForce = 200.0f;

    public float rotatingSpeed = 3.0f;

    private bool canJump = false;

    

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(canJump == true)
            {
                // Add vertical force
                GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
                canJump = false;
            }

        }
        // Rotate left
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
            transform.RotateAround(transform.position, Vector3.up, -rotatingSpeed);
        }

        // Rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {

            //transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.RotateAround(transform.position, Vector3.up, rotatingSpeed);

        }

        // Move Forward
        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.position += transform.forward * movementSpeed * Time.deltaTime;

        }

        // Move in reverse
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;

        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Floor")
        {
            canJump = true;
        }
    }
}
