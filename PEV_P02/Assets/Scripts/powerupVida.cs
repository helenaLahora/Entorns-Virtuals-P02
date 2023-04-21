using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupVida : MonoBehaviour
{
    public float HealthIncrement;
    public MeshRenderer[] mR; //recull el component mesh renderer que li posis al inspector


    public void Regen()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        foreach (MeshRenderer m in mR)
        {
            m.enabled = false;
        }
        StartCoroutine(RegenPowerup());
    }

    IEnumerator RegenPowerup()
    {
        yield return new WaitForSeconds(10);
        this.gameObject.GetComponent<Collider>().enabled = true;
        foreach (MeshRenderer m in mR)
        {
            m.enabled = true;
        }
        yield return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<SistemaSalud>().Salud += HealthIncrement;
            Regen();
        }
    }
}
