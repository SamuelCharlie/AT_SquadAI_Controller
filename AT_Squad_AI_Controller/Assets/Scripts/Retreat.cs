using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Retreat : MonoBehaviour
{
    public NavMeshAgent nav_agent;
    public Transform rally_transform;

    public bool retreating = false;

    private void Update()
    {
        if (retreating)
        {
            SquadRetreat();
        }
    }

    private void SquadRetreat()
    {
        nav_agent.SetDestination(rally_transform.position);
    }
}
