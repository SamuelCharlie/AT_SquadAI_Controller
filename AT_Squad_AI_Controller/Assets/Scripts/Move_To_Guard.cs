using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_To_Guard : MonoBehaviour
{
    Squad_Controller squad_controller;
    Follow_Leader follow_leader;

    public NavMeshAgent nav_agent;

    public bool sq_member_one = false;
    public bool sq_member_two = false;

    public bool cls_guard = false;
    public bool far_guard = false;

    public Vector3 current_pos = new Vector3(0, 0, 0);
    private Vector3 default_pos;

    private void Start()
    {
        follow_leader = GetComponent<Follow_Leader>();
    }

    void Update()
    {
        if (cls_guard)
        {
            GuardClose();
        }
        else if (far_guard)
        {
            GuardFar();
        }
    }

    public void GuardClose()
    {
        follow_leader.enabled = !follow_leader.enabled;
        if (sq_member_one)
        {
            current_pos = new Vector3(2, 2, -1);
            nav_agent.SetDestination(current_pos);
        }
    }

    public void GuardFar()
    {

    }
}
