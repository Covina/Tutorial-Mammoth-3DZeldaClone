using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

    [Header("Model")]
    public GameObject model;
    
    // How long until changes directions
    public float timeUntilRotate = 2.0f;

    // How quickly the enemy turns
    public float rotationSpeedInTime = 3.0f;

    public bool rotateClockwise = true;

    // Prep for rotation information
    private Quaternion targetRotation;
    private int targetAngle;

    // Countdown timer for tracking when to turn
    private float rotationTimer;

    [Header("Projectile")]
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float timeUntilShoot = 1.0f;
    private float shootTimer;


    // Use this for initialization
    void Start () {

        // init at full time
        rotationTimer = timeUntilRotate;
        shootTimer = timeUntilShoot;
	}
	
	// Update is called once per frame
	void Update () {

        // countdown
        rotationTimer -= Time.deltaTime;

        // Are we due for change
        if(rotationTimer <= 0f)
        {
            // reset the countdown
            rotationTimer = timeUntilRotate;

            // Angle direction change
            targetAngle += (rotateClockwise ? 90 : -90);
        }

        // Turn the enemy
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, targetAngle, 0), rotationSpeedInTime * Time.deltaTime);


        // Shoot bullets
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0.0f)
        {
            shootTimer = timeUntilShoot;

            // Spawn the obejct
            GameObject bulletObject = Instantiate(bulletPrefab);

            // set direction it faces
            bulletObject.transform.position = bulletSpawnPoint.transform.position;
            

            // set the bullet forward position to the model's forward position
            bulletObject.transform.forward = model.transform.forward;



        }


	}
}
