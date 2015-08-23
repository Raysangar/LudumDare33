using UnityEngine;
using System.Collections;

public class BloodCollector : MonoBehaviour {

	public float accumulatedBlood;
	// Use this for initialization
	void Start () {
	
	}

	public void CollectBlood(float blood){
		accumulatedBlood += blood;
	}

	public void UseBlood(float blood){
		accumulatedBlood -= blood;
	}
}
