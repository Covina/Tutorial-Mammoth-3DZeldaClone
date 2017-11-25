using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour {

    [Header("Object")]
    public NavMeshAgent agent;
    public Animator enemyAnimator;
    public GameObject enemyTarget;

    [Header("Movement")]
    public float movementRadius = 15f;
    public float movementUpdateTimer = 15f;
    public float movementUpdateDuration = 3f;
    private Vector3 previousPosition;

    [Header("Attack")]
    public float attackRadius = 3f;
    public float attackUpdateDuration = 1f;
    public float attackUpdateTimer;
    private bool isAttacking = false;


    private Vector3 originalPosition;

    private Vector3 originalEnemyAnimatorPosition;

    private void Awake()
    {
        previousPosition = transform.position;
        originalEnemyAnimatorPosition = enemyAnimator.transform.localPosition;

    }


    // Use this for initialization
    void Start () {

        originalPosition = transform.position;

        MoveAroundStart();

        movementUpdateTimer = movementUpdateDuration;

        attackUpdateTimer = attackUpdateDuration;
	}
	

	// Update is called once per frame
	void Update () {

        // Patrol around
        if(isAttacking == false) {
            movementUpdateTimer -= Time.deltaTime;
            if (movementUpdateTimer <= 0f)
            {
                MoveAroundStart();
                movementUpdateTimer = movementUpdateDuration;
            }
        }

        // Search for Player
        attackUpdateTimer -= Time.deltaTime;
        if(attackUpdateTimer <= 0f)
        {
            attackUpdateTimer = attackUpdateDuration;
            SearchPlayer();
        }

       
        if(agent.velocity.magnitude > 0 )
        {
            // Play the walking animation
            enemyAnimator.SetFloat("Forward", 0.6f);

        } else
        {
            // Play the walking animation
            enemyAnimator.SetFloat("Forward", 0.0f);

        }


    }

    private void MoveAroundStart()
    {
        agent.SetDestination(originalPosition + new Vector3(
                Random.Range(-movementRadius, movementRadius),
                0,
                Random.Range(-movementRadius, movementRadius)
                )
            );
    }


    // Update is called once per frame
    void LateUpdate()
    {

        enemyAnimator.transform.localPosition = originalEnemyAnimatorPosition;

    }

    /// <summary>
    /// Look for the player
    /// </summary>
    private void SearchPlayer()
    {
        isAttacking = false;

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRadius, transform.forward);
        foreach(RaycastHit hit in hits)
        {
            if(hit.transform.GetComponent<Player>() != null)
            {
                // Set to target player
                agent.SetDestination(hit.transform.position);
                isAttacking = true;
                break;
            }

        }

    }

}
