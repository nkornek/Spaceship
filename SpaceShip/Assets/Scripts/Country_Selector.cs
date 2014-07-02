using UnityEngine;
using System.Collections;

public class Country_Selector : MonoBehaviour {

	public bool countrySelected;
	public GameVariableManager.CountryType myCountry;
	public GUI_Button OFbutton, FEbutton, RNbutton, UATbutton;

	// Use this for initialization
	void Start () {
		countrySelected = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (countrySelected == true)
		{
			gameObject.SetActive(false);
		}
		if(OFbutton.clicked == true)
		{
			countrySelected = true;
			myCountry = GameVariableManager.CountryType.OF;
			GameObject.Find("FE").GetComponent<Country>().isAI = true;
			GameObject.Find("RN").GetComponent<Country>().isAI = true;
			GameObject.Find("UAT").GetComponent<Country>().isAI = true;
		}
		if(FEbutton.clicked == true)
		{
			countrySelected = true;
			myCountry = GameVariableManager.CountryType.FE;
			GameObject.Find("OF").GetComponent<Country>().isAI = true;
			GameObject.Find("RN").GetComponent<Country>().isAI = true;
			GameObject.Find("UAT").GetComponent<Country>().isAI = true;
		}
		if(RNbutton.clicked == true)
		{
			countrySelected = true;
			myCountry = GameVariableManager.CountryType.RN;
			
			GameObject.Find("FE").GetComponent<Country>().isAI = true;
			GameObject.Find("OF").GetComponent<Country>().isAI = true;
			GameObject.Find("UAT").GetComponent<Country>().isAI = true;
		}
		if(UATbutton.clicked == true)
		{
			countrySelected = true;
			myCountry = GameVariableManager.CountryType.UAT;
			GameObject.Find("FE").GetComponent<Country>().isAI = true;
			GameObject.Find("RN").GetComponent<Country>().isAI = true;
			GameObject.Find("OF").GetComponent<Country>().isAI = true;
		}
	
	}
}
