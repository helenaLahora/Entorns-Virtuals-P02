using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    public GameObject objectToInstantiate; // GameObject que se instanciará

    public Vector3 instantiationAreaCenter // Centro del área de instanciación
    {
        get { return transform.position; } // Se utiliza la posición actual del objeto con el script
    }

    // Tamaño del área de instanciación solo en los ejes x y z
    public Vector2 instantiationAreaSize;

    [Range(1, 100)] // Rango permitido para el número de instancias a crear
    public int numberOfInstances = 15; // Número de instancias a crear

    [Range(0, 10)] // Altura a la que se generan los objetos
    public float height = 0f;

    public float minScale = 0.5f; // Escala mínima permitida
    public float maxScale = 2f; // Escala máxima permitida

    [Range(0, 360)] // Rango permitido para la rotación en el eje "y"
    public float maxRotationY = 360f; // Valor máximo de rotación permitido en el eje "y"

    private void Start()
    {
        // Bucle para crear instancias
        for (int i = 0; i < numberOfInstances; i++)
        {
            // Se genera una posición aleatoria dentro del área de instanciación
            Vector3 randomPosition = new Vector3(
                Random.Range(-instantiationAreaSize.x / 2f, instantiationAreaSize.x / 2f), // Valor aleatorio en el eje x
                height, // Altura a la que se generarán los objetos
                Random.Range(-instantiationAreaSize.y / 2f, instantiationAreaSize.y / 2f) // Valor aleatorio en el eje z
            ) + instantiationAreaCenter; // Se agrega el centro del área de instanciación para obtener la posición final

            // Se genera una escala aleatoria para el objeto
            float randomScale = Random.Range(minScale, maxScale);
            Vector3 scale = new Vector3(randomScale, randomScale, randomScale);

            // Se genera una rotación aleatoria en el eje "y"
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, maxRotationY), 0f);

            // Se instancia el objeto en la posición aleatoria y con la escala y rotación generadas
            GameObject newInstance = Instantiate(objectToInstantiate, randomPosition, randomRotation);
            newInstance.transform.localScale = scale;

            // Se establece el objeto instanciado como hijo del objeto
            newInstance.transform.parent = transform;
        }
    }
}