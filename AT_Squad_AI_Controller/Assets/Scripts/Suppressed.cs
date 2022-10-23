using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Suppressed : MonoBehaviour
{
    public NavMeshAgent nav_agent;

    public bool is_suppressed = false;
    private float default_speed = 0.0f;

    private void Start()
    {
        default_speed = nav_agent.speed;
    }

    private void Update()
    {
        if (is_suppressed)
        {
            SquadSuppressed();
        }
    }

    private void SquadSuppressed()
    {
        if (nav_agent.speed == default_speed)
        {
            nav_agent.speed = 1;
        }
        else if (nav_agent.speed != default_speed)
        {
            nav_agent.speed = default_speed;
        }
        
    }
}
