using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float BulletLife; // Duración de vida de la bala
    public float BulletDamage; //Daño de la bala
    
    void Start()
    {
        StartCoroutine(BulletLifeDuration());
    }

    IEnumerator BulletLifeDuration()
    {
        Debug.Log("La bala ha sido creada");
        yield return new WaitForSeconds(BulletLife);
        Debug.Log("La bala ha sido destruida");
        Destroy(this.gameObject);
        yield return null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemies")
        {
            other.GetComponent<SistemaSalud>().Salud -= BulletDamage * 1.5f;
            Debug.Log("La bala ha colisionado con " + other.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}