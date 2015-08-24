using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {
    private bool disappearing;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private GameObject gameManager, canvas, hud;

    [SerializeField]
    private MovementController movementController;

	// Use this for initialization
	void Start () {
        disappearing = false;
        gameManager.SetActive(false);
        hud.SetActive(false);
        movementController.enabled = false;
        canvasGroup = GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Attack") && !disappearing)
            disappearing = true;
        if (disappearing)
        {
            if (canvasGroup.alpha > 0)
                canvasGroup.alpha -= Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                startGame();
            }
        }

	}

    private void startGame()
    {
        gameManager.SetActive(true);
        hud.SetActive(true);
        movementController.enabled = true;
        GameObject.Destroy(canvas);
    }
}
