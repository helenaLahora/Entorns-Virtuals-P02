using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class enemyWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public int actualWaypoint;
    public float Speed;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        actualWaypoint = 0;
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[actualWaypoint].position);
        }
    }

    void Update()
    {
        agent.speed = Speed;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            actualWaypoint++;
            if (actualWaypoint >= waypoints.Length)
                actualWaypoint = 0;

            agent.SetDestination(waypoints[actualWaypoint].position);
        }
    }
}
