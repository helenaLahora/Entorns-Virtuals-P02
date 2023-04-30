using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float BulletLife; // Duraci�n de vida de la bala
    public float BulletDamage; //Da�o de la bala
    void Start()
    {
        StartCoroutine(BulletLifeDuration());
    }

    IEnumerator BulletLifeDuration()
    {
        yield return new WaitForSeconds(BulletLife);
        yield return null;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemies")
        {
            other.GetComponent<SistemaSalud>().Salud -= BulletDamage * 1.5f;
        }
        Destroy(this.gameObject);
    }
}
