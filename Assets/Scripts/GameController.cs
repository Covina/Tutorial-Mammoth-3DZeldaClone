using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Jump");

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            Debug.Log("Move Left");

        }


        if (Input.GetKey(KeyCode.RightArrow))
        {

            Debug.Log("Move Right");

        }


    }
}
