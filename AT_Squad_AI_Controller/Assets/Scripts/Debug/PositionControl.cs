using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Position_Control : MonoBehaviour
{
    public NavMeshAgent nav_agent;
    public Transform soldier;

    public Vector3 offset = new Vector3(0, 0, 0);

    private void Update()
    {
        soldier.transform.position = offset;
        nav_agent.SetDestination(offset);
    }
}
