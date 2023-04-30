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
