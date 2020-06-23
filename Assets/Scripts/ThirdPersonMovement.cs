using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	public CharacterController controller;

	public float speed = 6f;

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal"); // Assigns the X input axis
		float vertical = Input.GetAxisRaw("Vertical"); // Assigns the Z input axis
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Passes in the axis' and sets Y to 0 as it wont be used

		if (direction.magnitude >= 0.1f)
		{
			controller.Move(direction * speed * Time.deltaTime);
		}
	}
}
