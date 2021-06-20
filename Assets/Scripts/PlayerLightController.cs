using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
	public int playerSpeed = 10;
	public float rotationSpeedX = 2.0f;
	public float rotationSpeedY = 2.0f;
	public float xRotation = 0.0f;
	public float yRotation = 0.0f;
    void Update()
    {
        //rotation
        xRotation += rotationSpeedX * Input.GetAxis("Mouse X");
		yRotation -= rotationSpeedY * Input.GetAxis("Mouse Y");
		transform.eulerAngles = new Vector3(yRotation, xRotation, 0.0f);

        //imitate the player's movement
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Jump"), Input.GetAxisRaw("Vertical"));
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * playerSpeed;
		Vector3 distanceMove = velocity * Time.deltaTime;
		transform.position += distanceMove;
	}
}
