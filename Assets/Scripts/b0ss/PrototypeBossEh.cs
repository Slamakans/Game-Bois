using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeBossEh : b0ss {

	[Header("WhatToFire")]
	public BossProjectile prefab;

	private IEnumerator Start() {
		yield return new WaitForSeconds(2);
		while(true) {
			FireWaveStraightTowards(prefab, GameGlobals.player.transform.position, 5, 35, 2);
			yield return new WaitForSeconds(0.2f);
			FireWaveStraightTowards(prefab, GameGlobals.player.transform.position, 5, 35, 2);
			yield return new WaitForSeconds(0.2f);
			FireWaveStraightTowards(prefab, GameGlobals.player.transform.position, 5, 35, 2);
			yield return new WaitForSeconds(0.2f);
			yield return new WaitForSeconds(1.5f);
		}
	}

}
