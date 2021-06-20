using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float rotationSpeedX = 2.0f;
	public float rotationSpeedY = 2.0f;
	public float xRotation = 0.0f;
	public float yRotation = 0.0f;
	public float playerSpeed = 10.0f;
	void Start()
	{
		transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}
	void Update()
	{
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Jump"), Input.GetAxisRaw("Vertical"));
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * playerSpeed;
		Vector3 velocityInTime = velocity * Time.deltaTime;

		//letting player move in correct rotation direction
		transform.position += velocityInTime;
		transform.rotation = Quaternion.Euler(0.0f, transform.rotation.y, transform.rotation.z); //makes sure the player doesn't topple
	}
}