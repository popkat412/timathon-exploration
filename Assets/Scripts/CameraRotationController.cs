using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
	public float rotationSpeedX = 2.0f;
	public float rotationSpeedY = 2.0f;
	public float xRotation = 0.0f;
	public float yRotation = 0.0f;

	void Update()
	{
		xRotation += rotationSpeedX * Input.GetAxis("Mouse X");
		yRotation -= rotationSpeedY * Input.GetAxis("Mouse Y");
		print(Input.GetAxis("Mouse X"));
		print(Input.GetAxis("Mouse Y"));
		transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
	}
}
