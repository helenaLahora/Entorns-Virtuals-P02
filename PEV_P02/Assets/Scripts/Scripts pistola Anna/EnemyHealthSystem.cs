using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(float amount)
    {
        Destroy(gameObject);
    }
}
