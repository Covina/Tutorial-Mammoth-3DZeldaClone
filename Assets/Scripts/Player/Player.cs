using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Model")]

    // Reference to the body and eyes model
    [SerializeField] private GameObject model;
    private float playerRotationSpeed = 10.0f;

    // Movement Speed
    private float playerMovementVelocity = 5.0f;

    // Jumping force
    private float playerJumpVelocity = 5.0f;

    // Track whether to process jump
    private bool playerCanJump = false;

    // Get the RigidBody on the Player object
    private Rigidbody playerRigidBody;

    private Quaternion targetModelRotation;

	// Use this for initialization
	void Start () {

        playerRigidBody = GetComponent<Rigidbody>();

        targetModelRotation = Quaternion.Euler(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {

        // Raycast Signature 12 of 16 - bool check if we hit something
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            playerCanJump = true;
        }

        // turn the player toward the target destination
        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, playerRotationSpeed * Time.deltaTime);

        // Process any player-related movement input
        ProcessPlayerMovement();

    }

    /// <summary>
    /// Process Player Movement
    /// </summary>
    private void ProcessPlayerMovement()
    {

        // Zero velocity
        playerRigidBody.velocity = new Vector3(
                0f,
                playerRigidBody.velocity.y,
                0f
                );



        // MOVE RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // move player, normalized for frame rate
            playerRigidBody.velocity = new Vector3(
                playerMovementVelocity,
                playerRigidBody.velocity.y,
                playerRigidBody.velocity.z
                );

            // Rotate the player to look right.
            targetModelRotation = Quaternion.Euler(0, 90, 0);

        }

        // MOVE LEFT
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move player, normalized for frame rate
            // move player, normalized for frame rate
            playerRigidBody.velocity = new Vector3(
                -playerMovementVelocity,
                playerRigidBody.velocity.y,
                playerRigidBody.velocity.z
                );

            // Look to the left
            targetModelRotation = Quaternion.Euler(0, 270, 0);

        }

        // MOVE FORWARD
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // move player, normalized for frame rate
            playerRigidBody.velocity = new Vector3(
                playerRigidBody.velocity.x,
                playerRigidBody.velocity.y,
                playerMovementVelocity
                );

            // Look to the front
            targetModelRotation = Quaternion.Euler(0, 0, 0);

        }

        // MOVE BACKWARD
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // move player, normalized for frame rate
            playerRigidBody.velocity = new Vector3(
                playerRigidBody.velocity.x,
                playerRigidBody.velocity.y,
                -playerMovementVelocity
                );

            // Look to the back
            targetModelRotation = Quaternion.Euler(0, 180, 0);

        }

        // JUMP
        if (playerCanJump == true && Input.GetKeyDown(KeyCode.Space))
        {

            // stop repeat jumping
            playerCanJump = false;

            // JUMP!
            playerRigidBody.velocity = new Vector3(
                playerRigidBody.velocity.x,
                playerJumpVelocity,
                playerRigidBody.velocity.z
                );

        }

    }


}
