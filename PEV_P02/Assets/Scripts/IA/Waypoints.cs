using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    [SerializeField]
    Transform[] _waypoints;


    private float _minDistanceToTarget = 0.1f;


    private float Speed = 50f;

    [SerializeField]
    private int _index;
    [SerializeField]
    private int _Last1index;
    [SerializeField]
    private int _Last2index;


    private Vector3 CurrentTargetPos => _waypoints[_index].position;


    void Update()
    {
        if (ReachedWaypoint())
        {
            Debug.Log("Reached " + Vector3.Distance(transform.position, CurrentTargetPos)+"   "+_index +"   "+ CurrentTargetPos);
            ChangeWaypoint();
        }
        Move();
    }

    private bool ReachedWaypoint()
    {
        //Debug.Log(Vector3.Distance(transform.position, CurrentTargetPos));
        return Vector3.Distance(transform.position, CurrentTargetPos) //que nos de la distancia entre ("nuestra posicion", y "la posicion objetivo");
            < _minDistanceToTarget;
    }

    private void ChangeWaypoint()
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

    private void Move()
    {

        transform.LookAt(CurrentTargetPos); //esto es suficiente para que mire en la direccion que queremos que vaya
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    }
}

