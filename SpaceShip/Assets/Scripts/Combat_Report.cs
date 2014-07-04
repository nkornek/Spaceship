using UnityEngine;
using System.Collections;

public class Combat_Report : MonoBehaviour {

	public GUI_Button reportPrompt;
	public PlayerScript player;

	// Use this for initialization
	void Start () {
		player = GameManager.instance.player;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameManager.instance.player;
		if (GameManager.instance.gameState == GameVariableManager.GameState.Combat) {
			reportPrompt.enabled = true;
			reportPrompt.buttonText.text = "Combat Report: " + 
				"\n\t\t\tFood Stolen: " + player.country.foodStolen + 
					"\n\t\t\tWater Stolen: " + player.country.waterStolen +
						"\n\t\t\tMetal Stolen: " + player.country.metalStolen +
							"\n\t\t\tFuel Stolen: " + player.country.oilStolen +
								"\n\t\t\tTroops Lost: " + player.country.totalSoldierDead +
									"\n\t\t\tCivillian Collateral: " + player.country.collateralDamage;
			if (reportPrompt.clicked) {
				GameManager.instance.gameState = GameVariableManager.GameState.Management;
				player.country.collateralDamage = 0;
				player.country.totalSoldierDead = 0;
			}
		}
		else {
			reportPrompt.enabled = false;
		}
	}
}
