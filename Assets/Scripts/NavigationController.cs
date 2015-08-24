using UnityEngine;
using System.Collections;

public class NavigationController : Singleton<NavigationController> {
	

	public string menuScene = "MenuScene";
	public string highScoreScene = "HighScoreScene";
	public string gameScene = "Game";


	public void GoToScene(string sceneName){
		Application.LoadLevel (sceneName);
	}
}
