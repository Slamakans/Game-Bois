using ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour {

	/// <summary>Movement speed for the player. Value reprecents units per second.</summary>
	[Header("Movement")]
	public float moveSpeed = 5;
	/// <summary>Once mid-air, i.e. not grounded, the players movement speed is multiplied by this number.</summary>
	[Range(0,1)]
	public float midAirMultiplier = 1;
	/// <summary>The height of the players jump in units.</summary>
	public float jumpHeight = 5;
	/// <summary>Decides wether player can continously jump by holding jump button or if they need to press it each time.</summary>
	public bool continousJumping = true;
	/// <summary>Speed of which player rotates towards where they're moving. Value reprecents angles per second.</summary>
	public float rotationSpeed = 480;
	/// <summary>Movement axis combined deadzone. Movement is ignored when the input vector magnitude is below this value.</summary>
	[Range(0,1)]
	public float movementDeadzone = 0.01f;

	/// <summary>The players X and Z velocity from their movement input. Is overriden each frame in _MovePlayer</summary>
	private Vector2 move = Vector2.zero;
	/// <summary>nameof variable is little missleading. It's actually the Y-velocity</summary>
	private float gravity = 0;

	float CalculateJumpForce() {
		/*
		 * Calculates the amount of force required to reach /jumpHeight/. Including gravity.
		 * 
		 * I don't recall where I found this formula but it's pretty basic physics.
		 * Too bad we DONT GET ANY PHYSICS CLASS IN AN ESTHETICS COURSE.
		 * 
		 * Stupid school. I want physics. Hmpf.
		 */
		return Mathf.Sqrt(Mathf.Abs(2 * jumpHeight * Physics.gravity.y));
	}

	private void _MovePlayer() {
		move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		// To circle'ize the input
		//move.Scale(move.normalized.Abs());
		
		// Speed multiplier
		move *= moveSpeed;

		// Gravity
		gravity += Physics.gravity.y * Time.deltaTime;

		if (body.isGrounded) {
			// Jumping
			if (continousJumping ? Input.GetButton("Jump") : Input.GetButtonDown("Jump"))
				gravity = CalculateJumpForce();
		} else {
			// Mid-air multiplier
			move *= midAirMultiplier;
		}
		
		// Apply movement
		body.Move(move.xzy(gravity) * Time.deltaTime);

		// Reset gravity
		if (body.isGrounded)
			gravity = 0;

		// Deadzone of movement
		if (move.magnitude > movementDeadzone) {
			// Rotate in direction of movement vector
			float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 90 - move.ToDegrees(), rotationSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * newAngle;
		}
	}
	
}
