using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastLaser : MonoBehaviour
{

    public float shootRange = 100f; // Rango m�ximo de disparo
    public LayerMask Shootable; // Capa que representa los objetos disparables
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform shootPoint; // Punto de origen del disparo

    public LineRenderer laser; // Componente LineRenderer para el l�ser

    public float bulletSpeed = 100f; // Velocidad de la bala
    public float bulletLifetime = 2f; // Tiempo de vida de la bala
    public float bulletDamage = 2f;

    [SerializeField]
    InputSystem input;

    void Start()
    {
        // Obtener o agregar un componente LineRenderer al objeto
        laser = GetComponent<LineRenderer>();
        if (laser == null)
        {
            laser = gameObject.AddComponent<LineRenderer>();
        }

        // Configurar las propiedades del l�ser
        laser.startWidth = 0.3f;
        laser.endWidth = 0.3f;
        laser.positionCount = 2;
    }

    void Update()
    {
        // Actualizar la posici�n y direcci�n del l�ser
        laser.SetPosition(0, shootPoint.position);
        laser.SetPosition(1, shootPoint.position + shootPoint.forward * shootRange);

        // Detectar el disparo del jugador con la tecla "F"
        if (input.Controles_F)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil solo si el l�ser est� habilitado (se hace clic en la tecla "F")
        if (laser.enabled)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.GetComponent<bala>().BulletLife = bulletLifetime;
            bullet.GetComponent<bala>().BulletDamage = bulletDamage;
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            bulletRigidbody.velocity = shootPoint.forward * bulletSpeed; // Usar la variable de velocidad de la bala

            // Destruir la bala despu�s de cierto tiempo si no colisiona con ning�n objeto
            Destroy(bullet, bulletLifetime); // Usar la variable
        }
    }
}