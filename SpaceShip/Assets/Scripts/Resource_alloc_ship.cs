using UnityEngine;
using System.Collections;

public class Resource_alloc_ship : MonoBehaviour {

	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public Country chosenCountry;

	// Use this for initialization
	void OnEnable () {	
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
	}
	
	// Update is called once per frame
	void Update () {

		if (fdUP.clicked) {
			chosenCountry.foodToShip += 1;
		}
		if (fdDN.clicked) {
			chosenCountry.foodToShip -= 1;
		}
		if (waUP.clicked) {
			chosenCountry.waterToShip += 1;
		}
		if (waDN.clicked) {
			chosenCountry.waterToShip -= 1;
		}
		if (mtUP.clicked) {
			chosenCountry.metalToShip += 1;
		}
		if (mtDN.clicked) {
			chosenCountry.metalToShip -= 1;
		}
		if (fuUP.clicked) {
			chosenCountry.oilToShip += 1;
		}
		if (fuDN.clicked) {
			chosenCountry.oilToShip -= 1;
		}
	
	}
}
