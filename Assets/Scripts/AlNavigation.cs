using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlNavigation : MonoBehaviour
{
    public Transform player;                  // Referencia al jugador
    public Transform[] patrolPoints;          // Puntos de patrullaje
    public float detectionRadius = 10f;       // Radio de detección del jugador
    public float patrolWaitTime = 2f;         // Tiempo de espera en cada punto de patrullaje
    public int damageAmount = 20;             // Daño que el policía inflige

    private NavMeshAgent agent;
    private int currentPatrolIndex;
    private float patrolWaitTimer;
    private bool isChasingPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        patrolWaitTimer = 0f;
        isChasingPlayer = false;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            patrolWaitTimer += Time.deltaTime;

            if (patrolWaitTimer >= patrolWaitTime)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPatrolIndex].position);
                patrolWaitTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vida vida = other.GetComponent<Vida>();
            if (vida != null)
            {
                vida.TakeDamage(damageAmount);
            }
        }
    }
}
