using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public int health = 1;


    // set for override
    public virtual void Hit()
    {
        health--;

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

    // If an enemy collides with something
    public void OnTriggerEnter(Collider other)
    {

        Debug.Log("Enemy :: Sword Hit detected");

        // If enemy was hit with sword, then run the hit function
        if (other.GetComponent<Sword>() != null)
        {
            // Check that we are actively attacking to correct for collisions
            if (other.GetComponent<Sword>().IsAttacking == true)
            {
                //Debug.Log("Enemy :: Sword Hit detected");
                Hit();

            }

        } else if (other.GetComponent<Arrow>() != null)
        {
            Debug.Log("Enemy :: Arrow Hit detected");
            Hit();

            // destroy the arrow as it hits the Enemy
            Destroy(other.gameObject);
        }

    }



}
