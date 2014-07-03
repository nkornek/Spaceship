using UnityEngine;
using System.Collections;

public class Deploy_Troops_Interface : MonoBehaviour {

	public Country chosenCountry;
	public GUI_Button endDeploy;
	public GUI_Button c1Inc, c1Dec, c2Inc, c2Dec, c3Inc, c3Dec;
	public GUIText c1Label, c2Label, c3Label;
	public GUIText troops1, troops2, troops3, troopReserves, reserveLabel, screenTitle;
	public GameObject c1, c2, c3;
	public GUITexture background;
	public int C1, C2, C3;
	public int troopsToC1, troopsToC2, troopsToC3;
	public int sentTroops, reserveTroops;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.DeployTroops) {
			//enable on start
			c1.SetActive(true);
			c2.SetActive(true);
			c3.SetActive(true);
			background.enabled = endDeploy.enabled = troopReserves.enabled = reserveLabel.enabled = screenTitle.enabled = true;



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
			reserveTroops = chosenCountry.military - sentTroops;

			if (c1Inc.hold & chosenCountry.military > 0 & sentTroops < chosenCountry.military) 
			{
				SendTroops(C1);
				troopsToC1 += 1;
			}
			if (c2Inc.hold & chosenCountry.military > 0 & sentTroops < chosenCountry.military) 
			{
				SendTroops(C2);
				troopsToC2 += 1;
			}
			if (c3Inc.hold & chosenCountry.military > 0 & sentTroops < chosenCountry.military) 
			{
				SendTroops(C3);
				troopsToC3 += 1;
			}
			if (c1Dec.hold & sentTroops > 0 & troopsToC1 > 0) 
			{
				PullTroops(C1);
				troopsToC1 -= 1;
			}
			if (c2Dec.hold & sentTroops > 0 & troopsToC2 > 0) 
			{
				PullTroops(C2);
				troopsToC2 -= 1;
			}
			if (c3Dec.hold & sentTroops > 0 & troopsToC3 > 0) 
			{
				PullTroops(C3);
				troopsToC3 -= 1;
			}
			if (endDeploy.clicked) 
			{
				GameManager.instance.gameState = GameVariableManager.GameState.TransferResources;
			}


		}
		else
		{
			c1.SetActive(false);
			c2.SetActive(false);
			c3.SetActive(false);
			background.enabled = endDeploy.enabled = troopReserves.enabled = reserveLabel.enabled = screenTitle.enabled = false;
		}
	
	}

	void SendTroops(int sentTroops) {
		switch (sentTroops) {
		case 1:
			chosenCountry.troopsToFE += 1;
			break;
		case 2:
			chosenCountry.troopsToOF += 1;
			break;
		case 3:
			chosenCountry.troopsToUAT += 1;
			break;
		case 4:
			chosenCountry.troopsToRN += 1;
			break;
		}
	}
	void PullTroops(int pullTroops){
		switch (pullTroops) {
		case 1:
			chosenCountry.troopsToFE -= 1;
			break;
		case 2:
			chosenCountry.troopsToOF -= 1;
			break;
		case 3:
			chosenCountry.troopsToUAT -= 1;
			break;
		case 4:
			chosenCountry.troopsToRN -= 1;
			break;
		}
	}

	//display numbers
	void OnGUI() {
		troops1.text = troopsToC1.ToString ();
		troops2.text = troopsToC2.ToString ();
		troops3.text = troopsToC3.ToString ();
		troopReserves.text = reserveTroops.ToString ();
	}
}
