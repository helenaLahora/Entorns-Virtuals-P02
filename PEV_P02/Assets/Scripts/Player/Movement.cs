using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //ES MOLT NECESSARI POSAR AIXÒ
                               // Serveix per a poder connectar el codi amb el InputSystem de Unity

public class Movement : MonoBehaviour
{
    // ES CREEN TOTS ELS VALORS NECESSARIS PER A QUE APAREGUIN EN PANTALLA I ES PUGUIN MODIFICAR

    [Header("Velocitats")]
    [SerializeField]
    float WalkingSpeed = 9f;

    [SerializeField]
    float RotaionSpeed = 250f;


    [Header("Smoothing")]
    [SerializeField]
    private float smoothing_Ground = 0.15f;

    [SerializeField]
    private float smoothing_Air = 0.15f;


    [Header("Scripts")]
    //AGAFEM ELS VALORS QUE NECESSITEM D'ALTRES SCRIPTS
    [SerializeField]
    InputSystem input; // IMPORTANT --> Ens conecta aquest script amb el SCRIPT InputSystem, per a poder agafar els inputs de moviment

    //[SerializeField]
    //camara Camera;

    [SerializeField]
    Salto saltito;


    [Header("Paràmetres per altres Scripts")]
    public float _lastVelocity_Y;
    public float _lastVelocity_X;
    public float _lastVelocity_Z;

    public float _jumpspeed;

    private Vector3 velocity = new Vector3(0, 0, 0); // Es crea el valor nou "velocity" que serà un Vector3




    //PlayAnimation _playAnimation;

    CharacterController _charactercontroler; // Creant una variable de tipus Character Controller


    //_________________________________________________________________________________________________________________________________________________________________________________________//


    private void FixedUpdate() 
    {
        Move(input.Controles_H, input.Controles_V); // Agafa els dos vectors que he transformat en OnMove() --> els valors dels vectors de x/y
                                                    // Aquests vectors els agafem dels SCRIPT InputSystem
    }


    // Start is called before the first frame update
    void Start()
    {
        // El GetComponent agafa el Character Controller del personatge i comprova alhora de que està posat al personatge
        _charactercontroler = GetComponent<CharacterController>();
        //_playAnimation = GetComponent<PlayAnimation>();
    }


    //_________________________________________________________________________________________________________________________________________________________________________________________//

    public void Move(float horizontal, float vertical) // Agafem 
    {
        Vector3 OGmove = new Vector3(WalkingSpeed * horizontal, 0, WalkingSpeed * vertical); // Crees un Vector3 que ajunta tots els valors float en una sola variable


        //LENA
        // Converteix la direcció OGmove de l'espai mundial a l'espai local del jugador
        //OGmove = transform.TransformDirection(OGmove);


        float targetVelocity_x = OGmove.x * WalkingSpeed; // El que fa es crear una acceleració (que desprès fem servir pel smoothing)
        float targetVelocity_z = OGmove.z * WalkingSpeed;

        float smoothing = _charactercontroler.isGrounded ? smoothing_Ground : smoothing_Air; // Quan el personatge ESTÀ tocant el terra, s'assigna el smoothing de ground
                                                                                             // Quan el personatge NO ESTÀ tocant el terra, s'assigna el smoothing del aire

        velocity.x = Mathf.Lerp(_lastVelocity_X, targetVelocity_x, smoothing); // ** Quan més gran sigui smoothing més lent anirà **
        velocity.y = Mathf.Lerp(_lastVelocity_Y, saltito.GetVelocity(), smoothing); // Agafem la ultima velocitat que teniem, la substituim per la nova, i aquesta nova la multipliquem per el smoothing que pertoca
        velocity.z = Mathf.Lerp(_lastVelocity_Z, targetVelocity_z, smoothing);

        if (velocity != Vector3.zero)
        {
            _charactercontroler.Move(velocity * Time.fixedDeltaTime); // Time.deltaTime ---> Dona els valors de velocitat a velocity
        }

        if (OGmove != Vector3.zero) // per corretgir el bug Look rotation viewing is zero, si el vector és 0 no fa res
        {
            //Funció de rotació que agafa l'input del moviment. Funció moviment - rotació.
            Quaternion toRotation = Quaternion.LookRotation(OGmove);
            //la component transform del personatge, agafes la rotació del personatge i li apliques la variable rotation creada anteriorment
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotaionSpeed * Time.fixedDeltaTime);
        }

        _lastVelocity_Y = velocity.y;
        _lastVelocity_X = velocity.x;
        _lastVelocity_Z = velocity.z;


        // _jumpspeed = Mathf.Sqrt((velocity.x * velocity.x) + (velocity.z * velocity.z));

        // _playAnimation.setanimationmove(_jumpspeed);
    }



}