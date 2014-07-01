﻿using UnityEngine;
using System.Collections;

public class GUI_Button : MonoBehaviour {

	//Fields
	public GUITexture buttonTexture;
	public GUIText buttonText;
	public bool enabled, clicked, hold;


	// Use this for initialization
	void Start () {
		enabled = true;
	}


	// Update is called once per frame
	void Update () {
		CheckEnabled ();
		CheckClickedHold ();
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


	//Check if the button is pressed
	void CheckClickedHold () {
		if (enabled && buttonTexture.HitTest (Input.mousePosition)
		    && Input.GetMouseButtonDown(0)) {
			clicked = true;
		}
		else {
			clicked = false;
		}

		if (enabled && buttonTexture.HitTest (Input.mousePosition)
		    && Input.GetMouseButton(0)) {
			hold = true;
		}
		else {
			hold = false;
		}
	}

}