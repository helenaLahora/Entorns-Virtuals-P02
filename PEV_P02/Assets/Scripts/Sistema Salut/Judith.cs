using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judith : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Lasse.OnTirarsePelPont += TrucarAmbulancia;
    }

    void OnDisable()//abans de morir la julia, li hauria de dir al lasse que fa un unsubscrive del canal 
    {
        Lasse.OnTirarsePelPont -= TrucarAmbulancia;
    }

    private void TrucarAmbulancia()
    {
        Debug.Log("Tatü tata");
    }
}
