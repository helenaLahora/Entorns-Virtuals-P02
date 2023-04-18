using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastLaser : MonoBehaviour
{
    public float shootRange = 100f; // Rango máximo de disparo
    public LayerMask Shootable; // Capa que representa los objetos disparables
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform shootPoint; // Punto de origen del disparo

    public LineRenderer laser; // Componente LineRenderer para el láser

    public float bulletSpeed = 100f; // Velocidad de la bala
    public float bulletLifetime = 2f; // Tiempo de vida de la bala

    void Start()
    {
        // Obtener o agregar un componente LineRenderer al objeto
        laser = GetComponent<LineRenderer>();
        if (laser == null)
        {
            laser = gameObject.AddComponent<LineRenderer>();
        }

        // Configurar las propiedades del láser
        laser.startWidth = 0.3f;
        laser.endWidth = 0.3f;
        laser.positionCount = 2;
    }

    void Update()
    {
        // Actualizar la posición y dirección del láser
        laser.SetPosition(0, shootPoint.position);
        laser.SetPosition(1, shootPoint.position + shootPoint.forward * shootRange);

        // Detectar el disparo del jugador con la tecla "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Lanzar el raycast desde el punto de origen del disparo en la dirección de la cámara
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootRange, Shootable))
        {
            // Si el raycast intersecta con un objeto en la capa shootable
            Debug.Log("Objetivo alcanzado: " + hit.collider.name);

            // Aquí puedes implementar la lógica de lo que sucede cuando se alcanza el objetivo,
            // como aplicar daño, reproducir efectos visuales, etc.

            // Obtener el componente Rigidbody del objeto alcanzado
            Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
            if (hitRigidbody != null)
            {
                // Aplicar la velocidad del proyectil al objeto alcanzado
                hitRigidbody.velocity = shootPoint.forward * bulletSpeed; // Usar la variable de velocidad de la bala
                // Destruir el enemigo
            }

            // Comprobar si el objeto alcanzado es el bulletPrefab
            if (hit.collider.gameObject.CompareTag("Enemy")) // Corregir la etiqueta del enemigo
            {
                // Destruir el enemigo
                Destroy(hit.collider.gameObject);
            }

        }
        else
        {
            // Si el raycast no intersecta con ningún objetivo
            Debug.Log("Disparo fallido");
        }

        // Instanciar el proyectil solo si el láser está habilitado (se hace clic en la tecla "F")
        if (laser.enabled)
        {
            // Instanciar una nueva bala en el punto de origen del disparo
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Configurar la velocidad y dirección de la bala
            bulletRigidbody.velocity = shootPoint.forward * bulletSpeed; // Usar la variable de velocidad de la bala

            // Destruir la bala después de cierto tiempo si no colisiona con ningún objeto
            Destroy(bullet, bulletLifetime); // Usar la variable
        }
    }
}