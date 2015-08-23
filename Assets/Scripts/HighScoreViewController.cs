using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HighScoreViewController : MonoBehaviour {

	private NavigationController navController;

	private HighScoreManager highScoreManager;
	private List<float> highScores;

	// Use this for initialization
	void Start () {
		navController = NavigationController.Instance;
		highScoreManager = new HighScoreManager ();
		highScores = highScoreManager.LoadAllScores ();
		Debug.Log (highScores.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void GoToMenuScene(){
		navController.GoToScene (navController.menuScene);
	}


}
