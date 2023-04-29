//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IdleFSM : StateMachineBehaviour
//{
//    Transform _player;
//    public float _timerIdle;

//    public float detectionDistance = 4;
//    public float WaitTimeIdle = 2;


//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        _player = GameObject.FindGameObjectWithTag("Player").transform; //dins de state enter sempre
//        _timerIdle = 0;
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        Execute();
//        CheckTriggers(animator);
//    }

//    private void Execute()
//    {
//        _timerIdle += Time.deltaTime; //augmentem el temps continuament
//    }

//    private void CheckTriggers(Animator animator)
//    {
//        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
//        animator.SetBool("IsChasing", isPlayerClose); //canvia d'animaci? segons si el personatge est? a prop dels enemics

//        bool timeUp = IsTimeUp();
//        animator.SetBool("IsPatrolling", timeUp); //canvia d'animaci? segons el wait time
//    }

//    private bool IsTimeUp()
//    {
//        return _timerIdle > WaitTimeIdle; //ho retorna si ?s m?s gran que el wait time
//    }

//    private bool IsPlayerClose(Transform player, Transform mySelf)
//    {
//        return Vector3.Distance(player.position, mySelf.position) < detectionDistance; //per saber si el player esta a prop de l'enemic
//    }
//}

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
        _player = GameObject.FindGameObjectWithTag("EnemyEdge").transform;
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

