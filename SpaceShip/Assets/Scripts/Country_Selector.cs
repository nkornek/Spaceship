using UnityEngine;
using System.Collections;

public class Country_Selector : MonoBehaviour {

	public bool countrySelected;
	public GUI_Button OFbutton, FEbutton, RNbutton, UATbutton;
	public Country FE, OF, UAT, RN;
	public GameObject player;

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
		if (GameManager.instance.gameState == GameVariableManager.GameState.StartGame) {
			if (OFbutton.clicked == true)
			{
				countrySelected = true;
				player.GetComponent<PlayerScript>().country = OF;
				player.GetComponent<PlayerScript>().C1 = 1;
				player.GetComponent<PlayerScript>().C2 = 4;
				player.GetComponent<PlayerScript>().C3 = 3;
				GameObject.Find("FE").GetComponent<Country>().isAI = true;
				GameObject.Find("RN").GetComponent<Country>().isAI = true;
				GameObject.Find("UAT").GetComponent<Country>().isAI = true;
				GameManager.instance.gameState = GameVariableManager.GameState.LookAtStar;
			}
			if(FEbutton.clicked == true)
			{
				countrySelected = true;
				player.GetComponent<PlayerScript>().country = FE;
				player.GetComponent<PlayerScript>().C1 = 2;
				player.GetComponent<PlayerScript>().C2 = 4;
				player.GetComponent<PlayerScript>().C3 = 3;
				GameObject.Find("OF").GetComponent<Country>().isAI = true;
				GameObject.Find("RN").GetComponent<Country>().isAI = true;
				GameObject.Find("UAT").GetComponent<Country>().isAI = true;
				GameManager.instance.gameState = GameVariableManager.GameState.LookAtStar;
			}
			if(RNbutton.clicked == true)
			{
				countrySelected = true;	
				player.GetComponent<PlayerScript>().country = RN;
				player.GetComponent<PlayerScript>().C1 = 1;
				player.GetComponent<PlayerScript>().C2 = 2;
				player.GetComponent<PlayerScript>().C3 = 3;		
				GameObject.Find("FE").GetComponent<Country>().isAI = true;
				GameObject.Find("OF").GetComponent<Country>().isAI = true;
				GameObject.Find("UAT").GetComponent<Country>().isAI = true;
				GameManager.instance.gameState = GameVariableManager.GameState.LookAtStar;
			}
			if(UATbutton.clicked == true)
			{
				countrySelected = true;
				player.GetComponent<PlayerScript>().country = UAT;
				player.GetComponent<PlayerScript>().C1 = 1;
				player.GetComponent<PlayerScript>().C2 = 4;
				player.GetComponent<PlayerScript>().C3 = 2;
				GameObject.Find("FE").GetComponent<Country>().isAI = true;
				GameObject.Find("RN").GetComponent<Country>().isAI = true;
				GameObject.Find("OF").GetComponent<Country>().isAI = true;
				GameManager.instance.gameState = GameVariableManager.GameState.LookAtStar;
			}
		}
	
	}
}
