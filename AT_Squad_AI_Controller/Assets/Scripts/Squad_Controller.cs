using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;

public class Squad_Controller : MonoBehaviour
{
    SquadInput squad_input;
    private CharacterController squad_controller;

    public NavMeshAgent nav_agent;
    public Camera player_cam;
    public GameObject player;

    public Vector2 mouse_pos;
    //public Vector3 hit_point;

    private void Awake()
    {
        squad_input = new SquadInput();
    }

    private void OnEnable()
    {
        squad_input.SquadController.Enable();
        squad_input.SquadController.Move.started += DoMove;
    }

    private void OnDisable()
    {
        squad_input.SquadController.Disable();
        squad_input.SquadController.Move.started -= DoMove;
    }
    void Update()
    {
        mouse_pos = Mouse.current.position.ReadValue();
    }

    private void DoMove(InputAction.CallbackContext obj)
    {
        Ray ray = player_cam.ScreenPointToRay(mouse_pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            nav_agent.SetDestination(hit.point);
        }
    }
}
