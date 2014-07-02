using UnityEngine;
using System.Collections;

public class Resource_alloc_country : MonoBehaviour {
	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public GUIText fdLabel, waLabel, mtLabel, fuLabel;
	public Country chosenCountry;
	public int selfCountry;

	// Use this for initialization
	void OnEnable () {
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
		if (gameObject.tag == "C1")
		{
			selfCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().C1;
		}
		if (gameObject.tag == "C2")
		{
			selfCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().C2;
		}
		if (gameObject.tag == "C3")
		{
			selfCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().C3;
		}
	}
	
	// Update is called once per frame
	void Update () {
	if (selfCountry == 1)
			{
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
}
