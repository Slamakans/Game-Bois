using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AutomaticCameraNigger : MonoBehaviour {

	[Header("Panning")]
	public float speed = 5;
	[Range(0,1)]
	public float followMultiplierX = 1;
	[Range(0,1)]
	public float followMultiplierZ = 1;
	public Vector3 offset = new Vector3(0,28,-28);

	[Header("Rotation")]
	public float lookSpeed = 150;
	[Range(0,1)]
	public float lookMultiplier = 1;

	private Vector3 centerOfMap;
	private Quaternion startRotation;

	private void Start() {
		startRotation = transform.rotation;
		centerOfMap = GameGlobals.player.transform.position;
		centerOfMap.y = 0;
	}

	private void Update() {
		// Move into place
		transform.position = Vector3.Lerp(
			transform.position,
			GetTargetPosition(),
			Time.deltaTime * speed
		);

		// Rotate into place
		transform.rotation = Quaternion.Lerp(
			transform.rotation,
			GetTargetRotation(),
			Time.deltaTime * lookSpeed
		);
	}

	private Vector3 GetTargetPosition() {
		Vector3 target = GameGlobals.player.transform.position;
		target.y = 0;
		target += offset;

		target.x = Mathf.Lerp(centerOfMap.x + offset.x, target.x, followMultiplierX);
		target.z = Mathf.Lerp(centerOfMap.z + offset.z, target.z, followMultiplierZ);

		return target;
	}

	private Quaternion GetTargetRotation() {
		Vector3 delta = GameGlobals.player.transform.position - transform.position;
		Quaternion target = Quaternion.LookRotation(delta);
		return Quaternion.Lerp(startRotation, target, lookMultiplier);
	}

}
