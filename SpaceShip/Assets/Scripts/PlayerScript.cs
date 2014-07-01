using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//Fields
	public GameVariableManager.CountryType myCountry;




	// Use this for initialization
	void Start () {
		
	}

	void OnGUI () {
		//if(GUI.Button (new Rect(10, 100, 150, 100), "BECOME OF"))
		//myCountry = GameVariableManager.CountryType.OF;
	}


	// Update is called once per frame
	void Update () {
		myCountry = GameObject.Find ("Country Selector").GetComponent<Country_Selector> ().myCountry;
	
	}
}
