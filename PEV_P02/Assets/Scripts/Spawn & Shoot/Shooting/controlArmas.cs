using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlArmas : MonoBehaviour {
    
    public List<Arma> armas; // guarda todas las armas que contienen el script para disparar
    private int armaActual = 0;

    void Start() {
        CambiarArma(armaActual);
    }

    void CambiarArma(int indice) {
        armaActual = indice;
        for (int i = 0; i < armas.Count; i++) {
            if (i == armaActual) {
                armas[i].gameObject.SetActive(true);
            } else {
                armas[i].gameObject.SetActive(false);
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            CambiarArma((armaActual + 1) % armas.Count);
        }
    }
}
