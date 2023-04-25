using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //ES MOLT NECESSARI POSAR AIXÒ
                                // Serveix per a poder connectar el codi amb el InputSystem de Unity

public class InputSystem : MonoBehaviour
{
    // ES CREEN TOTS ELS VALORS NECESSARIS PER A QUE APAREGUIN EN PANTALLA I ES PUGUIN MODIFICAR
    public float Controles_H;
    public float Controles_V;
    public bool Controles_J;
    public bool Controles_F;


//_________________________________________________________________________________________________________________________________________________________________________________________//


    void LateUpdate() // Es fa desprès del Update (és una acció que es realitza just desprès del Update normal)
    {
        Controles_J = false; // Li dius que no li estas donant a la tecla espai, que constantment està en FALSE fins que prems la tecla space i es posa TRUE
        Controles_F = false;
    }


//_________________________________________________________________________________________________________________________________________________________________________________________//


    private void OnMove(InputValue CONTROLES) //OnMove --> agafa el input de SystemInput pel moviment
                                              //InputValue --> agafa el valor que m'interessa i li poso el nom que vull (CONTROLES)
    {
        Controles_H = CONTROLES.Get<Vector2>().x; //Li assigno un nombre al valor que he agafat per no predre'l i el transformo en un Vector2 
        Controles_V = CONTROLES.Get<Vector2>().y; 
    }


    private void OnJump() //OnJUMP --> Té aquest nom perquè és el que li he posat jo als comandaments de salt en el InputSystem de Unity
                            // Com que només te les directrius de una tecla, no és necessari posar input perquè ja sap quin agafar
    {
        Controles_J = true; // Dius que en quan prems la tecla espai això es TRUE, s'activa el void i permet el salt

    }

    public void OnShoot()
    {
        Controles_F = true;
    }

}