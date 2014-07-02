using UnityEngine;
using System.Collections;

public class Resource_alloc_ship : MonoBehaviour {

	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public GUIText fdLabel, waLabel, mtLabel, fuLabel;
	public Country chosenCountry;
	public int sentFood, sentWater, sentMetal, sentOil;

	// Use this for initialization
	void OnEnable () {	
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
	}
	
	// Update is called once per frame
	void Update () {
		sentFood = chosenCountry.foodToShip + chosenCountry.foodToFE + chosenCountry.foodToOF + chosenCountry.foodToUAT + chosenCountry.foodToRN;
		sentWater = chosenCountry.waterToShip + chosenCountry.waterToFE + chosenCountry.waterToOF + chosenCountry.waterToUAT + chosenCountry.waterToRN;	
		sentMetal = chosenCountry.metalToShip + chosenCountry.metalToFE + chosenCountry.metalToOF + chosenCountry.metalToUAT + chosenCountry.metalToRN;	
		sentOil = chosenCountry.oilToShip + chosenCountry.oilToFE + chosenCountry.oilToOF + chosenCountry.oilToUAT + chosenCountry.oilToRN;

		if (fdUP.hold & chosenCountry.stockFood > 0 & sentFood < chosenCountry.stockFood) 
		{
			chosenCountry.foodToShip += 1;
		}
		if (fdDN.hold & chosenCountry.foodToShip > 0) {
			chosenCountry.foodToShip -= 1;
		}
		if (waUP.hold & chosenCountry.stockWater > 0 & sentWater < chosenCountry.stockWater) {
			chosenCountry.waterToShip += 1;
		}
		if (waDN.hold & chosenCountry.waterToShip > 0) {
			chosenCountry.waterToShip -= 1;
		}
		if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) {
			chosenCountry.metalToShip += 1;
		}
		if (mtDN.hold & chosenCountry.metalToShip > 0) {
			chosenCountry.metalToShip -= 1;
		}
		if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) {
			chosenCountry.oilToShip += 1;
		}
		if (fuDN.hold & chosenCountry.oilToShip > 0) {
			chosenCountry.oilToShip -= 1;
		}
	
	}

	void OnGUI (){
		{
			fdLabel.text = chosenCountry.foodToShip.ToString();
			waLabel.text = chosenCountry.waterToShip.ToString();
			mtLabel.text = chosenCountry.metalToShip.ToString();
			fuLabel.text = chosenCountry.oilToShip.ToString();
		}
	}
}
