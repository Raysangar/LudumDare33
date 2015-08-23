using UnityEngine;
using System.Collections;

public class BleedingSystem : MonoBehaviour {

	public float bleedAmount;

	public GameObject hitBleedEffect;
	public GameObject deadBleedEffect;
	
	public GameObject bleedingPoint;

	private BloodCollector bloodCollector;

	void Start(){
		bloodCollector = GameObject.Find ("BloodCollector").GetComponent<BloodCollector>();
	}


	public void HitBleed(){
		bloodCollector.CollectBlood (bleedAmount);
		Instantiate (hitBleedEffect, bleedingPoint.transform.position,hitBleedEffect.transform.rotation);
	}

	public void DeadBleed(){
		Instantiate (deadBleedEffect, this.transform.position,Quaternion.identity);
	}
}
