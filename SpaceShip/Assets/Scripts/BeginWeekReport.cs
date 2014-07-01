using UnityEngine;
using System.Collections;


//A prompt after the crisis that tells the player how much resources he/she gained last week
public class BeginWeekReport : MonoBehaviour {

	//Fields
	public GUI_Button reportPrompt;


	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.BeginWeekUpdate) {
			reportPrompt.enabled = true;
			if (reportPrompt.clicked) {
				GameManager.instance.gameState = GameVariableManager.GameState.Management;
			}
		}
		else {
			reportPrompt.enabled = false;
		}
	}
}
