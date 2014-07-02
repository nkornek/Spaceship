using UnityEngine;
using System.Collections;

public class Resource_alloc_country : MonoBehaviour {
	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public GUIText fdLabel, waLabel, mtLabel, fuLabel, cntryLabel;
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
		CountryResources(selfCountry);
	}

	//set button to correct country
	void CountryResources(int countryButtons){
		switch (countryButtons){
			case 1:
			if (fdUP.hold) {
				chosenCountry.foodToFE += 1;
			}
			if (fdDN.hold) {
				chosenCountry.foodToFE -= 1;
			}
			if (waUP.hold) {
				chosenCountry.waterToFE += 1;
			}
			if (waDN.hold) {
				chosenCountry.waterToFE -= 1;
			}
			if (mtUP.hold) {
				chosenCountry.metalToFE += 1;
			}
			if (mtDN.hold) {
				chosenCountry.metalToFE -= 1;
			}
			if (fuUP.hold) {
				chosenCountry.oilToFE += 1;
			}
			if (fuDN.hold) {
				chosenCountry.oilToFE -= 1;
			}
			break;
		case 2:
			if (fdUP.hold) {
				chosenCountry.foodToOF += 1;
			}
			if (fdDN.hold) {
				chosenCountry.foodToOF -= 1;
			}
			if (waUP.hold) {
				chosenCountry.waterToOF += 1;
			}
			if (waDN.hold) {
				chosenCountry.waterToOF -= 1;
			}
			if (mtUP.hold) {
				chosenCountry.metalToOF += 1;
			}
			if (mtDN.hold) {
				chosenCountry.metalToOF -= 1;
			}
			if (fuUP.hold) {
				chosenCountry.oilToOF += 1;
			}
			if (fuDN.hold) {
				chosenCountry.oilToOF -= 1;
			}
			break;
		case 3:
			if (fdUP.hold) {
				chosenCountry.foodToUAT += 1;
			}
			if (fdDN.hold) {
				chosenCountry.foodToUAT -= 1;
			}
			if (waUP.hold) {
				chosenCountry.waterToUAT += 1;
			}
			if (waDN.hold) {
				chosenCountry.waterToUAT -= 1;
			}
			if (mtUP.hold) {
				chosenCountry.metalToUAT += 1;
			}
			if (mtDN.hold) {
				chosenCountry.metalToUAT -= 1;
			}
			if (fuUP.hold) {
				chosenCountry.oilToUAT += 1;
			}
			if (fuDN.hold) {
				chosenCountry.oilToUAT -= 1;
			}
			break;
		case 4:
			if (fdUP.hold) {
				chosenCountry.foodToRN += 1;
			}
			if (fdDN.hold) {
				chosenCountry.foodToRN -= 1;
			}
			if (waUP.hold) {
				chosenCountry.waterToRN += 1;
			}
			if (waDN.hold) {
				chosenCountry.waterToRN -= 1;
			}
			if (mtUP.hold) {
				chosenCountry.metalToRN += 1;
			}
			if (mtDN.hold) {
				chosenCountry.metalToRN -= 1;
			}
			if (fuUP.hold) {
				chosenCountry.oilToRN += 1;
			}
			if (fuDN.hold) {
				chosenCountry.oilToRN -= 1;
			}
			break;
		}
	}
	void OnGUI (){
		if (selfCountry == 1)
		{
			fdLabel.text = chosenCountry.foodToFE.ToString();
			waLabel.text = chosenCountry.waterToFE.ToString();
			mtLabel.text = chosenCountry.metalToFE.ToString();
			fuLabel.text = chosenCountry.oilToFE.ToString();
			cntryLabel.text = "FE";

		}
		else if (selfCountry == 2)
		{
			fdLabel.text = chosenCountry.foodToOF.ToString();
			waLabel.text = chosenCountry.waterToOF.ToString();
			mtLabel.text = chosenCountry.metalToOF.ToString();
			fuLabel.text = chosenCountry.oilToOF.ToString();
			cntryLabel.text = "OF";
		}
		else if (selfCountry == 3)
		{
			fdLabel.text = chosenCountry.foodToUAT.ToString();
			waLabel.text = chosenCountry.waterToUAT.ToString();
			mtLabel.text = chosenCountry.metalToUAT.ToString();
			fuLabel.text = chosenCountry.oilToUAT.ToString();
			cntryLabel.text = "UAT";
		}
		else if (selfCountry == 4)
		{
			fdLabel.text = chosenCountry.foodToRN.ToString();
			waLabel.text = chosenCountry.waterToRN.ToString();
			mtLabel.text = chosenCountry.metalToRN.ToString();
			fuLabel.text = chosenCountry.oilToRN.ToString();
			cntryLabel.text = "RN";
		}

	}
}
