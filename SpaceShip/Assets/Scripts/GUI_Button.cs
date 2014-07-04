using UnityEngine;
using System.Collections;

public class GUI_Button : MonoBehaviour {

	//Fields
	public GUITexture buttonTexture;
	public GUITexture hoverTexture;
	public GUITexture holdTexture;
	public GUIText buttonText;
	public bool enabled, clicked, hold, hovered;


	// Use this for initialization
	void Start () {
		enabled = true;
	}


	// Update is called once per frame
	void Update () {
		CheckEnabled ();
		CheckClickedHold ();
		if (hoverTexture) {
			Hover();
		}
		if (holdTexture){
			CheckClickedHold();
		}
//		if (clicked) {
//			print ("Clicked");
//		}
	}


	//Check if the button is enabled or not
	void CheckEnabled () {
		if (enabled) {
			buttonText.enabled = buttonTexture.enabled = true;
		}
		else {
			buttonText.enabled = buttonTexture.enabled = false;
		}
	}

	void Hover() {
		if (enabled && buttonTexture.HitTest (Input.mousePosition)){
			hovered = true;
			buttonTexture.enabled = false;
			hoverTexture.enabled = true;
		} else {
			hovered = false;
			buttonTexture.enabled = true;
			hoverTexture.enabled = false;
		}
	}


	//Check if the button is pressed
	void CheckClickedHold () {
		if (enabled && buttonTexture.HitTest (Input.mousePosition)
		    && Input.GetMouseButtonDown(0)) {
			clicked = true;
			holdTexture.enabled = true;
		}
		else {
			clicked = false;
			holdTexture.enabled = false;
		}

		if (enabled && buttonTexture.HitTest (Input.mousePosition)
		    && Input.GetMouseButton(0)) {
			hold = true;
			holdTexture.enabled = true;
		}
		else {
			hold = false;
			holdTexture.enabled = false;
		}
	}

}
