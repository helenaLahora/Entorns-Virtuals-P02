using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    public Transform[] _waypoints;

    //public IdleFSM idleFSM;

    private float _minDistanceToTarget = 0.1f;

    private float Speed = 50f;

    [SerializeField]
    private int _index;
    [SerializeField]
    private int _Last1index;
    [SerializeField]
    private int _Last2index;

    public Vector3 CurrentTargetPos => _waypoints[_index].position;


    Transform _player;
    float _timer;

    public float TimerIdle = 0;

    public float detectionDistance = 4f;
    public float WaitTimeWalk = 8f;

    //Vector3 _dir;

    public Animator _animator;


    private void Start()
    {
        //_dir = new Vector3();

        _player = GameObject.FindGameObjectWithTag("Player").transform; //dins de state enter sempre
        _timer = 0;
    }

    void Update()
    {
        CheckTriggers(_animator);
        Execute(_animator);
        
    }

    private void Execute(Animator animator)
    {
        _timer += Time.deltaTime; //augmentem el temps continuament

        //Vector3 displacement = _dir * Time.deltaTime;
        //transform.Translate(displacement);

        if (ReachedWaypoint())
        {
            Debug.Log("Reached " + Vector3.Distance(transform.position, CurrentTargetPos) + "   " + _index + "   " + CurrentTargetPos);
            ChangeWaypoint();
        }
        MoveToWaypoint();
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, _animator.transform);
        bool timeUp = IsTimeUp();

        TimerIdle = TimerIdle + 1;

        if (TimerIdle < 2)
        {
            animator.SetBool("IsPatrolling", !timeUp); //invertim el valor de patrolling a false quan el temps de wander s'ha acabat
            Speed = 0;
            _timer = 0;
        }
        else
        {
            Speed = 50f;
            animator.SetBool("IsChasing", isPlayerClose); //canvia d'animaci? segons si el personatge est? a prop dels enemics
        }
        

    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) < detectionDistance; //per saber si el player esta a prop de l'enemic
    }

    private bool IsTimeUp()
    {
        return _timer > WaitTimeWalk; //ho retorna si ?s m?s gran que el wait time
    }

    public bool ReachedWaypoint()
    {
        //Debug.Log(Vector3.Distance(transform.position, CurrentTargetPos));
        return Vector3.Distance(transform.position, CurrentTargetPos) //que nos de la distancia entre ("nuestra posicion", y "la posicion objetivo");
            < _minDistanceToTarget;
    }

    public void ChangeWaypoint()
    {
        _Last2index = _Last1index;
        _Last1index = _index;


        _index = UnityEngine.Random.Range(0, _waypoints.Length);
        //_index = _index % _waypoints.Length;

        while (_index == _Last2index || _index == _Last1index)
        {
            _index = UnityEngine.Random.Range(0, _waypoints.Length);
        }
    }

    public void MoveToWaypoint()
    {
        transform.LookAt(CurrentTargetPos); //esto es suficiente para que mire en la direccion que queremos que vaya
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}

