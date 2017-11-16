using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


    public float arrowSpeed = 100.0f;

    public float arrowLifetime = 2.0f;

    // Use this for initialization
    void Start () {

        GetComponent<Rigidbody>().velocity = transform.forward * arrowSpeed;

	}
	
	// Update is called once per frame
	void Update () {

        arrowLifetime -= Time.deltaTime;

        if(arrowLifetime <= 0)
        {
            Destroy(gameObject);
        }

	}
}
