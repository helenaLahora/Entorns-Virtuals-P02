using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Salto : MonoBehaviour
{
    // ES CREEN TOTS ELS VALORS NECESSARIS PER A QUE APAREGUIN EN PANTALLA I ES PUGUIN MODIFICAR
    [Header("Jump Parameters")]
    [SerializeField]
    private float JumpHeight = 15;

    [SerializeField]
    private float JumpTime = 0.4f;



    [Header("Radi Empty Object")]
    //[SerializeField]
    //private float radi = 0.1f;

    private Vector3 velocitys = new Vector3(0, 0, 0);

    private bool doubleJump;


    [Range(-2, 2)] //ens dona un slider a escollir entre les variables escollides


    [Header("Scripts")]
    //AGAFEM ELS VALORS QUE NECESSITEM D'ALTRES SCRIPTS
    CharacterController _charactercontroler;

  //  PlayAnimation _playAnimation;

    [SerializeField]
    InputSystem input;

    [SerializeField]
    Movement movemento;


    [SerializeField]
    LayerMask WhatIsGround; // Apareix en pantalla de Unity l'opció de seleccionar quina capa és amb la que reaccionarà el Empty (el que farem servir com a terra)

    //[SerializeField]
    //Transform GroundChecker; // Apareix en pantalla de Unity la opció de assignar que serà el GROUNDCHECKER (és on assignem el CreateEmpty que serveix de punt per detectar el terra)



    private float _gravityScale=5f;

    private float _lastVelocitys;


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private void FixedUpdate()
    {
        ApplyGravity();

        if (PeakReached()) //ho aplica quan arriba a dalt de tot del salt
        {
            TweakGravity();
        }

        _lastVelocitys = velocitys.y;
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private bool PeakReached() //s'arriba al punt mÉs alt quan la velocitat passa de ser positiva a negativa
    {
        return (velocitys.y * _lastVelocitys) < 0;
    }

    private void ApplyGravity()
    {
        if(_charactercontroler.isGrounded)
        {
            velocitys.y = Mathf.Max(0, velocitys.y); //La velocitat en y no serà menor de 0 o major de la velocitat actual de y
            return;
        }

        Vector3 velocity = velocitys; //velocitat que tenim actualment
        velocity += Physics.gravity * _gravityScale * Time.fixedDeltaTime; //fixedDeltaTime ?s el time entre fixedupdate i fixedupdate
        velocitys = velocity; //la velocitat del rigidbody ?s la que acabem de dir
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private void Start()
    {
        _charactercontroler = GetComponent<CharacterController>();
       // _playAnimation = GetComponent<PlayAnimation>();
    }

    public void Update()
    {
        if (Jumps() && _charactercontroler.isGrounded) // Si es prem la tecla "Espai" i el personatge està tocant el terra salta 
        {
            Jump();
            doubleJump = true; // Aquesta variable passa a ser veritat (la volem per a permetre el doble salt)
        }
        else if(Jumps() && doubleJump) // Si s'ha premut la tecla "Espai" i la variable anterior és veritat (vol dir que hi ha hagut un salt previ), es permet fer un segon salt sense necessitat de tocar el terra
        {
            Jump();
            doubleJump = false; // Al acabar el segon salt posem la variable en fals per a no permetre més de dos salts seguits
        }

    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    public bool Jumps()
    {
        return input.Controles_J; // S'ha apretat la tecla space? Doncs llavors ha saltat
                                  // Control adquirit del SCRIPT InputSystem
    }


    private void Jump()
    {
        Vector3 velocity = new Vector3(movemento._lastVelocity_X, GetJumpSpeed(), movemento._lastVelocity_Z); //ficant la velocitat que té en x farà que no salti recte cap amunt i segueixi el moviment
        velocitys = velocity;

        AdjustGravity();

        //_playAnimation.setanimationjump(velocitys.y); //envio a playanimation la velocitat del salt
    }


    //public bool IsGrounded()
    //{
    //    return Physics.CheckSphere(GroundChecker.position, radi, WhatIsGround); // El que fa es detectar que hi ha dins del personatge, osigui que si el Empty està en contacte amb la capa de GROUND
    //}


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private void AdjustGravity()
    {
        float gravity = -2 * JumpHeight / (JumpTime * JumpTime); //gravetat que volem que actui sobre l'objecte
        _gravityScale = gravity / Physics.gravity.y; //gravity scale és la gravetat de l'objecte entre la gravetat que li hem dit abans
    }

    private void TweakGravity() //quan arriba al punt més alt del salt multiplica la gravetat *2 perquè caigui més ràpid
    {
        _gravityScale *= 2;
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private float GetJumpSpeed()
    {
        return 2 * JumpHeight / JumpTime;
    }



//_________________________________________________________________________________________________________________________________________________________________________________________//


    public float GetVelocity()
    {
        return velocitys.y;
    }

}
