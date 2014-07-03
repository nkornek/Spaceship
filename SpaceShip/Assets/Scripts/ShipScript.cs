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

		Vector3 shipBarScale = shipBar.transform.localScale;
		shipBarScale.y = (float)shipCompletion / shipCap * shipBarCap;
		shipBar.transform.localScale = shipBarScale;
	}

	void CheckCompletion () {
		if (shipWater >= 1000 && shipFood >= 1000
		    && shipMetal >= 1000 && shipOil >= 1000) {
			GameManager.instance.shipCompleted = true;
		}
		else {
			GameManager.instance.shipCompleted = false;
		}
	}
}
