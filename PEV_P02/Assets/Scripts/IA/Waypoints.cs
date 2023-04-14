using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    Transform[] _waypoints;

    private int _index;
    private int _LastIndex = 0;

    private Vector3 CurrentTargetPos => _waypoints[_index].position; //dona la posició segons la posició del index

    private float _minDistanceToTarget = 0.1f; //si el player va ràpid, la distànciia ha de ser més gran perquè sino se la passa (radi)

    [SerializeField]
    float Speed = 3f;


    // Update is called once per frame
    void Update()
    {
        if (ReachedWaypoint()) //comprovar si ha arribat al waypoint
        {
            ChangeWaypoint();
        }
        Move();
    }

    private void Move()
    {
        transform.LookAt(CurrentTargetPos); //Ens movem en la direcció del target (posició del index), aixi només camina cap endevant
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void ChangeWaypoint()
    {
        _index = UnityEngine.Random.Range(1, 8); //Per canviar el waypoint es canvia el index

        if (_LastIndex == _index) //Si el ultimo numero de waipoint es diferente al numero nuevo
        {
            while (_LastIndex == _index)
            {
                _index = UnityEngine.Random.Range(1, 8);
            }
            _LastIndex = _index;
        }
        else
        {
            _LastIndex = _index;
        }
    }

    private bool ReachedWaypoint()
    {
        return Vector3.Distance(transform.position, CurrentTargetPos) < _minDistanceToTarget;
    }
}
