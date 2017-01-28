using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class b0ss : MonoBehaviour {

	[Header("Health")]
	public int health = 100;
	public int maxHealth = 100;

#if UNITY_EDITOR
	private void OnValidate() {
		health = Mathf.Clamp(health, 0, maxHealth);
	}
#endif

	public void FireInArcTowards(BossProjectile prefab, Vector3 target, float impactAfter = 1) {
		BossProjectile clone = Instantiate(prefab, transform.position, Quaternion.identity);

		clone.body = clone.GetComponent<Rigidbody>();

		var delta = target - transform.position;
		clone.body.velocity = VectorHelper.CalculateVelocity(delta, impactAfter / Time.fixedDeltaTime);

		// Look where you goin, chump
		clone.transform.forward = clone.body.velocity;
	}

	public void FireStraightTowards(BossProjectile prefab, Vector3 target, float speed = 5f) {
		BossProjectile clone = Instantiate(prefab, transform.position, Quaternion.identity);

		clone.body = clone.GetComponent<Rigidbody>();

		var delta = target - transform.position;
		clone.body.velocity = delta * speed;
		clone.body.useGravity = false;

		// Look where you goin, chump
		clone.transform.forward = clone.body.velocity;
	}

	public void FireWaveStraightTowards(BossProjectile prefab, Vector3 target, int amount, float angle = 45, float speed = 5f) {
		Vector3 delta = target - transform.position;

		if (amount == 1) FireStraightTowards(prefab, target, speed);
		else {
			for (int i=0; i<amount; i++) {
				Vector3 newTarget = transform.position + Quaternion.Euler(0, i/(amount-1f) * angle - angle * 0.5f, 0) * delta;
				FireStraightTowards(prefab, newTarget, speed);
			}
		}

	}

}
