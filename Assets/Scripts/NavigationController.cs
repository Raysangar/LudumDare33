using UnityEngine;
using System.Collections;

public class NavigationController : Singleton<NavigationController> {
	

	public string menuScene = "MecanimTest";
	public string highScoreScene = "HighScoreScene";
	public string gameScene = "GameScene";


	public void GoToScene(string sceneName){
		Application.LoadLevel (sceneName);
	}
}
