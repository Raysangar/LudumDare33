using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.Collections;

public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Text theText;
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = Color.white; //Or however you do your color
	}
	
	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.black; //Or however you do your color
	}
}
