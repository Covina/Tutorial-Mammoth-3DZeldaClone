using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    [Header("Sword Speeds")]
    public float swordSwingSpeed = 10.0f;

    public float attackDuration = 0.35f;

    public float cooldownSpeed = 2.0f;
    public float cooldownDuration = 0.5f;

    private Quaternion targetRotation;

    private float cooldownTimer;

	// Use this for initialization
	void Start () {

        // initialize
        targetRotation = Quaternion.Euler(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, swordSwingSpeed * Time.deltaTime);

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

        // rotate sword
        targetRotation = Quaternion.Euler(90, 0, 0);

        // reset cooldown timer
        cooldownTimer = cooldownDuration;

        // Fire off the wait
        StartCoroutine(CooldownWait());

    }


    private IEnumerator CooldownWait()
    {
        // Wait some time after attack
        yield return new WaitForSeconds(attackDuration);

        // Set return position for the sword
        targetRotation = Quaternion.Euler(0, 0, 0);

    }




}
