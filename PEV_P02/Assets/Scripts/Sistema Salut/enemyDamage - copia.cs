using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float EnemyDamage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<SistemaSalud>().Salud > 0)
            {
                other.GetComponent<SistemaSalud>().Salud -= EnemyDamage;
            }
        }
    }
}
