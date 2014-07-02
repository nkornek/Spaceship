using UnityEngine;
using System.Collections;

public class Resource_alloc_ship : MonoBehaviour {

	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public GUIText fdLabel, waLabel, mtLabel, fuLabel;
	public Country chosenCountry;

	// Use this for initialization
	void OnEnable () {	
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
	}
	
	// Update is called once per frame
	void Update () {

		if (fdUP.hold) {
			chosenCountry.foodToShip += 1;
		}
		if (fdDN.hold) {
			chosenCountry.foodToShip -= 1;
		}
		if (waUP.hold) {
			chosenCountry.waterToShip += 1;
		}
		if (waDN.hold) {
			chosenCountry.waterToShip -= 1;
		}
		if (mtUP.hold) {
			chosenCountry.metalToShip += 1;
		}
		if (mtDN.hold) {
			chosenCountry.metalToShip -= 1;
		}
		if (fuUP.hold) {
			chosenCountry.oilToShip += 1;
		}
		if (fuDN.hold) {
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
