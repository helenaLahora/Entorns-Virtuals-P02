using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float BulletLife;
    public float BulletDamage;
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
        if(other.tag == "Enemy")
        {
            other.GetComponent<SistemaSalud>().Salud -= BulletDamage * 3;
        }
        Destroy(this.gameObject);
    }
}
