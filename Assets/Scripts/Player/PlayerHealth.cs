using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed partial class Player : MonoBehaviour {

	[Header("Health")]
	public int health = 100;
	public int maxHealth = 100;

#if UNITY_EDITOR
	private int oldHealth = 100;
	private int oldMaxHealth = 100;
	private void OnValidate() {
		health = Mathf.Clamp(health, 0, maxHealth);
		if (!Application.isPlaying) return;
		if (health!=oldHealth) GameGlobals.playerHPSlider.value = oldHealth = health;
		if (maxHealth!=oldMaxHealth) GameGlobals.playerHPSlider.maxValue = oldMaxHealth = maxHealth;
	}
#endif
	
	/// <summary>
	/// Sets health AND changes the UI healthbar.
	/// </summary>
	public void SetHealth(int health) {
		GameGlobals.playerHPSlider.value = this.health = health;
	}

	/// <summary>
	/// Sets max health AND changes the UI healthbar.
	/// </summary>
	public void SetMaxHealth(int maxHealth) {
		GameGlobals.playerHPSlider.maxValue = this.maxHealth = maxHealth;
	}

	/// <summary>
	/// <para>Subtracts <paramref name="amount"/> from players health, as well as updates the UI.</para>
	/// <para>Calculation: <code><see cref="health"/> -= <paramref name="amount"/>;</code></para>
	/// </summary>
	public void Damage(int amount) {
		GameGlobals.playerHPSlider.value = health = health - amount;
	}

	/// <summary>
	/// <para>Subtracts <paramref name="amount"/> from players health, as well as updates the UI.</para>
	/// <para>Calculation: <code><see cref="health"/> += <paramref name="amount"/>;</code></para>
	/// </summary>
	public void Heal(int amount) {
		GameGlobals.playerHPSlider.value = health = health + amount;
	}

}
