using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	public CharacterController controller;
	public Transform cam;

	public float speed = 6f;
	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal"); // Assigns the X input axis
		float vertical = Input.GetAxisRaw("Vertical"); // Assigns the Z input axis
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Passes in the axis' and sets Y to 0 as it wont be used

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // Calculates the point on the radius the player is facing using the Atan2 func, then converting it from radians to degrees.
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}
	}
}
