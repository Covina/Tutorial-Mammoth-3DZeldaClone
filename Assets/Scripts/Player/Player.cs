using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Model Movement")]

    // Reference to the body and eyes model
    [SerializeField] private GameObject model;

    [SerializeField] private float playerRotationSpeed = 10.0f;

    // Movement Speed
    [SerializeField] private float playerMovementVelocity = 5.0f;

    // Jumping force
    [SerializeField] private float playerJumpVelocity = 5.0f;


    [Header("Equipment")]
    public Sword sword;
    public GameObject bombPrefab;
    public int BombAmount = 5;
    public float throwingSpeed = 1.0f;
    public Bow bow;
    public int arrowAmount = 15;
    

    // Track whether to process jump
    private bool playerCanJump = false;

    // Get the RigidBody on the Player object
    private Rigidbody playerRigidBody;

    // holder for which direction we're turning toward
    private Quaternion targetModelRotation;




    // Use this for initialization
    void Start ()
    {
        // get reference for rigidbody
        playerRigidBody = GetComponent<Rigidbody>();

        // reset face direction
        targetModelRotation = Quaternion.Euler(0, 0, 0);

        // Start player with sword showing
        bow.gameObject.SetActive(false);


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

        // Attack - Swing sword
        if(Input.GetKeyDown(KeyCode.Z))
        {
            // using the Sword
            sword.gameObject.SetActive(true);
            bow.gameObject.SetActive(false);

            sword.Attack();

        }

        // Attack - Throw a Bomb
        if (Input.GetKeyDown(KeyCode.C))
        {

            ThrowBomb();

        }

        // Attack - Fire the Bow
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Check inventory
            if(arrowAmount > 0) {

                // using the Bow
                sword.gameObject.SetActive(false);
                bow.gameObject.SetActive(true);

                bow.Attack();

                // reduce arrow inventory
                arrowAmount--;
            }

            

        }





    }


    /// <summary>
    /// Create the bomb
    /// </summary>
    private void ThrowBomb()
    {
        // Check inventory
        if(BombAmount <= 0)
        {
            return;
        }

        // Reduce inventory by 1
        BombAmount--;

        // Create the bomb
        GameObject bombObject = Instantiate(bombPrefab);

        // set at player position and aim at facing outward vector
        bombObject.transform.position = transform.position + model.transform.forward;

        // set direction and give verticality
        Vector3 throwingDirection = (model.transform.forward + Vector3.up).normalized;

        // Throw the object
        bombObject.GetComponent<Rigidbody>().AddForce(throwingDirection * throwingSpeed);
    }

}
