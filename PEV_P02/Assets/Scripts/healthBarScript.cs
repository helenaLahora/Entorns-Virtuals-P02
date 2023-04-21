using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class healthBarScript : MonoBehaviour
{
    public Image healthBar;
    public SistemaSalud sS;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float saludNormalizada = sS.Salud / sS.SaludMaxima;
        healthBar.fillAmount = saludNormalizada;
    }
}
