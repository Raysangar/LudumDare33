using UnityEngine;
using System.Collections;

public class BleedingSystem : MonoBehaviour {

	public GameObject hitBleedEffect;
	public GameObject deadBleedEffect;
	public GameObject bleedingPoint;

	public void HitBleed(){
		Instantiate (hitBleedEffect, bleedingPoint.transform.position,hitBleedEffect.transform.rotation);
	}

	public void DeadBleed(){
		Instantiate (deadBleedEffect, this.transform.position,Quaternion.identity);
	}
}
