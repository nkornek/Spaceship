using UnityEngine;
using System.Collections;

public class ResourceRecapInterface : MonoBehaviour {

	//Fields
	public GUI_Button informationPrompt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.ResourceRecap) {
			informationPrompt.enabled = true;
			informationPrompt.buttonText.text = "Resources report: " +
				"\n\tResources sent: " +
					"\n\t\t\tFood: " + GameManager.instance.player.country.sentFood + 
					"\n\t\t\tWater: " + GameManager.instance.player.country.sentWater + 
					"\n\t\t\tOil: " + GameManager.instance.player.country.sentOil + 
					"\n\t\t\tMetal: " + GameManager.instance.player.country.sentMetal +
				"\n\tResources received: " +
					"\n\t\t\tFood: " + GameManager.instance.player.country.receivedFood + 
					"\n\t\t\tWater: " + GameManager.instance.player.country.receivedWater + 
					"\n\t\t\tOil: " + GameManager.instance.player.country.receivedOil + 
					"\n\t\t\tMetal: " + GameManager.instance.player.country.receivedMetal;

			if (informationPrompt.clicked) {
				GameManager.instance.gameState = GameVariableManager.GameState.AIReact;
			}
		}
		else {
			informationPrompt.enabled = false;
		}
	}
}
