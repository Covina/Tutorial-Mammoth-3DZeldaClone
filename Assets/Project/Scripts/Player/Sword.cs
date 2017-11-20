using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    [Header("Sword Speeds")]
    public float swordSwingSpeed = 10.0f;

    public float attackDuration = 1.0f;

    public float cooldownSpeed = 2.0f;
    public float cooldownDuration = 0.5f;


    public Vector3 defaultAngle;
    public Vector3 attackAngle;

    private Quaternion targetRotation;

    private float cooldownTimer;

    private bool isAttacking = false;
    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }


    private bool justAttacked;
    public bool JustAttacked
    {
        get { return justAttacked; }
    }


	// Use this for initialization
	void Start () {

        // initialize
        targetRotation = Quaternion.Euler(defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {

        // determine whether to attack and cooldown
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * (isAttacking ? swordSwingSpeed : cooldownSpeed) );

        cooldownTimer -= Time.deltaTime;
	}

    /// <summary>
    /// Attack
    /// </summary>
    public void Attack()
    {
        // If we're on cooldown
        if(cooldownTimer > 0f)
        {
            return;
        }

        // Swing the sword by rotating it
        targetRotation = Quaternion.Euler(attackAngle);


        // check for collisions

        // reset cooldown timer
        cooldownTimer = cooldownDuration;

        // Fire off the wait
        StartCoroutine(CooldownWait());

    }


    private IEnumerator CooldownWait()
    {
        isAttacking = true;
        justAttacked = true;

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        justAttacked = false;

        // Wait some time after attack
        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;

        // Set return position for the sword
        targetRotation = Quaternion.Euler(defaultAngle);

    }




}
