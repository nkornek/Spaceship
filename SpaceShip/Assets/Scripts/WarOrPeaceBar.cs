using UnityEngine;
using System.Collections;

public class WarOrPeaceBar : MonoBehaviour {

	public int civilizedMeter;
	public bool civilized; 

	public Country[] countries; // 
	NaturalHazards nh;
	bool hasUpdated;
	float ambientLightRed;

	// Use this for initialization
	void Start () {
		civilizedMeter = 100;
		ambientLightRed = RenderSettings.ambientLight.r;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(civilizedMeter < 50)
		{
			civilized = false;
		}

		if (GameManager.instance.gameState == GameVariableManager.GameState.LookAtStar) {
			if (!hasUpdated) {
				updateBar();
				UpdateAmbientLight();
				hasUpdated = true;
			}
		}
		else {
			hasUpdated = false;
		}
	}

	void setPlayerArray(Country []p) // copies the country array from the scene 
	{
		countries = new Country[p.Length];
		for(int i = 0; i < p.Length; i++)
		{
			countries[i] = p[i];
		}
	}

	//Update the civilization scale according to the relationships
	public void updateBar() {
		if (GameManager.instance.FE_OF < 15 || GameManager.instance.FE_RN < 15 ||
		    GameManager.instance.FE_UAT < 15 || GameManager.instance.OF_UAT < 15 ||
		    GameManager.instance.OF_RN < 15 || GameManager.instance.UAT_RN < 15) {
			civilizedMeter -= 10;
		}
		else if (GameManager.instance.FE_OF < 30 || GameManager.instance.FE_RN < 30 ||
		    GameManager.instance.FE_UAT < 30 || GameManager.instance.OF_UAT < 30 ||
		    GameManager.instance.OF_RN < 30 || GameManager.instance.UAT_RN < 30) {
			civilizedMeter -= 5;
		}
		else if (GameManager.instance.FE_OF < 50 || GameManager.instance.FE_RN < 50 ||
		         GameManager.instance.FE_UAT < 50 || GameManager.instance.OF_UAT < 50 ||
		         GameManager.instance.OF_RN < 50 || GameManager.instance.UAT_RN < 50) {
			civilizedMeter -= 3;
		}
	}

	//Update the ambientlight based on the civilization scale
	public void UpdateAmbientLight() {
		Color temp = RenderSettings.ambientLight;
		temp.r = ambientLightRed * ((float)civilizedMeter / 100f);
		RenderSettings.ambientLight = temp;
	}



}
