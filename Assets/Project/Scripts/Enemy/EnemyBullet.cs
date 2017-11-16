using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float bulletSpeed = 10.0f;

    public float bulletLifetime = 2.0f;

    // Use this for initialization
    void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        bulletLifetime -= Time.deltaTime;

        if (bulletLifetime <= 0)
        {
            Destroy(gameObject);
        }

    }
}
