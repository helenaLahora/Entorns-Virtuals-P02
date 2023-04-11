using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;

	// Se define la velocidad de movimiento y rotación del jugador
	public float speed = 600.0f;
	public float turnSpeed = 400.0f;

	// La dirección de movimiento se inicializa a cero
	private Vector3 moveDirection = Vector3.zero;

	// Gravedad aplicada al jugador
	public float gravity = 20.0f;

	// Fuerza de salto
	public float jumpForce = 8.0f;

	void Start () {
		// Se obtienen los componentes Animator y CharacterController del objeto al que se le asigna el script
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();

	}

	void Update (){
		if (Input.GetKey("w")) {
			// Si se pulsa la tecla "w", se activa la animación de correr
			anim.SetInteger("AnimationPar", 1);
		} else {
			// De lo contrario, se desactiva la animación
			anim.SetInteger("AnimationPar", 0);
		}

		if (controller.isGrounded) {
			// Si el jugador está en el suelo, se calcula su dirección de movimiento en base a la entrada del jugador
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

			if (Input.GetKeyDown(KeyCode.Space)) {
				// Si se pulsa la tecla espacio, se aplica una fuerza de salto a la dirección vertical de movimiento del jugador
				moveDirection.y = jumpForce;
			}
		}

		// Se calcula la dirección de rotación en base a la entrada del jugador
		float turn = Input.GetAxis("Horizontal");

		// Se aplica la rotación al objeto del jugador
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

		// Se mueve el objeto del jugador en la dirección de movimiento calculada
		controller.Move(moveDirection * Time.deltaTime);

		// Se aplica la gravedad al jugador
		moveDirection.y -= gravity * Time.deltaTime;
	}
}