using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private HighScoreManager highScoreManager;
	// Use this for initialization
	void Start () {
		highScoreManager = new HighScoreManager ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver()
    {
		Debug.Log ("Entra aqui");
		SaveCurrentScore ();
        NavigationController.Instance.GoToScene(NavigationController.Instance.highScoreScene);
    }

	private void SaveCurrentScore ()
	{
		float score = GameObject.FindGameObjectWithTag ("Player").GetComponent<BloodCollector> ().scoreBlood;
		highScoreManager.SaveScore (score);
	}
}
