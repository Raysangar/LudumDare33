﻿using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	private bool alive = true;

	public float maxHealth = 100f;
	public float currentHealth;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	public void ReceiveDamage(float damage){
		if (!alive) {
			return;
		}
		currentHealth -= damage;
		SendMessage ("UpdateFloatingHealthBar",currentHealth/maxHealth);
		SendMessage("HitBleed");

		if (currentHealth <= 0) {
			alive = false;
			StartCoroutine(Die());
		}
	}

	private IEnumerator Die(){
		SendMessage ("DeadBleed");
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	}
}