using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public GameObject focusTarget;

    public Vector3 cameraOffset;

    public float focusSpeed = 5.0f;

    public float cameraFocusTime = 3.0f;

    public GameObject temporaryTarget;
    public float temporaryFocusTime = 3.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(temporaryTarget != null)
        {

            transform.position = Vector3.Lerp(transform.position, temporaryTarget.transform.position + cameraOffset, focusSpeed * Time.deltaTime);

        } else if(focusTarget != null)
        {
            // If its the player we are targeting
            if (focusTarget.GetComponent<Player>() != null)
            {
                Player player = focusTarget.GetComponent<Player>();

                transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraOffset, focusSpeed * Time.deltaTime);

                // if there was a telportation, instantly move the camera
                if (player.JustTeleported)
                {
                    transform.position = player.transform.position + cameraOffset;
                }
            } else
            {
                // else it is the camera
                transform.position = Vector3.Lerp(transform.position, focusTarget.transform.position + cameraOffset, focusSpeed * Time.deltaTime);

            }



        }
        
            
	}

    /// <summary>
    /// Set the target for only a few seconds
    /// </summary>
    /// <param name="target"></param>
    public void FocusOn (GameObject target)
    {

        temporaryTarget = target;

        StartCoroutine(FocusOnCoroutine());
    }

    /// <summary>
    /// After a brief time, null the temp target so it goes back to player
    /// </summary>
    /// <returns></returns>
    private IEnumerator FocusOnCoroutine()
    {

        yield return new WaitForSeconds(temporaryFocusTime);

        temporaryTarget = null;

    }

}
