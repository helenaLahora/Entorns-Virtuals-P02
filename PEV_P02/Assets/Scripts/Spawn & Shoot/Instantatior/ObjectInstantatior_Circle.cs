using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantatior_Circle : MonoBehaviour
{
    public GameObject objectToInstantiate; // El objeto que se instanciará

    [Range(1, 100)] // Rango permitido para el número de instancias a crear
    public int numberOfObjects; // El número de objetos a instanciar

    public float radius; // El radio del patrón circular
    public float speed; // La velocidad a la que girará el patrón circular

    [Range(0, 10)] // Altura a la que se generan los objetos
    public float height; // La altura a la que se generan los objetos

    [Range(0.1f, 10f)] // Rango permitido para la escala de los objetos instanciados
    public float scale = 1f; // La escala de los objetos instanciados

    private List<GameObject> objects = new List<GameObject>(); // Lista para almacenar las instancias

    void Start()
    {
        // Se crea un objeto vacío que será el padre de las instancias
        GameObject parentObject = new GameObject("Instantiated Objects");

        // Se hace que el objeto padre sea hijo del objeto que tiene el script
        parentObject.transform.parent = transform;

        // Se genera un bucle para instanciar el objeto "numberOfObjects" veces
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Se calcula el ángulo en el que debe estar la instancia actual para seguir el patrón circular
            float angle = i * Mathf.PI * 2f / numberOfObjects;

            // Se calcula la posición de la instancia en función del ángulo, el radio y la altura definidos
            Vector3 pos = new Vector3(Mathf.Cos(angle), height, Mathf.Sin(angle)) * radius;

            // Se instancia el objeto en la posición calculada y se añade a la lista
            GameObject obj = Instantiate(objectToInstantiate, parentObject.transform);
            obj.transform.localPosition = pos;
            obj.transform.localScale = Vector3.one * scale; // Se establece la escala del objeto instanciado
            objects.Add(obj);
        }
    }

    void Update()
    {
        // Se rota el objeto que tiene el script
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        // Se recorre la lista de objetos instanciados
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] != null) // Null check
            {
                // Se calcula el ángulo en el que debe estar la instancia actual para seguir el patrón circular, tomando en cuenta la rotación del objeto que tiene el script
                float angle = i * Mathf.PI * 2f / numberOfObjects + transform.rotation.eulerAngles.y * Mathf.Deg2Rad;

                // Se calcula la posición de la instancia en función del ángulo, el radio y la altura definidos
                Vector3 pos = new Vector3(Mathf.Cos(angle), height, Mathf.Sin(angle)) * radius;

                // Se actualiza la posición de la instancia
                objects[i].transform.position = transform.position + pos;

                // Se calcula la dirección desde la instancia hacia el centro del círculo
                Vector3 dirToCenter = Vector3.Normalize(transform.position - objects[i].transform.position);

                // Se rota la instancia para que mire hacia el centro del círculo
                objects[i].transform.rotation = Quaternion.LookRotation(dirToCenter, Vector3.up);

                // Se establece el objeto principal como padre de la instancia
                objects[i].transform.parent = transform;
            }
        }
    }
}