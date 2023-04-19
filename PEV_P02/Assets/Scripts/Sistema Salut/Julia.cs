using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Julia : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Lasse.OnTirarsePelPont += TrucarPolicia;
    }

    void OnDisable()//abans de morir la julia, li hauria de dir al lasse que fa un unsubscrive del canal 
    {
        Lasse.OnTirarsePelPont -= TrucarPolicia;
    }

    private void TrucarPolicia(bool isDead)
    {
        if(!isDead)
            Debug.Log("Por fin");
        else
            Debug.Log("Li posarem una multa");
    }
}

