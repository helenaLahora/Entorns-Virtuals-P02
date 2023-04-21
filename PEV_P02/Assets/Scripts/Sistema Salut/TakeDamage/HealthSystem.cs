using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    public void TakeDamage(float amount)
    {
        Debug.Log("Took Damage" + amount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var  health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            health.TakeDamage(5);
        }
    }
}
