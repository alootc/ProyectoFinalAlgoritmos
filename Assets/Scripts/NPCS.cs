using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCS : MonoBehaviour
{
    public Transform[] targets;
    private int index;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 0;
        agent.SetDestination(targets[index].position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targets[index].position) < 0.1f)
        {
            index++;
            if (index >= targets.Length) index = 0;
            agent.SetDestination(targets[index].position);
        }
    }
}
