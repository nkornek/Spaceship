using UnityEngine;
using System.Collections;

public class Resource_alloc_country : MonoBehaviour {
	public GUI_Button fdUP, fdDN, waUP, waDN, mtUP, mtDN, fuUP, fuDN;
	public int foodSent, waterSent, metalSent, fuelSent;
	public GUIText fdLabel, waLabel, mtLabel, fuLabel, cntryLabel;
	public GUITexture cntryPic;
	public Country chosenCountry;
	public int selfCountry;
	public int sentFood, sentWater, sentMetal, sentOil;

	// Use this for initialization
	void OnEnable () {
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
		//print (gameObject.tag);
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
		//print (selfCountry);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.Management) {
			//gameObject.SetActive (true);
			CountryResources(selfCountry);
			sentFood = chosenCountry.foodToShip + chosenCountry.foodToFE + chosenCountry.foodToOF + chosenCountry.foodToUAT + chosenCountry.foodToRN;
			sentWater = chosenCountry.waterToShip + chosenCountry.waterToFE + chosenCountry.waterToOF + chosenCountry.waterToUAT + chosenCountry.waterToRN;	
		sentMetal = chosenCountry.metalToShip + chosenCountry.metalToFE + chosenCountry.metalToOF + chosenCountry.metalToUAT + chosenCountry.metalToRN + (int)chosenCountry.metalToMilitary;	
		sentOil = chosenCountry.oilToShip + chosenCountry.oilToFE + chosenCountry.oilToOF + chosenCountry.oilToUAT + chosenCountry.oilToRN + (int)chosenCountry.oilToMilitary;

			if (selfCountry == 1)
			{
				fdLabel.text = chosenCountry.foodToFE.ToString();
				waLabel.text = chosenCountry.waterToFE.ToString();
				mtLabel.text = chosenCountry.metalToFE.ToString();
				fuLabel.text = chosenCountry.oilToFE.ToString();
				cntryLabel.text = "FE";
				cntryPic.texture = cntryPic.GetComponent<Pic>().Textures[0];
				
			}
			else if (selfCountry == 2)
			{
				fdLabel.text = chosenCountry.foodToOF.ToString();
				waLabel.text = chosenCountry.waterToOF.ToString();
				mtLabel.text = chosenCountry.metalToOF.ToString();
				fuLabel.text = chosenCountry.oilToOF.ToString();
				cntryLabel.text = "OF";
				cntryPic.texture = cntryPic.GetComponent<Pic>().Textures[1];
			}
			else if (selfCountry == 3)
			{
				fdLabel.text = chosenCountry.foodToUAT.ToString();
				waLabel.text = chosenCountry.waterToUAT.ToString();
				mtLabel.text = chosenCountry.metalToUAT.ToString();
				fuLabel.text = chosenCountry.oilToUAT.ToString();
				cntryPic.texture = cntryPic.GetComponent<Pic>().Textures[3];
				cntryLabel.text = "UAT";
			}
			else if (selfCountry == 4)
			{
				fdLabel.text = chosenCountry.foodToRN.ToString();
				waLabel.text = chosenCountry.waterToRN.ToString();
				mtLabel.text = chosenCountry.metalToRN.ToString();
				fuLabel.text = chosenCountry.oilToRN.ToString();
				cntryLabel.text = "RN";
				cntryPic.texture = cntryPic.GetComponent<Pic>().Textures[2];
			}
		}
//		else {
//			gameObject.SetActive (false);
//		}
	}

	//set button to correct country
	void CountryResources(int countryButtons){
		switch (countryButtons){
		case 1:
			if (fdUP.hold & chosenCountry.stockFood > 0 & sentFood < chosenCountry.stockFood) 
			{
				chosenCountry.foodToFE += 1;
			}
			if (fdDN.hold & chosenCountry.foodToFE > 0) 
			{
				chosenCountry.foodToFE -= 1;
			}
			if (waUP.hold & chosenCountry.stockWater > 0 & sentWater < chosenCountry.stockWater) 
			{
				chosenCountry.waterToFE += 1;
			}
			if (waDN.hold & chosenCountry.waterToFE > 0) 
			{
				chosenCountry.waterToFE -= 1;
			}
			if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) 
			{
				chosenCountry.metalToFE += 1;
			}
			if (mtDN.hold & chosenCountry.metalToFE > 0)
			{
				chosenCountry.metalToFE -= 1;
			}
			if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) 
			{
				chosenCountry.oilToFE += 1;
			}
			if (fuDN.hold & chosenCountry.oilToFE > 0) 
			{
				chosenCountry.oilToFE -= 1;
			}
			break;
		case 2:
			if (fdUP.hold & chosenCountry.stockFood > 0 & sentFood < chosenCountry.stockFood) 
			{
				chosenCountry.foodToOF += 1;
			}
			if (fdDN.hold & chosenCountry.foodToOF > 0) 
			{
				chosenCountry.foodToOF -= 1;
			}
			if (waUP.hold & chosenCountry.stockWater > 0 & sentWater < chosenCountry.stockWater) 
			{
				chosenCountry.waterToOF += 1;
			}
			if (waDN.hold & chosenCountry.waterToOF > 0) 
			{
				chosenCountry.waterToOF -= 1;
			}
			if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) 
			{
				chosenCountry.metalToOF += 1;
			}
			if (mtDN.hold & chosenCountry.metalToOF > 0)
			{
				chosenCountry.metalToOF -= 1;
			}
			if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) 
			{
				chosenCountry.oilToOF += 1;
			}
			if (fuDN.hold & chosenCountry.oilToOF > 0) 
			{
				chosenCountry.oilToOF -= 1;
			}
			break;
		case 3:
			if (fdUP.hold & chosenCountry.stockFood > 0 & sentFood < chosenCountry.stockFood) 
			{
				chosenCountry.foodToUAT += 1;
			}
			if (fdDN.hold & chosenCountry.foodToUAT > 0) 
			{
				chosenCountry.foodToUAT -= 1;
			}
			if (waUP.hold & chosenCountry.stockWater > 0 & sentWater < chosenCountry.stockWater) 
			{
				chosenCountry.waterToUAT += 1;
			}
			if (waDN.hold & chosenCountry.waterToUAT > 0) 
			{
				chosenCountry.waterToUAT -= 1;
			}
			if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) 
			{
				chosenCountry.metalToUAT += 1;
			}
			if (mtDN.hold & chosenCountry.metalToUAT > 0)
			{
				chosenCountry.metalToUAT -= 1;
			}
			if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) 
			{
				chosenCountry.oilToUAT += 1;
			}
			if (fuDN.hold & chosenCountry.oilToUAT > 0) 
			{
				chosenCountry.oilToUAT -= 1;
			}
			break;
		case 4:
			if (fdUP.hold & chosenCountry.stockFood > 0 & sentFood < chosenCountry.stockFood) 
			{
				chosenCountry.foodToRN += 1;
			}
			if (fdDN.hold & chosenCountry.foodToRN > 0) 
			{
				chosenCountry.foodToRN -= 1;
			}
			if (waUP.hold & chosenCountry.stockWater > 0 & sentWater < chosenCountry.stockWater) 
			{
				chosenCountry.waterToRN += 1;
			}
			if (waDN.hold & chosenCountry.waterToRN > 0) 
			{
				chosenCountry.waterToRN -= 1;
			}
			if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) 
			{
				chosenCountry.metalToRN += 1;
			}
			if (mtDN.hold & chosenCountry.metalToRN > 0)
			{
				chosenCountry.metalToRN -= 1;
			}
			if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) 
			{
				chosenCountry.oilToRN += 1;
			}
			if (fuDN.hold & chosenCountry.oilToRN > 0) 
			{
				chosenCountry.oilToRN -= 1;
			}
			break;
		}
	}
