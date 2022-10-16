using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;

public class Follow_Leader : MonoBehaviour
{
    public Moving_To_Cover mtc;
    public Moving_To_Cover mtc_y;

    public NavMeshAgent nav_agent;
    public Transform squad_leader;
    public Transform soldier;

    //public bool in_cover_x = false;

    public Vector3 offset = new Vector3(0, 0, 0);
    private Vector3 starting_offset;

    private void Start()
    {
        starting_offset = offset;
    }

    void Update()
    {
        nav_agent.SetDestination(squad_leader.position + offset);
        if (mtc_y.in_cover_y)
        {
            Debug.Log("In cover y");

            if (offset.y == 1)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(1, 0, 2);
            }

            if (offset.y == 2)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(1, 0, -2);
            }
        }
        else if (mtc.in_cover_x)
        {
            Debug.Log("In cover x");

            if (offset.x >= 1)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(3, 0, 0);
            }
            
            if (offset.x <= 1)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(-3, 0, 0);
            }
        }
        else
        {
            offset = starting_offset;
        }
    }
}