using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class HighScoreViewController : MonoBehaviour {

	public GameObject highScorePanelElement;
	public GameObject contentPanel;


	private HighScoreManager highScoreManager;
	private List<float> highScores;

	private NavigationController navController;

	// Use this for initialization
	void Start () {
		navController = NavigationController.Instance;
		highScoreManager = new HighScoreManager ();
		highScores = highScoreManager.LoadAllScores ();
		PopulateHighScores ();
	}

	public void GoToMenuScene(){
		navController.GoToScene (navController.menuScene);
	}

	private void PopulateHighScores(){
		foreach (float score in highScores) {
			GameObject hsPanel = Instantiate(highScorePanelElement)as GameObject;
			Text scoreText = hsPanel.GetComponent<HighScorePanelElement>().scoreText;
			scoreText.text = score.ToString();
			hsPanel.transform.SetParent(contentPanel.transform);
		}

	}


}
