using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerSpeed = 10.0f;
	float playerHealth = 10f;
	public CharacterController controller;
	void Start()
	{
		transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 distanceToMove = transform.right * horizontal + transform.forward * vertical;
		Vector3 movement = distanceToMove * Time.deltaTime * playerSpeed;
		controller.Move(movement);
	}

	void OnCollisionEnter(Collision Collider)
	{
		print(Collider.gameObject.tag); 
		if (Collider.gameObject.tag == "Trap")
		{
			playerHealth -= 0.5f;
			print(playerHealth);
		}
	}
}