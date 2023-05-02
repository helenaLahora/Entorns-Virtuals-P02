using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarArma : MonoBehaviour {
    public controlArmas controlArmas; // referencia al script que maneja las armas
    public Transform posicionArma; // referencia al objeto "PosicionArma"
    public GameObject Armainicial;
    public GameObject ArmaArcoiris;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Arma")) { // verifica si el objeto que ha entrado en colisión es un arma
            Arma arma = other.GetComponent<Arma>(); // obtiene el script de arma del objeto que ha entrado en colisión
            
            if (arma != null && !controlArmas.armas.Contains(arma)) {
                controlArmas.armas.Add(arma); // agrega el arma a la lista de armas del controlador de armas
                Armainicial.SetActive(false);
                ArmaArcoiris.GetComponent<raycastLaser>().enabled = true;
                ArmaArcoiris.GetComponent<raycastLaser>().ModoDisparo = true;
                arma.transform.position = posicionArma.position; // coloca el arma en las coordenadas del objeto "PosicionArma"
                arma.transform.rotation = posicionArma.rotation; // coloca el arma en las coordenadas del objeto "PosicionArma"
                arma.transform.parent = posicionArma; // hace que el objeto "PosicionArma" sea el padre del objeto de arma
            }
        }
    }
}