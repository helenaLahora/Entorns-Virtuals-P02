using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasse : MonoBehaviour
{

    public static Action OnTirarsePelPont; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TryKillMySelf()
    {
        OnTirarsePelPont.Invoke();
    }
}
