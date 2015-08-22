using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	public void ReceiveDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Die();
		}
	}

	private void Die(){
		Destroy (this.gameObject);
	}
}
