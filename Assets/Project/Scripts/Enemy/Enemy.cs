using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public int health = 1;


    // set for override
    public virtual void Hit()
    {
        health--;

        if (health <= 0)
        {
            EffectManager.Instance.ApplyEffect(transform.position, EffectManager.Instance.killEffectPrefab);

            Destroy(gameObject);
        } else
        {
            EffectManager.Instance.ApplyEffect(transform.position, EffectManager.Instance.hitEffectPrefab);
        }

    }

    // If an enemy collides with something
    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Arrow>() != null)
        {
            //Debug.Log("Enemy :: Arrow Hit detected");
            Hit();

            // destroy the arrow as it hits the Enemy
            Destroy(other.gameObject);
        }

    }


    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Sword>() != null)
        {
            if (other.GetComponent<Sword>().JustAttacked)
            {
                Hit();
            }
        }
    }

}
