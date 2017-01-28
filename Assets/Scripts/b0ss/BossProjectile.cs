using ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BossProjectile : MonoBehaviour {

	public int damage = 1;
	public float autoDieAfter = 15;
	[System.NonSerialized]
	public Rigidbody body;

#if UNITY_EDITOR
	private void OnValidate() {
		// Lock values
		damage = Mathf.Max(damage, 0);
		autoDieAfter = Mathf.Clamp(autoDieAfter, 0, 60);
	}
#endif

	private void Start() {
		if (body == null) {
			Debug.LogError("Projectile created in an incorrect fashion!");
		}

		Destroy(gameObject, autoDieAfter);
	}

	private void Update() {
		transform.forward = body.velocity;
	}

	private void OnCollisionEnter(Collision col) {
		if (col.gameObject.GetComponent<Player>()) {
			GameGlobals.player.Damage(damage);
		}

		Destroy(gameObject);
	}

}
