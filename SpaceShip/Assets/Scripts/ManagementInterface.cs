using UnityEngine;
using System.Collections;

public class ManagementInterface : MonoBehaviour {

	//Fields
	public Resource_alloc_ship shipPrompt;
	public Resource_alloc_country countryPrompt1, countryPrompt2, countryPrompt3;
	public resource_alloc_military militaryPrompt;
	public GUITexture background;
	public GUI_Button endManagement;
	public GameObject ship, C1, C2, C3;
	public Country chosenCountry;
	public int sentFood, sentWater, sentOil, sentMetal;

	// Use this for initialization
//	void OnEnable () {
//		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript>().country;
//		//reset stocks if sent is greater than stock
//		if (chosenCountry.GetComponent<Country>().sentFood > chosenCountry.stockFood)
//		{
//			chosenCountry.foodToShip = 0;
//			chosenCountry.foodToFE = 0;
//			chosenCountry.foodToOF = 0;
//			chosenCountry.foodToUAT = 0;
//			chosenCountry.foodToRN = 0;
//		}
//		if (chosenCountry.GetComponent<Country>().sentWater > chosenCountry.stockWater)
//		{
//			chosenCountry.waterToShip = 0;
//			chosenCountry.waterToFE = 0;
//			chosenCountry.waterToOF = 0;
//			chosenCountry.waterToUAT = 0;
//			chosenCountry.waterToRN = 0;
//		}
//		if (chosenCountry.GetComponent<Country>().sentMetal > chosenCountry.stockMetal)
//		{
//			chosenCountry.metalToShip = 0;
//			chosenCountry.metalToFE = 0;
//			chosenCountry.metalToOF = 0;
//			chosenCountry.metalToUAT = 0;
//			chosenCountry.metalToRN = 0;
//		}
//		if (chosenCountry.GetComponent<Country>().sentOil > chosenCountry.stockOil)
//		{
//			chosenCountry.oilToShip = 0;
//			chosenCountry.oilToFE = 0;
//			chosenCountry.oilToOF = 0;
//			chosenCountry.oilToUAT = 0;
//			chosenCountry.oilToRN = 0;
//		}
//
//	
//	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.gameState == GameVariableManager.GameState.Management) {
			shipPrompt.gameObject.SetActive (true);
			countryPrompt1.gameObject.SetActive (true);
			countryPrompt2.gameObject.SetActive (true);
			countryPrompt3.gameObject.SetActive (true);
			militaryPrompt.gameObject.SetActive (true);
			background.enabled = endManagement.enabled = true;

			//Resets resources to zero if there's not enough
			chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript>().country;
			//reset stocks if sent is greater than stock
			sentFood = chosenCountry.foodToShip + chosenCountry.foodToFE + chosenCountry.foodToOF + chosenCountry.foodToUAT + chosenCountry.foodToRN;
			sentWater = chosenCountry.waterToShip + chosenCountry.waterToFE + chosenCountry.waterToOF + chosenCountry.waterToUAT + chosenCountry.waterToRN;	
			sentMetal = chosenCountry.metalToShip + chosenCountry.metalToFE + chosenCountry.metalToOF + chosenCountry.metalToUAT + chosenCountry.metalToRN + (int)chosenCountry.metalToMilitary;	
			sentOil = chosenCountry.oilToShip + chosenCountry.oilToFE + chosenCountry.oilToOF + chosenCountry.oilToUAT + chosenCountry.oilToRN + (int)chosenCountry.oilToMilitary;

			if (sentFood > chosenCountry.stockFood)
			{
				chosenCountry.foodToShip = 0;
				chosenCountry.foodToFE = 0;
				chosenCountry.foodToOF = 0;
				chosenCountry.foodToUAT = 0;
				chosenCountry.foodToRN = 0;

			}
			if (sentWater > chosenCountry.stockWater)
			{
				chosenCountry.waterToShip = 0;
				chosenCountry.waterToFE = 0;
				chosenCountry.waterToOF = 0;
				chosenCountry.waterToUAT = 0;
				chosenCountry.waterToRN = 0;
			}
			if (sentMetal > chosenCountry.stockMetal)
			{
				chosenCountry.metalToShip = 0;
				chosenCountry.metalToFE = 0;
				chosenCountry.metalToOF = 0;
				chosenCountry.metalToUAT = 0;
				chosenCountry.metalToRN = 0;
				chosenCountry.metalToMilitary = 0;
			}
			if (sentOil > chosenCountry.stockOil)
			{
				chosenCountry.oilToShip = 0;
				chosenCountry.oilToFE = 0;
				chosenCountry.oilToOF = 0;
				chosenCountry.oilToUAT = 0;
				chosenCountry.oilToRN = 0;
				chosenCountry.oilToMilitary = 0;
			}

			if (endManagement.clicked) {
				if (chosenCountry.military == 0)
				{
					GameManager.instance.gameState = GameVariableManager.GameState.TransferResources;
				}
				else
				{
					GameManager.instance.gameState = GameVariableManager.GameState.DeployTroops;
				}
			}
		}
		else {
			shipPrompt.gameObject.SetActive (false);
			countryPrompt1.gameObject.SetActive (false);
			countryPrompt2.gameObject.SetActive (false);
			countryPrompt3.gameObject.SetActive (false);
			militaryPrompt.gameObject.SetActive (false);
			background.enabled = endManagement.enabled = false;
		}
	
	}
}
