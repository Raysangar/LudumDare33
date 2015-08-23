using UnityEngine;
using System.Collections;

public class BleedingSystem : MonoBehaviour {

	public GameObject hitBleedEffect;
	public GameObject deadBleedEffect;
	public GameObject bleedingPoint;

<<<<<<< HEAD
=======
	private BloodCollector bloodCollector;

	void Start(){
		bloodCollector = GameObject.FindGameObjectWithTag ("Player").GetComponent<BloodCollector>();
	}

>>>>>>> e95c7a811377f281dcfcdbaa5e05fe844c796faa
	public void HitBleed(){
		Instantiate (hitBleedEffect, bleedingPoint.transform.position,hitBleedEffect.transform.rotation);
	}

	public void DeadBleed(){
		Instantiate (deadBleedEffect, this.transform.position,Quaternion.identity);
	}
}
