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

}
