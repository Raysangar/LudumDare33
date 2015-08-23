using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodCollector : MonoBehaviour {

	public Text bloodCounter;
	public Slider summonBar;

	public float scoreBlood;

	public float currentBloodForSummon;
	public float maxBloodForSummon;
	
	// Use this for initialization
	void Start () {
	
	}



	public void CollectBlood(float blood){
		scoreBlood += blood;
		currentBloodForSummon += blood;

		if (currentBloodForSummon > maxBloodForSummon) {
			currentBloodForSummon = maxBloodForSummon;
		}

		UpdateSummonBar ();
		UpdateCounter ();
	}

	public void UseBlood(float blood){
		currentBloodForSummon = 0;
		UpdateSummonBar ();
	}

	private void UpdateCounter(){
		//bloodCounter.text = accumulatedBlood.ToString ();
	}

	private void UpdateSummonBar(){
		summonBar.value = currentBloodForSummon / maxBloodForSummon;
	}
}
