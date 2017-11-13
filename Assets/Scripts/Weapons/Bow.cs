using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public GameObject arrowPrefab;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
        // Create the arrow
        GameObject arrowObject = Instantiate(arrowPrefab);
        
        // Position the arrow in line with the bow and facing outward from the bow
        arrowObject.transform.position = transform.position + transform.forward;

        // Set the object to face forward
        arrowObject.transform.forward = transform.forward;

    }
}
