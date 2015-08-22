using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SealController : MonoBehaviour {

	public float fillSpeed;
	public GameObject seal;

	public Image[] sealParts;

	bool fillPart1 = false;
	bool fillPart2 = false;
	bool fillPart3 = false;
	
	// Use this for initialization
	void Start () {
		GetSealParts ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			fillPart1 = true;
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			fillPart2 = true;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			fillPart3 = true;
		}

		if (fillPart1) {
			FillRadialImage(sealParts[1]);
		}
		if (fillPart2) {
			FillRadialImage(sealParts[2]);
		}
		if (fillPart3) {
			FillRadialImage(sealParts[3]);
		}
	}


	private void SealSide(){
	}

	private void FillRadialImage(Image image){
		image.fillAmount += Time.deltaTime/fillSpeed;
	}

	private void GetSealParts(){
		sealParts = seal.GetComponentsInChildren<Image>();
	}
}
