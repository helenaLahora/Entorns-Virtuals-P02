using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class attack : StateMachineBehaviour
{
    Transform _player;

    public float detectionDistance = 30;

    [SerializeField]
    private float _minDistanceToTarget = 0.1f;

    Vector3 posPlayer;

    public float Speed = 5f;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute(animator);
        CheckTriggers(animator);
    }

    private void Execute(Animator animator)
    {
        animator.transform.LookAt(_player);
        Debug.Log("before attack");
        if (ReachedPlayer(animator.transform, _player))
        {
            Debug.Log("attack");
            animator.transform.position += animator.transform.forward * Speed * Time.deltaTime;

            //posPlayer = new Vector3();
            //posPlayer = _player.position;
            //ChangePos(_player);
        }
        //animator.transform.LookAt(posPlayer); //esto es suficiente para que mire en la direccion que queremos que vaya
        //animator.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //Move(animator);
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

//______________________________________________________________________________________________________________________________________________________________//

    private bool ReachedPlayer(Transform mySelf, Transform player)
    {
        //que nos de la distancia entre ("nuestra posicion", y "la posicion objetivo");
        return Vector3.Distance(mySelf.position, player.position) >= _minDistanceToTarget;
    }

    //private void ChangePos(Transform player)
    //{
    //    posPlayer = new Vector3();
    //    posPlayer = _player.position;
    //}

    //private void Move(Animator animator)
    //{
    //    animator.transform.LookAt(posPlayer); //esto es suficiente para que mire en la direccion que queremos que vaya
    //    animator.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    //}
}