//	void OnGUI (){
//		if (selfCountry == 1)
//		{
//			fdLabel.text = chosenCountry.foodToFE.ToString();
//			waLabel.text = chosenCountry.waterToFE.ToString();
//			mtLabel.text = chosenCountry.metalToFE.ToString();
//			fuLabel.text = chosenCountry.oilToFE.ToString();
//			cntryLabel.text = "FE";
//
//		}
//		else if (selfCountry == 2)
//		{
//			fdLabel.text = chosenCountry.foodToOF.ToString();
//			waLabel.text = chosenCountry.waterToOF.ToString();
//			mtLabel.text = chosenCountry.metalToOF.ToString();
//			fuLabel.text = chosenCountry.oilToOF.ToString();
//			cntryLabel.text = "OF";
//		}
//		else if (selfCountry == 3)
//		{
//			fdLabel.text = chosenCountry.foodToUAT.ToString();
//			waLabel.text = chosenCountry.waterToUAT.ToString();
//			mtLabel.text = chosenCountry.metalToUAT.ToString();
//			fuLabel.text = chosenCountry.oilToUAT.ToString();
//			cntryLabel.text = "UAT";
//		}
//		else if (selfCountry == 4)
//		{
//			fdLabel.text = chosenCountry.foodToRN.ToString();
//			waLabel.text = chosenCountry.waterToRN.ToString();
//			mtLabel.text = chosenCountry.metalToRN.ToString();
//			fuLabel.text = chosenCountry.oilToRN.ToString();
//			cntryLabel.text = "RN";
//		}
//
//	}
}
