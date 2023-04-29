using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEdge: StateMachineBehaviour
{
    Transform _player;
    float _timer;

    public float DetectionDistance = 10;
    public float WaitTime = 3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Execute();
        CheckTriggers(animator);

    }

    private void Execute()
    {
        _timer += Time.deltaTime;
    }


    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
        animator.SetBool("IsChasing", isPlayerClose);

        bool timeUp = IsTimeUp();
        animator.SetBool("IsPatrolling", timeUp);
    }

    private bool IsTimeUp()
    {
        return _timer > WaitTime;
    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) < DetectionDistance;
    }




    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


}

