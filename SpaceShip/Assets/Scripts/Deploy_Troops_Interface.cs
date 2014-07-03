using UnityEngine;
using System.Collections;

public class Deploy_Troops_Interface : MonoBehaviour {

	public Country chosenCountry;
	public GUI_Button endDeploy;
	public GUI_Button c1Inc, c1Dec, c2Inc, c2Dec, c3Inc, c3Dec;
	public GUIText c1Label, c2Label, c3Label;
	public GUIText troops1, troops2, troops3;
	public GameObject c1, c2, c3;
	public GUITexture background;
	public int C1, C2, C3;
	public int sentTroops;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.DeployTroops) {
			//enable on start
			c1.SetActive(true);
			c2.SetActive(true);
			c2.SetActive(true);
			background.enabled = endDeploy.enabled = true;



			//set country
			chosenCountry = GameObject.Find ("Player").GetComponent<PlayerScript>().country;
			if (C1 == 0 & C2 == 0 & C3 ==0)
			{
				C1 = GameObject.Find("Player").GetComponent<PlayerScript>().C1;
				C2 = GameObject.Find("Player").GetComponent<PlayerScript>().C2;
				C3 = GameObject.Find("Player").GetComponent<PlayerScript>().C3;
			}

			//calculate maximum
			sentTroops = chosenCountry.troopsToFE + chosenCountry.troopsToOF + chosenCountry.troopsToUAT + chosenCountry.troopsToRN;

			if (c1Inc.hold & chosenCountry.military > 0 & sentTroops < chosenCountry.military) 
			{

			}
			if (c1Dec.hold & sentTroops > 0) {

			}


		}
	
	}

	void SendTroops(int countryTroops) {
		switch (countryTroops) {
		case 1:
			chosenCountry.troopsToFE += 1;
			break;

		}
	}
}
