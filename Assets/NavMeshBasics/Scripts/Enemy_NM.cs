using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_NM : MonoBehaviour
{    
    [SerializeField] private NavMeshAgent agent;    // for moving on the NavMesh
    [SerializeField] private Transform target;      // the target to follow

    private float distanceToTarget = float.MaxValue;    // distance to target - default to far away
    private float chaseRange = 10f;                     // when target is closer than this, chase!
    private float attackRange = 2.0f;
    private enum EnemyState { IDLE, CHASE, ATTACK };
    private EnemyState state;

   /* void Update()
    {
        agent.SetDestination(target.transform.position);  // follow the target
    }*/


    private void SetState(EnemyState newState)
    {
        state = newState;
    }

    void Start()
    {
        SetState(EnemyState.IDLE);      // start off in the IDLE state
    }

    void Update()
    {
        distanceToTarget  = Vector3.Distance(transform.position, target.position);
        // what happens here depends on the state we're currently in!
        switch (state)
        {
            case EnemyState.IDLE: Update_Idle(); break;
            case EnemyState.CHASE: Update_Chase(); break;
            case EnemyState.ATTACK: Update_Attack(); break;
            default: Debug.Log("Invalid state!"); break;
        }
    }

    void Update_Idle()
    {
        agent.isStopped = true;                             // stop the agent (following)
        if(distanceToTarget <= chaseRange)
        {
            SetState(EnemyState.CHASE);
        }
    }

    void Update_Chase()
    {
        agent.isStopped = false;                            // start the agent (following)
        agent.SetDestination(target.transform.position);    // follow the target
        if(distanceToTarget > chaseRange)
        {
            SetState(EnemyState.IDLE);
        }
        if (distanceToTarget <= attackRange)
        {
            SetState(EnemyState.ATTACK);
        }
    }

    void Update_Attack()
    {
        Debug.Log("Attacking player"); // Print out "attacking player" to console
        if (distanceToTarget > attackRange) // Transition to CHASE state when player is out of attack range
        {
            SetState(EnemyState.CHASE);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);  // draw a circle to show chase range

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
