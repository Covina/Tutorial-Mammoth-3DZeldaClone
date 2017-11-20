using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public GameObject playerModel;
    public GameObject arrowPrefab;
    

    public void Attack()
    {
        // Create the arrow
        GameObject arrowObject = Instantiate(arrowPrefab);
        
        // Position the arrow in line with the bow and facing outward from the bow
        arrowObject.transform.position = playerModel.transform.position + playerModel.transform.forward;

        // Set the object to face forward
        arrowObject.transform.forward = playerModel.transform.forward;

    }
}
