using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_NPC3 : StateMachineBehaviour
{
    Transform _player;
    Transform _enemy;

    float _timer;

    public float DetectionJump = 10;
    public float DetectionDmg = 10;
    public float WaitTime = 3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemy = GameObject.FindGameObjectWithTag("Enemies").transform;

        _timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Execute();
        CheckTriggers(animator);
    }

    private void Execute()
    {
        _timer += Time.deltaTime;
    }


    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
        animator.SetBool("Jump", isPlayerClose);

        bool timeUp = IsTimeUp();
        animator.SetBool("Walk", timeUp);

        if (Vector3.Distance(_player.position, _enemy.position) < DetectionDmg)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) //get mouse button down 0 = boto esq
            {
                animator.SetBool("Damage", true);
            }
        }
    }

    private bool IsTimeUp()
    {
        return _timer > WaitTime;
    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) < DetectionJump;
    }
}
