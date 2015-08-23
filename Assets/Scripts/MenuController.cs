using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	NavigationController navController;
	// Use this for initialization
	void Start () {
		navController = NavigationController.Instance;
	}

	public void GoToMenuScene(){
		navController.GoToScene (navController.menuScene);
	}
	
	public void GoToHighScoreScene(){
		navController.GoToScene (navController.highScoreScene);
	}
	
	public void GoToGameScene(){
		navController.GoToScene (navController.gameScene);
	}

	public void Close(){
		Application.Quit ();
	}
}
