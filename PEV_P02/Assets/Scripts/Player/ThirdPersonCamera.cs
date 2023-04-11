using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Establece los ángulos mínimo y máximo de la cámara
    public float Y_ANGLE_MIN = 0.0f;
    public float Y_ANGLE_MAX = 50.0f;

    // El objeto que la cámara seguirá
    public Transform lookAt;
    // La distancia mínima y máxima entre la cámara y el objeto a seguir
    public float minDistance = 3.0f;
    public float maxDistance = 10.0f;
    // La distancia actual entre la cámara y el objeto a seguir
    private float currentDistance = 5.0f;

    // El ángulo actual de la cámara en el eje X
    private float currentX = 0.0f;
    // El ángulo actual de la cámara en el eje Y
    private float currentY = 45.0f;
    // La sensibilidad de la cámara en el eje X
    private float sensitivityX = 20.0f;
    // La sensibilidad de la cámara en el eje Y
    private float sensitivityY = 20.0f;
    // La transformación de la cámara
    private Transform camTransform;

    private void Start()
    {
        // Asigna la transformación de la cámara a la transformación del objeto
        camTransform = transform;
    }

    private void Update()
    {
        // Obtiene la entrada del ratón y la multiplica por la sensibilidad en los ejes X e Y
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        // Limita el ángulo de la cámara en el eje Y para que no se pueda mirar hacia abajo o hacia arriba demasiado lejos
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        // Controla el zoom mediante la rueda del ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentDistance -= scroll * 5;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        // Crea un vector de dirección apuntando hacia atrás desde la posición de la cámara
        Vector3 dir = new Vector3(0, 0, -currentDistance);
        // Crea una rotación utilizando los ángulos actuales de la cámara
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        // Establece la posición de la cámara utilizando la posición del objeto a seguir, la rotación y el vector de dirección
        camTransform.position = lookAt.position + rotation * dir;
        // Hace que la cámara apunte hacia el objeto a seguir
        camTransform.LookAt(lookAt.position);
    }
}
