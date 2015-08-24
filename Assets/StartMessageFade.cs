using UnityEngine;
using System.Collections;

public class StartMessageFade : MonoBehaviour {
    private CanvasGroup canvasGroup;
    private bool fadingIn;

    [SerializeField]
    private float timeTillStartFading = 4;

	// Use this for initialization
	void Start () {
        fadingIn = true;
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timeTillStartFading -= Time.deltaTime;
        if (timeTillStartFading > 0) return;

        if (fadingIn)
        {
            canvasGroup.alpha += Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
                fadingIn = false;
            }
        }
        else
        {
            canvasGroup.alpha -= Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                fadingIn = true;
            }
        }
	}
}
