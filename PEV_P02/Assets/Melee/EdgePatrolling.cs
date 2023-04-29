using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgePatrolling : StateMachineBehaviour
{
    Transform _player;
    Transform _enemy;
    float _timer;

    Transform CastPoint;

    [SerializeField]
    private LayerMask WhatIsGround;

    [SerializeField]
    float Speed = 30f;

    private float maxDistToGround = 20f;

    public float DetectionDistance = 10;
    public float WaitTime = 3;

    
    //______________________________________________________________________________________________________________________________________________________________//


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemy = GameObject.FindGameObjectWithTag("EnemyEdge").transform;

        CastPoint = GameObject.FindGameObjectWithTag("Castpoints").transform;

        _timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute(animator);
        CheckTriggers(animator);
    }
    
    //______________________________________________________________________________________________________________________________________________________________//

    private void Execute(Animator animator)
    {
        _timer += Time.deltaTime;

        if (EdgeDetected())
        {
            Rotate();
        }
        else
        {
            Move();
        }
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
        return _timer > WaitTime;
    }
    
    //______________________________________________________________________________________________________________________________________________________________//

    private void Move()
    {
        _enemy.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float rot = UnityEngine.Random.Range(90,270);
        _enemy.transform.Rotate(new Vector3(0, rot, 0));
    }

    private bool EdgeDetected()
    {
        if (Physics.Raycast(CastPoint.position, Vector3.down, maxDistToGround, WhatIsGround))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
