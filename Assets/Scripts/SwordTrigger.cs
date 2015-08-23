using UnityEngine;
using System.Collections;
public class SwordTrigger : MonoBehaviour {

	public void OnTriggerEnter(Collider other){
		SendMessageUpwards ("ApplySwordDamage",other);
	}
}
