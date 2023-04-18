using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasse : MonoBehaviour
{

    public static Action<bool> OnTirarsePelPont;
    bool _isDead;

    // Start is called before the first frame update
    void Start()
    {
        TryKillMySelf();
        
    }

    void TryKillMySelf()
    {
        //_isDead = Random.value < 0.5f;
        //OnTirarsePelPont?.Invoke(_isDead);
        OnTirarsePelPont?.Invoke(false);//No es null el ?. Quan invoco el mètode m'he tirat pel pont, puc dir estic mort si o no?
    }
}
