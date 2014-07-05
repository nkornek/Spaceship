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
			if (player.country.sentTroops > 0)
			{
			reportPrompt.buttonText.text = "Combat Report: " + 
				"\n\t\t\tFood Stolen: " + player.country.foodStolen + 
					"\n\t\t\tWater Stolen: " + player.country.waterStolen +
						"\n\t\t\tMetal Stolen: " + player.country.metalStolen +
							"\n\t\t\tFuel Stolen: " + player.country.oilStolen +
								"\n\t\t\tDeathbots Lost: " + player.country.totalSoldierDead +
									"\n\t\t\tCivillian Collateral: " + player.country.collateralDamage;
			}
			else if (player.country.military > 0 & player.country.sentTroops == 0)
			{
				reportPrompt.buttonText.text = "Combat Report: " + 
					"\n\t\t\tNo Deathbots Deployed";
			}
			else if (player.country.military == 0)
			{
				reportPrompt.buttonText.text = "Combat Report: " + 
					"\n\t\t\tNo Deathbots Built";
			}
			if (reportPrompt.clicked) {				
				GameManager.instance.gameState = GameVariableManager.GameState.View;
				player.country.collateralDamage = 0;
				player.country.totalSoldierDead = 0;
				//reset all stolen resources
				GameManager.instance.FE.GetComponent<Country>().foodStolen = 0;
				GameManager.instance.FE.GetComponent<Country>().waterStolen = 0;
				GameManager.instance.FE.GetComponent<Country>().metalStolen = 0;
				GameManager.instance.FE.GetComponent<Country>().oilStolen = 0;
				GameManager.instance.OF.GetComponent<Country>().foodStolen = 0;
				GameManager.instance.OF.GetComponent<Country>().waterStolen = 0;
				GameManager.instance.OF.GetComponent<Country>().metalStolen = 0;
				GameManager.instance.OF.GetComponent<Country>().oilStolen = 0;
				GameManager.instance.UAT.GetComponent<Country>().foodStolen = 0;
				GameManager.instance.UAT.GetComponent<Country>().waterStolen = 0;
				GameManager.instance.UAT.GetComponent<Country>().metalStolen = 0;
				GameManager.instance.UAT.GetComponent<Country>().oilStolen = 0;
				GameManager.instance.RN.GetComponent<Country>().foodStolen = 0;
				GameManager.instance.RN.GetComponent<Country>().waterStolen = 0;
				GameManager.instance.RN.GetComponent<Country>().metalStolen = 0;
				GameManager.instance.RN.GetComponent<Country>().oilStolen = 0;

			}
		}
		else {
			reportPrompt.enabled = false;
		}
	}
}
