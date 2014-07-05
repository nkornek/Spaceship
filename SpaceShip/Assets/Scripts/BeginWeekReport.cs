using UnityEngine;
using System.Collections;


//A prompt after the crisis that tells the player how much resources he/she gained last week
public class BeginWeekReport : MonoBehaviour {

	//Fields
	public GUI_Button reportPrompt;
	public PlayerScript player;


	// Use this for initialization
	void Start () {
		player = GameManager.instance.player;
	}


	// Update is called once per frame
	void Update () {
		player = GameManager.instance.player;
		if (GameManager.instance.gameState == GameVariableManager.GameState.BeginWeekUpdate) {
			reportPrompt.enabled = true;
			reportPrompt.buttonText.text = "Weekly Report: " + 
				"\n\t\t\tPopulation Change: " + player.country.populationChange + 
					"\n\t\t\tDeathbots Built: " + player.country.militaryBuilt;
			if (reportPrompt.clicked) 
			{
				GameManager.instance.gameState = GameVariableManager.GameState.Combat;
			}
		}
		else {
			reportPrompt.enabled = false;
		}
	}
}
