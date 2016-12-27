using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public sealed partial class Player : MonoBehaviour {
	
	private CharacterController body;

	partial void Awake() {
		body = GetComponent<CharacterController>();
	}

	partial void Update() {
		_MovePlayer();
	}

	#region Partial Methods Declaration
	partial void Awake();
	partial void Start();
	partial void Update();
	partial void FixedUpdate();
	partial void LateUpdate();
	partial void OnEnable();
	partial void OnDisable();
	partial void OnDestroy();
	partial void OnCollisionEnter(Collision col);
	partial void OnCollisionStay(Collision col);
	partial void OnCollisionExit(Collision col);
	partial void OnTriggerEnter(Collider col);
	partial void OnTriggerStay(Collider col);
	partial void OnTriggerExit(Collider col);
	#endregion
}
