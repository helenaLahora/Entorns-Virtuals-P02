using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantationPattern : MonoBehaviour
{
    public GameObject prefab; // Prefab del game object a instanciar
    public int numInstancies = 10; // Nombre d'inst�ncies a crear
    public float radi = 5f; // Radi del cercle on s'instanciaran els game objects

    private void Start()
    {
        // Creem les inst�ncies en un cercle al voltant de l'objecte principal
        for (int i = 0; i < numInstancies; i++)
        {
            // Calculem la posici� del game object en el cercle
            float angle = i * Mathf.PI * 2 / numInstancies; // angle de separaci� entre les inst�ncies
            Vector3 posicio = transform.position + new Vector3(Mathf.Cos(angle) * radi, 0f, Mathf.Sin(angle) * radi);

            // Instanciem el game object a la posici� calculada
            Instantiate(prefab, posicio, Quaternion.identity);
        }
    }
}
