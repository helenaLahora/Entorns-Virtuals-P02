using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgePatrolling : StateMachineBehaviour
{
    Transform _player;

    [SerializeField]
    Transform CastPoint;

    [SerializeField]
    private LayerMask WhatIsGround;

    [SerializeField]
    float Speed = 30f;

    private float maxDistToGround = 20f;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (EdgeDetected())
        {
            Rotate();
        }
        else
        {
            Move();
        }
    }
    
    private void Move()
    {
        _player.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float rot = UnityEngine.Random.Range(90,270);
        _player.transform.Rotate(new Vector3(0, rot, 0));
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
