using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {

	//Fields
	public GameObject foodBar, waterBar, oilBar, metalBar;
	public PlayerScript player;
	public float resourceCap, resourceBarCap;
	public float foodReserve, waterReserve, oilReserve, metalReserve ;
	Color foodColor, waterColor, oilColor, metalColor;


	// Use this for initialization
	void Start () {
		foodColor = foodBar.renderer.material.color;
		waterColor = waterBar.renderer.material.color;
		oilColor = oilBar.renderer.material.color;
		metalColor = metalBar.renderer.material.color;
	}

	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.Management) {
			foodReserve = player.country.stockFood - player.country.foodToFE - player.country.foodToOF - player.country.foodToUAT - player.country.foodToRN - player.country.foodToShip;
			waterReserve = player.country.stockWater - player.country.waterToFE - player.country.waterToOF - player.country.waterToUAT - player.country.waterToRN - player.country.waterToShip;
			oilReserve = player.country.stockOil - player.country.oilToFE - player.country.oilToOF - player.country.oilToUAT - player.country.oilToRN - player.country.oilToShip - player.country.oilToMilitary;
			metalReserve = player.country.stockMetal - player.country.metalToFE - player.country.metalToOF - player.country.metalToUAT - player.country.metalToRN - player.country.metalToShip - player.country.metalToMilitary;
			UpdateGraphicsBars ();
			if (foodReserve < 50) {
				foodBar.renderer.material.color = Color.red;
			}
			else {
				foodBar.renderer.material.color = foodColor;
			}

			if (waterReserve < 50) {
				waterBar.renderer.material.color = Color.red;
			}
			else {
				waterBar.renderer.material.color = waterColor;
			}

			if (oilReserve < 50) {
				oilBar.renderer.material.color = Color.red;
			}
			else {
				oilBar.renderer.material.color = oilColor;
			}

			if (metalReserve < 50) {
				metalBar.renderer.material.color = Color.red;
			}
			else {
				metalBar.renderer.material.color = metalColor;
			}
		}
	}


	//Update the graphics bars (ressources, population and military)
	void UpdateGraphicsBars () {
		//ensure that no stock can be shown below 0
		//need to add code later so that players cannot give away more stock than they have
//		if (player.country.stockFood < 0) {player.country.stockFood = 0;}
//		if (player.country.stockMetal < 0) {player.country.stockMetal = 0;}
//		if (player.country.stockOil < 0) {player.country.stockOil = 0;}
//		if (player.country.stockWater < 0) {player.country.stockWater = 0;}
		if (foodReserve < 0)
			foodReserve = 0;
		if (waterReserve < 0)
			waterReserve = 0;
		if (oilReserve < 0)
			oilReserve = 0;
		if (metalReserve < 0)
			metalReserve = 0;


		Vector3 foodBarScale = foodBar.transform.localScale;
		foodBarScale.y = (float)foodReserve / resourceCap * resourceBarCap;
		foodBar.transform.localScale = foodBarScale;
		
		Vector3 waterBarScale = waterBar.transform.localScale;
		waterBarScale.y = (float)waterReserve / resourceCap * resourceBarCap;
		waterBar.transform.localScale = waterBarScale;
		
		Vector3 oilBarScale = oilBar.transform.localScale;
		oilBarScale.y = (float)oilReserve / resourceCap * resourceBarCap;
		oilBar.transform.localScale = oilBarScale;
		
		Vector3 metalBarScale = metalBar.transform.localScale;
		metalBarScale.y = (float)metalReserve / resourceCap * resourceBarCap;
		metalBar.transform.localScale = metalBarScale;
		
//		Vector3 populationBarScale = player.country.populationBar.transform.localScale;
//		populationBarScale.y = (float)player.country.population / player.country.populationCap * player.country.populationBarCap;
//		player.country.populationBar.transform.localScale = populationBarScale;
		
//		Vector3 militaryBarScale = militaryBar.transform.localScale;
//		militaryBarScale.y = (float)military / militaryCap * militaryBarCap;
//		militaryBar.transform.localScale = militaryBarScale;
	}
}
