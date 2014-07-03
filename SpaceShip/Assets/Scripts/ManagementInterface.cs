using UnityEngine;
using System.Collections;

public class ManagementInterface : MonoBehaviour {

	//Fields
	public Resource_alloc_ship shipPrompt;
	public Resource_alloc_country countryPrompt1, countryPrompt2, countryPrompt3;
	public GUITexture background;
	public GUI_Button endManagement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.Management) {
			shipPrompt.gameObject.SetActive (true);
			countryPrompt1.gameObject.SetActive (true);
			countryPrompt2.gameObject.SetActive (true);
			countryPrompt3.gameObject.SetActive (true);
			background.enabled = endManagement.enabled = true;

			if (endManagement.clicked) {
				GameManager.instance.gameState = GameVariableManager.GameState.TransferResources;
			}
		}
		else {
			shipPrompt.gameObject.SetActive (false);
			countryPrompt1.gameObject.SetActive (false);
			countryPrompt2.gameObject.SetActive (false);
			countryPrompt3.gameObject.SetActive (false);
			background.enabled = endManagement.enabled = false;
		}
	
	}
}
