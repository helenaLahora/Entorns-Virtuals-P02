using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{

    [SerializeField]
    Transform[] _waypoints;

    [SerializeField]
    float Speed = 5;

    private int _index;
    private Vector3 CurrentTargetPos => _waypoints[_index].position;
    private float _minDistanceToTarget = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (ReachedWaypoint())
        {
            ChangeWayPoint();
        }
        Move();
    }

    private void ChangeWayPoint()
    {
        _index++;
        _index = _index % _waypoints.Length;
    }

    private bool ReachedWaypoint()
    {
        return Vector3.Distance(transform.position, CurrentTargetPos) < _minDistanceToTarget;
    }

    private void Move()
    {
        transform.LookAt(CurrentTargetPos);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
