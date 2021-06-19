using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerSpeed = 10.0f;
	void Update()
    {
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Jump"), Input.GetAxisRaw("Vertical"));
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * playerSpeed;
		Vector3 distanceMove = velocity * Time.deltaTime;
		transform.position += distanceMove;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //makes sure the player doesn't topple
	}
}
