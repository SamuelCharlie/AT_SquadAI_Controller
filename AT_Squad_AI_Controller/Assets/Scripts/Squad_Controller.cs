using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.AI;
using System;

public class Squad_Controller : MonoBehaviour
{
    SquadInput squad_input;

    public Retreat retreat;
    public Suppressed suppressed;
    public Follow_Leader follow_leader_sq_one;
    public Follow_Leader follow_leader_sq_two;
    public Game_State_Controller game_state;

    private CharacterController squad_controller;
    private Animator animator;
    public Rigidbody rb;

    public NavMeshAgent nav_agent;
    public Camera player_cam;
    public GameObject player;
    public Transform nearest_cover;

    public Vector2 mouse_pos;
    public Vector3 hit_point;

    public bool squad_moving = false;
    private float default_speed = 0.0f;

    private void Awake()
    {
        squad_input = new SquadInput();
        animator = GetComponent<Animator>();
        default_speed = nav_agent.speed;
    }

    private void OnEnable()
    {
        squad_input.SquadController.Enable();
        squad_input.SquadController.Move.started += DoMove;
        squad_input.SquadController.Retreat.started += DoRetreat;
        squad_input.SquadController.Suppressed.started += Suppressed;
        squad_input.SquadController.CloseGuard.started += DoCloseGuard;
        squad_input.SquadController.FarGuard.started += DoFarGuard;
        squad_input.SquadController.CombatState.started += CombatStateChange;

        squad_input.SquadController.DoubleMove.performed += DoDoubleMove;
    }

    private void OnDisable()
    {
        squad_input.SquadController.Disable();
        squad_input.SquadController.Move.started -= DoMove;
        squad_input.SquadController.Retreat.started -= DoRetreat;
        squad_input.SquadController.Suppressed.started -= Suppressed;
        squad_input.SquadController.CloseGuard.started -= DoCloseGuard;
        squad_input.SquadController.FarGuard.started -= DoFarGuard;
        squad_input.SquadController.CombatState.started -= CombatStateChange;

        squad_input.SquadController.DoubleMove.performed -= DoDoubleMove;
    }
    

    void Update()
    {
        mouse_pos = Mouse.current.position.ReadValue();

        if(nav_agent.remainingDistance > 0.1f)
        {
            squad_moving = true;
            animator.SetBool("is_running", true);
        }
        else if (nav_agent.remainingDistance < 0.1f)
        {
            squad_moving = false;
            nav_agent.speed = default_speed;
            follow_leader_sq_one.sq_sprinting = false;
            follow_leader_sq_two.sq_sprinting = false;
            animator.SetBool("is_running", false);
        }
    }

    private void DoMove(InputAction.CallbackContext obj)
    {
        Ray ray = player_cam.ScreenPointToRay(mouse_pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hit_point = hit.point;
            nav_agent.SetDestination(hit_point);
        }
    }

    private void DoRetreat(InputAction.CallbackContext obj)
    {
        if (nav_agent.remainingDistance < 0.1f)
        {
            if (nav_agent.speed == default_speed)
            {
                nav_agent.speed = 8;
            }
            else if (nav_agent.speed != default_speed)
            {
                nav_agent.speed = default_speed;
            }
            retreat.retreating = !retreat.retreating;
        }
    }

    private void Suppressed(InputAction.CallbackContext obj)
    {
        suppressed.is_suppressed = !suppressed.is_suppressed;
    }

    private void DoCloseGuard(InputAction.CallbackContext obj)
    {
        follow_leader_sq_one.cls_guard = !follow_leader_sq_one.cls_guard;
        follow_leader_sq_two.cls_guard = !follow_leader_sq_two.cls_guard;
    }

    private void DoFarGuard(InputAction.CallbackContext obj)
    {
        follow_leader_sq_one.far_guard = !follow_leader_sq_one.far_guard;
        follow_leader_sq_two.far_guard = !follow_leader_sq_two.far_guard;
    }

    private void DoDoubleMove(InputAction.CallbackContext obj)
    {
        Debug.Log("Double Tap");

        if (!game_state.combat_state)
        {
            Ray ray = player_cam.ScreenPointToRay(mouse_pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                hit_point = hit.point;
                follow_leader_sq_one.sq_sprinting = true;
                follow_leader_sq_two.sq_sprinting = true;
                nav_agent.speed = 8;
                nav_agent.SetDestination(hit_point);
            }
        }
        else if (game_state.combat_state)
        {
            nav_agent.SetDestination(nearest_cover.position);
        }   
    }

    private void CombatStateChange(InputAction.CallbackContext obj)
    {
        game_state.combat_state = !game_state.combat_state;
        Debug.Log(game_state.combat_state);
    }

}
