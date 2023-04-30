using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public MelePlayer _mele;

    public float PlayerDamage;

    private void OnTriggerStay(Collider other)
    {
        if(_mele.isMele == true)
        {
            if(other.tag == "Enemies")
            {
                if (other.GetComponent<SistemaSalud>().Salud > 0)
                {
                    other.GetComponent<SistemaSalud>().Salud -= PlayerDamage;
                }
            }
        }
    }
}
