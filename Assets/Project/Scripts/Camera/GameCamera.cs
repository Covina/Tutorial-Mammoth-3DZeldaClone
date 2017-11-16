using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public GameObject target;

    public Vector3 cameraOffset;

    public float focusSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, focusSpeed * Time.deltaTime);
        }
        
            
	}
}
