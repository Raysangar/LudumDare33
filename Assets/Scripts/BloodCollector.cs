using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodCollector : MonoBehaviour {

	public Text bloodCounter;

	public float accumulatedBlood;
	// Use this for initialization
	void Start () {
	
	}

	public void CollectBlood(float blood){
		accumulatedBlood += blood;
		UpdateCounter ();
	}

	public void UseBlood(float blood){
		accumulatedBlood -= blood;
		UpdateCounter ();
	}

	private void UpdateCounter(){
		bloodCounter.text = accumulatedBlood.ToString ();
	}
}
