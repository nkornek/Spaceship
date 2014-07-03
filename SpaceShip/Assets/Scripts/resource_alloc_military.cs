using UnityEngine;
using System.Collections;

public class resource_alloc_military : MonoBehaviour {
	public GUI_Button mtUP, mtDN, fuUP, fuDN;
	public GUIText mtLabel, fuLabel;
	public Country chosenCountry;
	public int sentMetal, sentOil;

	// Use this for initialization
	void OnEnable () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.Management)
		{
		chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript> ().country;
		sentMetal = chosenCountry.metalToShip + chosenCountry.metalToFE + chosenCountry.metalToOF + chosenCountry.metalToUAT + chosenCountry.metalToRN + (int)chosenCountry.metalToMilitary;	
			sentOil = chosenCountry.oilToShip + chosenCountry.oilToFE + chosenCountry.oilToOF + chosenCountry.oilToUAT + chosenCountry.oilToRN + (int)chosenCountry.oilToMilitary;

		mtLabel.text = chosenCountry.metalToMilitary.ToString();
		fuLabel.text = chosenCountry.oilToMilitary.ToString();

		if (mtUP.hold & chosenCountry.stockMetal > 0 & sentMetal < chosenCountry.stockMetal) 
		{
			chosenCountry.metalToMilitary += 1.0f;
		}
		if (mtDN.hold & chosenCountry.metalToMilitary > 0)
		{
			chosenCountry.metalToMilitary -= 1.0f;
		}
		if (fuUP.hold & chosenCountry.stockOil > 0 & sentOil < chosenCountry.stockOil) 
		{
			chosenCountry.oilToMilitary += 1.0f;
		}
		if (fuDN.hold & chosenCountry.oilToMilitary > 0) 
		{
			chosenCountry.oilToMilitary -= 1.0f;
		}
		}
	
	}
}
