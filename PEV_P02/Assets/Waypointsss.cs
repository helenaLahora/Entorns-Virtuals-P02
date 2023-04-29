//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Waypointss : StateMachineBehaviour
//{
//    //    [SerializeField]
//    //    Transform[] _waypoints;

//    //    Transform _player;
//    //    float _timer;

//    //    public float detectionDistance = 4;
//    //    public float WaitTime = 3;

//    //    Vector3 _dir;

//    //    private float _minDistanceToTarget = 0.1f;


//    //    private float Speed = 50f;

//    //    [SerializeField]
//    //    private int _index;
//    //    [SerializeField]
//    //    private int _Last1index;
//    //    [SerializeField]
//    //    private int _Last2index;

//    //    //private Vector3 CurrentTargetPos => _waypoints[_index].position;
//    //    private Vector3 CurrentTargetPos
//    //    {
//    //        get
//    //        {
//    //            if (_player != null && IsPlayerClose(_player, _player.transform))
//    //            {
//    //                return _player.position;
//    //            }
//    //            else
//    //            {
//    //                return _waypoints[_index].position;
//    //            }
//    //        }
//    //    }


//    //    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    //    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    _dir = new Vector3();

//    //    _player = GameObject.FindGameObjectWithTag("Player").transform;
//    //    _timer = 0;

//    //    _index = UnityEngine.Random.Range(0, _waypoints.Length);
//    //    _Last1index = -1;
//    //    _Last2index = -1;
//    //}

//    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    Execute(animator);
//    //    CheckTriggers(animator);

//    //    if (ReachedWaypoint())
//    //    {
//    //        ChangeWaypoint();
//    //    }
//    //    Move();
//    //}

//    //private void Execute(Animator animator)
//    //{
//    //    _timer += Time.deltaTime;

//    //    Vector3 displacement = _dir * Time.deltaTime;
//    //    animator.transform.Translate(displacement);
//    //}

//    //private void CheckTriggers(Animator animator)
//    //{
//    //    bool isPlayerClose = IsPlayerClose(_player, animator.transform);
//    //    animator.SetBool("IsChasing", isPlayerClose);

//    //    bool timeUp = IsTimeUp();
//    //    animator.SetBool("IsPatrolling", !timeUp);
//    //}

//    //private bool IsPlayerClose(Transform player, Transform mySelf)
//    //{
//    //    return player != null && Vector3.Distance(player.position, mySelf.position) < detectionDistance;
//    //}

//    //private bool IsTimeUp()
//    //{
//    //    return _timer > WaitTime;
//    //}

//    //private bool ReachedWaypoint()
//    //{
//    //    return Vector3.Distance(_player.transform.position, CurrentTargetPos)
//    //        < _minDistanceToTarget;
//    //}

//    //private void ChangeWaypoint()
//    //{
//    //    _Last2index = _Last1index;
//    //    _Last1index = _index;

//    //    _index = UnityEngine.Random.Range(0, _waypoints.Length);

//    //    while (_index == _Last2index || _index == _Last1index)
//    //    {
//    //        _index = UnityEngine.Random.Range(0, _waypoints.Length);
//    //    }
//    //}

//    //private void Move()
//    //{
//    //    _player.transform.LookAt(CurrentTargetPos);
//    //    _player.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
//    //}




//    Transform _player;

//    //public Waypoints wp;
//    public Transform[] wpPositions;
//    float _timer;

//    public float detectionDistance = 4;
//    public float WaitTime = 3;

//    Vector3 _dir;


//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        _dir = new Vector3();
//        // _dir.x = Random.Range(-1f, 1f);
//        //_dir.y = 0;
//        //_dir.z = Random.Range(-1f, 1f);

//        _player = GameObject.FindGameObjectWithTag("Player").transform; //dins de state enter sempre
//        //wp = _player.GetComponent<Waypoints>();
//        //wpPositions = wp._waypoints;

//        _timer = 0;
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        Execute(animator);
//        CheckTriggers(animator);        
//    }

//    private void Execute(Animator animator)
//    {
//        _timer += Time.deltaTime; //augmentem el temps continuament

//        Vector3 displacement = _dir * Time.deltaTime;
//        animator.transform.Translate(displacement);
//    }

//    private void CheckTriggers(Animator animator)
//    {
//        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
//        animator.SetBool("IsChasing", isPlayerClose); //canvia d'animaci? segons si el personatge est? a prop dels enemics

//        bool timeUp = IsTimeUp();
//        animator.SetBool("IsPatrolling", !timeUp); //invertim el valor de patrolling a false quan el temps de wander s'ha acabat
//    }

//    private bool IsPlayerClose(Transform player, Transform mySelf)
//    {
//        return Vector3.Distance(player.position, mySelf.position) < detectionDistance; //per saber si el player esta a prop de l'enemic
//    }

//    private bool IsTimeUp()
//    {
//        return _timer > WaitTime; //ho retorna si ?s m?s gran que el wait time
//    }
//}





using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointsss : StateMachineBehaviour
{

    Transform _player;

    public float DetectionDistance = 10;

    Transform[] _waypoints;

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
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _timer = 0;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Waypoints");

        _waypoints = new Transform[gameObjects.Length];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            _waypoints[i] = gameObjects[i].transform;
        }
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







