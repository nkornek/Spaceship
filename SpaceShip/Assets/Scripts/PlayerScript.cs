using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//Fields
	public GameVariableManager.CountryType myCountry;
	public Country country;
	public int C1, C2, C3;

	/*
	 * 1= FE
	 * 2= OF
	 * 3= UAT
	 * 4= RN
	 * 
	 */



	// Use this for initialization
	void Start () {
		
	}

	void OnGUI () {
		//if(GUI.Button (new Rect(10, 100, 150, 100), "BECOME OF"))
		//myCountry = GameVariableManager.CountryType.OF;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
