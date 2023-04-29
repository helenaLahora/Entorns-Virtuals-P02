using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointsss : StateMachineBehaviour
{

    Transform _player;

    public float DetectionDistance = 10;

    [SerializeField]
    public Transform[] _waypoints;

    [SerializeField]
    private float _minDistanceToTarget = 0.1f;


    private float Speed = 50f;

    [SerializeField]
    private int _index;
    [SerializeField]
    private int _Last1index;
    [SerializeField]
    private int _Last2index;

    private Vector3 CurrentTargetPos => _waypoints[_index].position;

    float _timer;
    public float WaitTime = 10;


    //______________________________________________________________________________________________________________________________________________//


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("EnemyWay").transform;
        _timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute(animator);
        CheckTriggers(animator);
    }

    private void Execute(Animator animator)
    {
        //Vector3 displacement = _direc * Speed * Time.deltaTime;
        //animator.transform.Translate(displacement);
        _timer += Time.deltaTime;

        if (ReachedWaypoint(animator))
        {
            ChangeWaypoint();
        }
        Move(animator);
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
        animator.SetBool("IsChasing", isPlayerClose);

        bool timeUp = IsTimeUp();
        animator.SetBool("IsPatrolling", !timeUp); //invertim el valor de patrolling a false quan el temps de wander s'ha acabat

    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) < DetectionDistance;
    }

    private bool IsTimeUp()
    {
        return _timer > WaitTime; //ho retorna si ?s m?s gran que el wait time
    }



    //______________________________________________________________________________________________________________________________________________________________//

    private bool ReachedWaypoint(Animator animator)
    {
        return Vector3.Distance(animator.transform.position, CurrentTargetPos) //que nos de la distancia entre ("nuestra posicion", y "la posicion objetivo");
            < _minDistanceToTarget;
    }

    private void ChangeWaypoint()
    {

        _Last2index = _Last1index;
        _Last1index = _index;

        _index = UnityEngine.Random.Range(0, _waypoints.Length);

        if (_index == _Last2index)
        {
            while (_index == _Last2index || _index == _Last1index)
            {
                _index = UnityEngine.Random.Range(0, _waypoints.Length);
            }
        }
    }

    private void Move(Animator animator)
    {

        animator.transform.LookAt(CurrentTargetPos); //esto es suficiente para que mire en la direccion que queremos que vaya
        animator.transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    }

}







