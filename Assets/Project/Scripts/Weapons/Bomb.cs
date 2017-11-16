using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float duration = 5.0f;

    public float explosionRadius = 5.0f;

    public GameObject explosionGameObject;

    private float explosionTimer;

    private float explosionDuration = 0.25f;

    private bool isExploded;

	// Use this for initialization
	void Start () {

        // init the explosion timer
        explosionTimer = duration;

        // disable the explosion sphere
        explosionGameObject.SetActive(false);

        // set the explosion radius 
        explosionGameObject.transform.localScale = Vector3.one * explosionRadius;

	}
	
	// Update is called once per frame
	void Update () {

        explosionTimer -= Time.deltaTime;

        // check if its ready to explode
        if(explosionTimer <= 0f && isExploded == false)
        {
            StartCoroutine(Explode());
        }
	}


    // Process the explosion
    private IEnumerator Explode()
    {
        // it's exploding!
        isExploded = true;

        // disable the explosion sphere
        explosionGameObject.SetActive(true);

        // returns array of colliders within specified sphere
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        // check everything that the explosion hit
        foreach (Collider collider in hitObjects)
        {

            // we hit an enemy!
            if(collider.GetComponent<Enemy>() != null)
            {
                collider.GetComponent<Enemy>().Hit();
            }

        }

        yield return new WaitForSeconds(explosionDuration);

        Destroy(gameObject);

    }
}
