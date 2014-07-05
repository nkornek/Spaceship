using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	bool hasUpdated;

	public float shipCompletion;
	public int shipWater, shipOil, shipMetal, shipFood;
	public GameObject shipBar;
	public float shipCap, shipBarCap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShip ();
		CheckCompletion ();
		switch (GameManager.instance.gameState) {
		case GameVariableManager.GameState.BeginWeekUpdate:
			if (!hasUpdated) {
				//print ("New Week Update!");
				//print (ownedResourceType);
				hasUpdated = true;
			}
			break;
		}

		if (shipCompletion >= 200){
			Debug.Log("SHIP COMPLETE");
		}
	
	}

	void UpdateShip () {
		shipCompletion = (shipWater + shipOil + shipMetal + shipFood) / shipCap * shipBarCap;
		//ensure that values do not surpass limit
		if (shipFood > 1500)
		{
			shipFood = 1500;
		}
		if (shipWater > 1500)
		{
			shipWater = 1500;
		}
		if (shipMetal > 1500)
		{
			shipMetal = 1500;
		}
		if (shipOil > 1500)
		{
			shipOil = 1500;
		}
		Vector3 shipBarScale = shipBar.transform.localScale;
		shipBarScale.y = (float)shipCompletion / shipCap * shipBarCap;
		shipBar.transform.localScale = shipBarScale;
	}

	void CheckCompletion () {
		if (shipWater >= 1500 && shipFood >= 1500
		    && shipMetal >= 1500 && shipOil >= 1500) {
			GameManager.instance.shipCompleted = true;
		}
		else {
			GameManager.instance.shipCompleted = false;
		}
	}
}
