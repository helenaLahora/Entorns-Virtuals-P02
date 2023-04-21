using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSalud : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    public void Update()
    {
        Salud = Mathf.Clamp(Salud, 0, SaludMaxima);
        if(Salud <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

