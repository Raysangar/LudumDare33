using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Animator gameOverAnimator;

	private HighScoreManager highScoreManager;
	// Use this for initialization
	void Start () {
        gameOverAnimator.gameObject.SetActive(false);
		highScoreManager = new HighScoreManager ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver()
    {
        SaveCurrentScore ();
        StartCoroutine("GameOverAnimation");
    }

    private IEnumerator GameOverAnimation()
    {
        gameOverAnimator.SetTrigger("GameOver");
        yield return new WaitForSeconds(2.5f);
        NavigationController.Instance.GoToScene(NavigationController.Instance.highScoreScene);
    }

	private void SaveCurrentScore ()
	{
		float score = GameObject.FindGameObjectWithTag ("Player").GetComponent<BloodCollector> ().scoreBlood;
		highScoreManager.SaveScore (score);
	}
}
