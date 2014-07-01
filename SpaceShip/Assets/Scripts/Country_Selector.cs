using UnityEngine;
using System.Collections;

public class Country_Selector : MonoBehaviour {

	public bool countrySelected;
	public Country myCountry;
	public GUI_Button OFbutton, FEbutton, RNbutton, UATbutton;

	// Use this for initialization
	void Start () {
		countrySelected = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(OFbutton.clicked == true)
		{
			myCountry = GameVariableManager.CountryType.OF;
			GameObject.Find("Player").GetComponent<PlayerScript>().ownedCountry = myCountry;

		}
	
	}
}
