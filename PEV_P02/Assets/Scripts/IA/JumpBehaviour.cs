using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : StateMachineBehaviour
{
    Transform _player;
    Transform _enemy;

    public float DetectionJump = 10;
    public float DetectionDmg = 10;


    //______________________________________________________________________________________________________________________________________________________________//


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemy = GameObject.FindGameObjectWithTag("Enemies").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute(animator);
        CheckTriggers(animator);
    }

    private void Execute(Animator animator)
    {
        
    }

    private void CheckTriggers(Animator animator)
    {        
        bool isPlayerClose = doJump(_player, animator.transform);
        animator.SetBool("Jump", isPlayerClose);

        if (Vector3.Distance(_player.position, _enemy.position) < DetectionDmg)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) //get mouse button down 0 = boto esq
            {
                animator.SetBool("Damage", true);
            }
        }
    }

    private bool doJump(Transform player, Transform mySelf)
    {
        return Vector3.Distance(_player.position, _enemy.position) > DetectionJump;
    }
}
