using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_NPC3 : StateMachineBehaviour
{
    Transform _player;
    Transform _enemy;

    public float DetectionDmg = 10;

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
        _enemy.LookAt(_player);
        animator.SetBool("Damage", true);
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayerClose = IsPlayerClose(_player, animator.transform);
        animator.SetBool("Damage", isPlayerClose);
    }

    private bool IsPlayerClose(Transform player, Transform mySelf)
    {
        return Vector3.Distance(player.position, mySelf.position) > DetectionDmg;
    }
}
