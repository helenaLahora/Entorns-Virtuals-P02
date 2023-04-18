using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantatior_Circle : MonoBehaviour
{
    public GameObject objectToInstantiate; // El objeto que se instanciar�

    [Range(1, 100)] // Rango permitido para el n�mero de instancias a crear
    public int numberOfObjects; // El n�mero de objetos a instanciar

    public float radius; // El radio del patr�n circular
    public float speed; // La velocidad a la que girar� el patr�n circular

    [Range(0, 10)] // Altura a la que se generan los objetos
    public float height; // La altura a la que se generan los objetos

    [Range(0.1f, 10f)] // Rango permitido para la escala de los objetos instanciados
    public float scale = 1f; // La escala de los objetos instanciados

    private List<GameObject> objects = new List<GameObject>(); // Lista para almacenar las instancias

    void Start()
    {
        // Se crea un objeto vac�o que ser� el padre de las instancias
        GameObject parentObject = new GameObject("Instantiated Objects");

        // Se hace que el objeto padre sea hijo del objeto que tiene el script
        parentObject.transform.parent = transform;

        // Se genera un bucle para instanciar el objeto "numberOfObjects" veces
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Se calcula el �ngulo en el que debe estar la instancia actual para seguir el patr�n circular
            float angle = i * Mathf.PI * 2f / numberOfObjects;

            // Se calcula la posici�n de la instancia en funci�n del �ngulo, el radio y la altura definidos
            Vector3 pos = new Vector3(Mathf.Cos(angle), height, Mathf.Sin(angle)) * radius;

            // Se instancia el objeto en la posici�n calculada y se a�ade a la lista
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
                // Se calcula el �ngulo en el que debe estar la instancia actual para seguir el patr�n circular, tomando en cuenta la rotaci�n del objeto que tiene el script
                float angle = i * Mathf.PI * 2f / numberOfObjects + transform.rotation.eulerAngles.y * Mathf.Deg2Rad;

                // Se calcula la posici�n de la instancia en funci�n del �ngulo, el radio y la altura definidos
                Vector3 pos = new Vector3(Mathf.Cos(angle), height, Mathf.Sin(angle)) * radius;

                // Se actualiza la posici�n de la instancia
                objects[i].transform.position = transform.position + pos;

                // Se calcula la direcci�n desde la instancia hacia el centro del c�rculo
                Vector3 dirToCenter = Vector3.Normalize(transform.position - objects[i].transform.position);

                // Se rota la instancia para que mire hacia el centro del c�rculo
                objects[i].transform.rotation = Quaternion.LookRotation(dirToCenter, Vector3.up);

                // Se establece el objeto principal como padre de la instancia
                objects[i].transform.parent = transform;
            }
        }
    }
}