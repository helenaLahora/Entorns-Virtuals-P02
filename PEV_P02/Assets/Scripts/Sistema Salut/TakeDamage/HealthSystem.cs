using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageTaker
{
    public void TakeDamage(float amount)
    {
        Debug.Log("Took Damage" + amount);
    }
}
