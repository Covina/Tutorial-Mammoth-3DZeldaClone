using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy {

    public Animator enemyAnimator;

    private Vector3 originalEnemyAnimatorPosition;

	// Use this for initialization
	void Start () {

        // Play the walking animation
        enemyAnimator.SetFloat("Forward", 0.3f);

        originalEnemyAnimatorPosition = enemyAnimator.transform.localPosition;


    }
	
	// Update is called once per frame
	void LateUpdate () {

        enemyAnimator.transform.localPosition = originalEnemyAnimatorPosition;

    }
}
