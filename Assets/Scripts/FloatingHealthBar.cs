using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour {

	public GameObject floatingHealthBarCanvas;
	public Slider floatingHealthBarSlider;
	// Update is called once per frame
	void Update () {
		Billboard ();
	}

	private void Billboard ()
	{
		floatingHealthBarCanvas.transform.rotation = Camera.main.transform.rotation;
	}

	private void UpdateFloatingHealthBar(float value){
		floatingHealthBarSlider.value = value;
	}

}
