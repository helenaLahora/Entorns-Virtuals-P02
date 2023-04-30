using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MelePlayer : MonoBehaviour
{
    [SerializeField]
    InputSystem input;

    [SerializeField]
    Animator _animator;

    //public LayerMask Shootable;

    CharacterController _charactercontroler;



    // Start is called before the first frame update
    void Start()
    {
        _charactercontroler = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Meles())
        {
            Debug.Log("mele");
            AttackMele();
        }
        else
        {
            _animator.SetBool("Attack", false);
        }        
    }

    private bool Meles()
    {
        return input.Controles_E;
    }

    private void AttackMele()
    {
        _animator.SetBool("Attack", true);
    }
}
