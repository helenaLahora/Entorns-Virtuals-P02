using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour // declaramos la clase
{
    public Transform target; // objeto a seguir
    public float distance = 5.0f; // distancia inicial de la cámara
    public float height = 2.0f; // altura de la cámara sobre el objeto
    public float damping = 5.0f; // suavidad de movimiento de la cámara
    public float zoomSpeed = 2.0f; // velocidad de zoom
    public float minDistance = 1.0f; // distancia mínima permitida
    public float maxDistance = 10.0f; // distancia máxima permitida

    private float currentDistance; // distancia actual
    private float desiredDistance; // distancia deseada
    private Vector3 offset; // offset (distancia) entre la cámara y el objeto

    void Start()
    {
        offset = transform.position - target.position; // calculamos el offset
        currentDistance = distance; // establecemos la distancia actual como la distancia inicial
        desiredDistance = distance; // establecemos la distancia deseada como la distancia inicial
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * damping; // obtenemos el movimiento horizontal del mouse
        float vertical = Input.GetAxis("Mouse Y") * damping; // obtenemos el movimiento vertical del mouse

        Quaternion rotation = Quaternion.Euler(vertical, horizontal, 0); // calculamos la rotación de la cámara
        Vector3 desiredPosition = target.position + (rotation * offset * currentDistance); // calculamos la posición deseada de la cámara

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping); // movemos la cámara hacia la posición deseada utilizando la función Lerp

        currentDistance = Mathf.Clamp(currentDistance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, minDistance, maxDistance); // actualizamos la distancia actual utilizando el valor del mouse scrollwheel y asegurándonos de que esté dentro de los límites permitidos
    }
}
