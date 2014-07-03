using UnityEngine;
using System.Collections;


//Crisis interface displayed at the beginning of the turn.
//Not fully implemented (like at all)
public class CrisisInterface : MonoBehaviour {

	//Fields
	public GUI_Button situation, solution1, solution2, solution3, solution4;
	public bool enabled;
	public NaturalHazards crisisManager;


	// Use this for initialization
	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
		CheckEnabled ();
		if (GameManager.instance.gameState == GameVariableManager.GameState.Crisis) {
			enabled = true;
			situation.buttonText.text = crisisManager.hazardSentence;
			if (situation.clicked) {
				GameManager.instance.gameState = GameVariableManager.GameState.BeginWeekUpdate;
			}
		}
		else {
			enabled = false;
		}
	}


	//Check whether the interface is enabled and act accordingly
	void CheckEnabled () {
		if (enabled) {
			situation.enabled = solution1.enabled = solution2.enabled = solution3.enabled = solution4.enabled = true;
		}
		else {
			situation.enabled = solution1.enabled = solution2.enabled = solution3.enabled = solution4.enabled = false;
		}
	}
}
