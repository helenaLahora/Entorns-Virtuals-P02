using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Init(float Speed)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;

        Invoke("KillMyself", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageReciever = other.GetComponent<ITakeDamage>();
        if(damageReciever != null) //quan ataqui a algo que es pugui matar, li fara x mal i destruira la bala
        {
            damageReciever.TakeDamage(42);
            Destroy(gameObject);
        }
    }

    /*private void OnBecameInvisible() //necessitaria un renderer pq pugui estar visible i llavors se li pugui aplicar el invisible
    {
        Destroy(gameObject);
    }*/
    void KillMyself()
    {
        Destroy(gameObject);
    }
}
