using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	public float swordDamage = 10;
	public Collider swordTrigger;

	public void EnableSwordTrigger(){
		swordTrigger.enabled = true;
	}

	public void DisableSwordTrigger(){
		swordTrigger.enabled = false;
	}

	public void ApplySwordDamage(Collider other){
		other.GetComponent<HealthSystem> ().ReceiveDamage(swordDamage);
	}

}
