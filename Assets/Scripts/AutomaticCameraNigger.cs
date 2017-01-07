using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AutomaticCameraNigger : MonoBehaviour {

	public float speed = 5;

	private void Update() {
		// Move into place
		transform.position = Vector3.Lerp(
			transform.position,
			GetTargetPosition(),
			Time.deltaTime * speed
		);
	}

	private Vector3 GetTargetPosition() {
		

		return transform.position;
	}

}
