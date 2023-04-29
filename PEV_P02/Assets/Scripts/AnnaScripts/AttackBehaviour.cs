using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform _player;

    public float detectionDistance = 4;

    Vector3 posPlayer;
    public float Speed = 5;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform; //dins de state enter sempre
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute(animator);
        CheckTriggers(animator);
    }

    private void Execute(Animator animator)
    {
        animator.transform.LookAt(_player); //enemic mira a player

        posPlayer = new Vector3();
        posPlayer = _player.position;
        //direcció(e - p) = player - enemic
        Vector3 displacement = posPlayer * Speed * Time.deltaTime;
        animator.transform.Translate(displacement);
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
        animator.SetBool("IsChasing", isPlayerClose); //canvia d'animació segons si el personatge està a prop dels enemics
    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) < detectionDistance; //per saber si el player esta a prop de l'enemic
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
