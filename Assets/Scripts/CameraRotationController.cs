using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
	public float rotationSpeed = 50f;

	public Transform playerObject;

	float xRotation = 0f;
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
	}
	void Update()
	{
		float mouseX = rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
		float mouseY = rotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
		xRotation -= mouseY;

		//clamp rotation
		xRotation = Mathf.Clamp(xRotation, -60f, 60f);

		//change rotation
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerObject.Rotate(Vector3.up * mouseX);
	}
}
