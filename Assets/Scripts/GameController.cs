using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public GameObject[] gameCameras;

    // Track which camera we want to look at.
    private int gameCameraIndex = 0;

	// Use this for initialization
	void Start () {
        // set main camera
        FocusOnCamera(gameCameraIndex);

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            // change direction
            ChangeCamera(1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            // change direction
            ChangeCamera(-1);
        }

    }


    private void FocusOnCamera(int index)
    {
        for(int i = 0; i < gameCameras.Length; i++)
        {

            if (i == index)
            {
                gameCameras[i].SetActive(true);
                continue;

            }

            gameCameras[i].SetActive(false);


        }


    }

    /// <summary>
    /// Change Camera
    /// </summary>
    /// <param name="changeDirection"></param>
    private void ChangeCamera(int changeDirection)
    {
        // move one index
        gameCameraIndex += changeDirection;

        if(gameCameraIndex >= gameCameras.Length)
        {
            // out of range, wrap to first one
            gameCameraIndex = 0;

        } else if (gameCameraIndex < 0)
        {
            // out of range, wrap around to last one
            gameCameraIndex = gameCameras.Length - 1;
        }

        FocusOnCamera(gameCameraIndex);


    }

}
