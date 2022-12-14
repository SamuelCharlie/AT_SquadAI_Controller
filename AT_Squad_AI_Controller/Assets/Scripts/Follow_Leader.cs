using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;

public class Follow_Leader : MonoBehaviour
{
    public Squad_Controller squad_controller;
    private Animator animator;

    public Moving_To_Cover mtc;
    public Moving_To_Cover mtc_y;

    public NavMeshAgent nav_agent;
    public Transform squad_leader;
    public Transform soldier;

    public bool sq_member_one = false;
    public bool sq_member_two = false;
    public bool sq_sprinting = false;
    public bool cls_guard = false;
    public bool far_guard = false;

    public Vector3 offset = new Vector3(0, 0, 0);
    private Vector3 starting_offset;

    private float sq_default_speed = 0.0f;

    private void Start()
    {
        starting_offset = offset;
        sq_default_speed = nav_agent.speed;
    }

    void Update()
    {
        nav_agent.SetDestination(squad_leader.position + offset);
        if (sq_sprinting)
        {
            IsSprinting();
        }
        else if (!sq_sprinting)
        {
            nav_agent.speed = sq_default_speed;
        }

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

            if (offset.y == 2)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(3, 0, 0);
            }
            
            if (offset.y == 1)
            {
                Debug.Log("Moving to Cover");
                offset = new Vector3(-3, 0, 0);
            }
        }
        else if (cls_guard)
        {
            GuardClose();
        }
        else if (far_guard)
        {
            GuardFar();
        }
        else
        {
            offset = starting_offset;
        }
    }

    public void GuardClose()
    {
        if (sq_member_one)
        {
            offset = new Vector3(-1, 2, 1/2);
        }
        else if (sq_member_two)
        {
            offset = new Vector3(-1, 2, 1 / 2);
        }
    }

    public void GuardFar()
    {
        if (sq_member_one)
        {
            offset = new Vector3(-3, 2, 2);
        }
        else if (sq_member_two)
        {
            offset = new Vector3(-3, 2, -2);
        }
    }

    public void IsSprinting()
    {
        nav_agent.speed = 8;
    }
}