﻿using UnityEngine;
using System.Collections;


//This is a singleton class that holds the game state amongst other critical info.
//There is only one instance of this class, the instance can be called with:
//GameManager.instance
public class GameManager : MonoBehaviour {

	//Fields
	//Singleton stuff
	private static GameManager _pInstance;
	public static GameManager instance {
		get {
			return _pInstance;
		}
	}

	//The game's game state
	public GameVariableManager.GameState gameState;
	//The four countries and the ship
	public Country FE, OF, UAT, RN;
	public ShipScript ship;
	//The game's total week number (starts with 1)
	public int weekNumber;
	//A pointer to the player
	public PlayerScript player;
	//Relationships between the countries
	public int FE_RN, FE_OF, FE_UAT, OF_UAT, OF_RN, UAT_RN;



	//Awake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	
	// Use this for initialization
	void Start () {
		_pInstance.weekNumber = 0;
		//debug code
		_pInstance.gameState = GameVariableManager.GameState.StartGame;
		_pInstance.FE = GameObject.Find ("FE").GetComponent<Country> ();
		_pInstance.OF = GameObject.Find ("OF").GetComponent<Country> ();
		_pInstance.UAT = GameObject.Find ("UAT").GetComponent<Country> ();
		_pInstance.RN = GameObject.Find ("RN").GetComponent<Country> ();
		_pInstance.ship = GameObject.Find ("Ship").GetComponent<ShipScript> ();
		_pInstance.player = GameObject.Find ("Player").GetComponent<PlayerScript> ();
		_pInstance.FE_OF = _pInstance.FE_RN = _pInstance.FE_UAT = _pInstance.OF_RN =
			_pInstance.OF_UAT = _pInstance.UAT_RN = 100;
	}


	// Update is called once per frame
	void Update () {
		print (_pInstance.weekNumber);
		print (_pInstance.gameState);
		switch (_pInstance.gameState) {
		case GameVariableManager.GameState.TransferResources:
			TransferResources ();
			_pInstance.gameState = GameVariableManager.GameState.ResourceRecap;
			break;
		case GameVariableManager.GameState.AIReact:
			UpdateRelationShips();
			_pInstance.gameState = GameVariableManager.GameState.LookAtStar;
			break;
		}
	}


	//Manager the resource transfers
	void TransferResources () {
		//Decrease the sent resources and total sent resources
		_pInstance.FE.stockFood = _pInstance.FE.stockFood - _pInstance.FE.foodToOF - _pInstance.FE.foodToUAT - _pInstance.FE.foodToShip - _pInstance.FE.foodToShip;
		_pInstance.FE.stockWater = _pInstance.FE.stockWater - _pInstance.FE.waterToOF - _pInstance.FE.waterToUAT - _pInstance.FE.waterToRN - _pInstance.FE.waterToShip;
		_pInstance.FE.stockOil = _pInstance.FE.stockOil - _pInstance.FE.oilToOF - _pInstance.FE.oilToUAT - _pInstance.FE.oilToRN - _pInstance.FE.oilToShip;
		_pInstance.FE.stockMetal = _pInstance.FE.stockMetal - _pInstance.FE.metalToOF - _pInstance.FE.metalToUAT - _pInstance.FE.metalToRN - _pInstance.FE.metalToShip;
		_pInstance.FE.sentFood = _pInstance.FE.foodToOF + _pInstance.FE.foodToUAT + _pInstance.FE.foodToRN + _pInstance.FE.foodToShip;
		_pInstance.FE.sentWater = _pInstance.FE.waterToOF + _pInstance.FE.waterToUAT + _pInstance.FE.waterToRN + _pInstance.FE.waterToShip;
		_pInstance.FE.sentOil = _pInstance.FE.oilToOF + _pInstance.FE.oilToUAT + _pInstance.FE.oilToRN + _pInstance.FE.oilToShip;
		_pInstance.FE.sentMetal = _pInstance.FE.metalToOF + _pInstance.FE.metalToUAT + _pInstance.FE.metalToRN + _pInstance.FE.metalToShip;

		_pInstance.OF.stockFood = _pInstance.OF.stockFood - _pInstance.OF.foodToFE - _pInstance.OF.foodToUAT - _pInstance.OF.foodToShip - _pInstance.OF.foodToShip;
		_pInstance.OF.stockWater = _pInstance.OF.stockWater - _pInstance.OF.waterToFE - _pInstance.OF.waterToUAT - _pInstance.OF.waterToRN - _pInstance.OF.waterToShip;
		_pInstance.OF.stockOil = _pInstance.OF.stockOil - _pInstance.OF.oilToFE - _pInstance.OF.oilToUAT - _pInstance.OF.oilToRN - _pInstance.OF.oilToShip;
		_pInstance.OF.stockMetal = _pInstance.OF.stockMetal - _pInstance.OF.metalToFE - _pInstance.OF.metalToUAT - _pInstance.OF.metalToRN - _pInstance.OF.metalToShip;
		_pInstance.OF.sentFood = _pInstance.OF.foodToFE + _pInstance.OF.foodToUAT + _pInstance.OF.foodToRN + _pInstance.OF.foodToShip;
		_pInstance.OF.sentWater = _pInstance.OF.waterToFE + _pInstance.OF.waterToUAT + _pInstance.OF.waterToRN + _pInstance.OF.waterToShip;
		_pInstance.OF.sentOil = _pInstance.OF.oilToFE + _pInstance.OF.oilToUAT + _pInstance.OF.oilToRN + _pInstance.OF.oilToShip;
		_pInstance.OF.sentMetal = _pInstance.OF.metalToFE + _pInstance.OF.metalToUAT + _pInstance.OF.metalToRN + _pInstance.OF.metalToShip;

		_pInstance.UAT.stockFood = _pInstance.UAT.stockFood - _pInstance.UAT.foodToFE - _pInstance.UAT.foodToOF - _pInstance.UAT.foodToRN - _pInstance.UAT.foodToShip;
		_pInstance.UAT.stockWater = _pInstance.UAT.stockWater - _pInstance.UAT.waterToFE - _pInstance.UAT.waterToOF - _pInstance.UAT.waterToRN - _pInstance.UAT.waterToShip;
		_pInstance.UAT.stockOil = _pInstance.UAT.stockOil - _pInstance.UAT.oilToFE - _pInstance.UAT.oilToOF - _pInstance.UAT.oilToRN - _pInstance.UAT.oilToShip;
		_pInstance.UAT.stockMetal = _pInstance.UAT.stockMetal - _pInstance.UAT.metalToFE - _pInstance.UAT.metalToOF - _pInstance.UAT.metalToRN - _pInstance.UAT.metalToShip;
		_pInstance.UAT.sentFood = _pInstance.UAT.foodToOF + _pInstance.UAT.foodToFE + _pInstance.UAT.foodToRN + _pInstance.UAT.foodToShip;
		_pInstance.UAT.sentWater = _pInstance.UAT.waterToOF + _pInstance.UAT.waterToFE + _pInstance.UAT.waterToRN + _pInstance.UAT.waterToShip;
		_pInstance.UAT.sentOil = _pInstance.UAT.oilToOF + _pInstance.UAT.oilToFE + _pInstance.UAT.oilToRN + _pInstance.UAT.oilToShip;
		_pInstance.UAT.sentMetal = _pInstance.UAT.metalToOF + _pInstance.UAT.metalToFE + _pInstance.UAT.metalToRN + _pInstance.UAT.metalToShip;

		_pInstance.RN.stockFood = _pInstance.RN.stockFood - _pInstance.RN.foodToFE - _pInstance.RN.foodToOF - _pInstance.RN.foodToUAT - _pInstance.RN.foodToShip;
		_pInstance.RN.stockWater = _pInstance.RN.stockWater - _pInstance.RN.waterToFE - _pInstance.RN.waterToOF - _pInstance.RN.waterToUAT - _pInstance.RN.waterToShip;
		_pInstance.RN.stockOil = _pInstance.RN.stockOil - _pInstance.RN.oilToFE - _pInstance.RN.oilToOF - _pInstance.RN.oilToUAT - _pInstance.RN.oilToShip;
		_pInstance.RN.stockMetal = _pInstance.RN.stockMetal - _pInstance.RN.metalToFE - _pInstance.RN.metalToOF - _pInstance.RN.metalToUAT - _pInstance.RN.metalToShip;
		_pInstance.RN.sentFood = _pInstance.RN.foodToOF + _pInstance.RN.foodToUAT + _pInstance.RN.foodToFE + _pInstance.RN.foodToShip;
		_pInstance.RN.sentWater = _pInstance.RN.waterToOF + _pInstance.RN.waterToUAT + _pInstance.RN.waterToFE + _pInstance.RN.waterToShip;
		_pInstance.RN.sentOil = _pInstance.RN.oilToOF + _pInstance.RN.oilToUAT + _pInstance.RN.oilToFE + _pInstance.RN.oilToShip;
		_pInstance.RN.sentMetal = _pInstance.RN.metalToOF + _pInstance.RN.metalToUAT + _pInstance.RN.metalToFE + _pInstance.RN.metalToShip;


		//Increase the received resources
		int prevFoodAmount = _pInstance.FE.stockFood, prevWaterAmount = _pInstance.FE.stockWater, prevOilAmount = _pInstance.FE.stockOil, prevMetalAmount = _pInstance.FE.stockMetal;
		_pInstance.FE.stockFood = _pInstance.FE.stockFood + _pInstance.OF.foodToFE + _pInstance.UAT.foodToFE + _pInstance.RN.foodToFE;
		_pInstance.FE.stockWater = _pInstance.FE.stockWater + _pInstance.OF.waterToFE + _pInstance.UAT.waterToFE + _pInstance.RN.waterToFE;
		_pInstance.FE.stockOil = _pInstance.FE.stockOil + _pInstance.OF.oilToFE + _pInstance.UAT.oilToFE + _pInstance.RN.oilToFE;
		_pInstance.FE.stockMetal = _pInstance.FE.stockMetal + _pInstance.OF.metalToFE + _pInstance.UAT.metalToFE + _pInstance.RN.metalToFE;
		_pInstance.FE.receivedFood = _pInstance.FE.stockFood - prevFoodAmount;
		_pInstance.FE.receivedWater = _pInstance.FE.stockWater - prevWaterAmount;
		_pInstance.FE.receivedOil = _pInstance.FE.stockOil - prevOilAmount;
		_pInstance.FE.receivedMetal = _pInstance.FE.stockMetal - prevMetalAmount;

		prevFoodAmount = _pInstance.OF.stockFood; 
		prevWaterAmount = _pInstance.OF.stockWater; 
		prevOilAmount = _pInstance.OF.stockOil; 
		prevMetalAmount = _pInstance.OF.stockMetal;
		_pInstance.OF.stockFood = _pInstance.OF.stockFood + _pInstance.FE.foodToOF + _pInstance.UAT.foodToOF + _pInstance.RN.foodToOF;
		_pInstance.OF.stockWater = _pInstance.OF.stockWater + _pInstance.FE.waterToOF + _pInstance.UAT.waterToOF + _pInstance.RN.waterToOF;
		_pInstance.OF.stockOil = _pInstance.OF.stockOil + _pInstance.FE.oilToOF + _pInstance.UAT.oilToOF + _pInstance.RN.oilToOF;
		_pInstance.OF.stockMetal = _pInstance.OF.stockMetal + _pInstance.FE.metalToOF + _pInstance.UAT.metalToOF + _pInstance.RN.metalToOF;
		_pInstance.OF.receivedFood = _pInstance.OF.stockFood - prevFoodAmount;
		_pInstance.OF.receivedWater = _pInstance.OF.stockWater - prevWaterAmount;
		_pInstance.OF.receivedOil = _pInstance.OF.stockOil - prevOilAmount;
		_pInstance.OF.receivedMetal = _pInstance.OF.stockMetal - prevMetalAmount;

		prevFoodAmount = _pInstance.UAT.stockFood; 
		prevWaterAmount = _pInstance.UAT.stockWater; 
		prevOilAmount = _pInstance.UAT.stockOil; 
		prevMetalAmount = _pInstance.UAT.stockMetal;
		_pInstance.UAT.stockFood = _pInstance.UAT.stockFood + _pInstance.OF.foodToUAT + _pInstance.FE.foodToUAT + _pInstance.RN.foodToUAT;
		_pInstance.UAT.stockWater = _pInstance.UAT.stockWater + _pInstance.OF.waterToUAT + _pInstance.FE.waterToUAT + _pInstance.RN.waterToUAT;
		_pInstance.UAT.stockOil = _pInstance.UAT.stockOil + _pInstance.OF.oilToUAT + _pInstance.FE.oilToUAT + _pInstance.RN.oilToUAT;
		_pInstance.UAT.stockMetal = _pInstance.UAT.stockMetal + _pInstance.OF.metalToUAT + _pInstance.FE.metalToUAT + _pInstance.RN.metalToFE;
		_pInstance.UAT.receivedFood = _pInstance.UAT.stockFood - prevFoodAmount;
		_pInstance.UAT.receivedWater = _pInstance.UAT.stockWater - prevWaterAmount;
		_pInstance.UAT.receivedOil = _pInstance.UAT.stockOil - prevOilAmount;
		_pInstance.UAT.receivedMetal = _pInstance.UAT.stockMetal - prevMetalAmount;

		prevFoodAmount = _pInstance.RN.stockFood; 
		prevWaterAmount = _pInstance.RN.stockWater; 
		prevOilAmount = _pInstance.RN.stockOil; 
		prevMetalAmount = _pInstance.RN.stockMetal;
		_pInstance.RN.stockFood = _pInstance.RN.stockFood + _pInstance.OF.foodToRN + _pInstance.UAT.foodToRN + _pInstance.FE.foodToRN;
		_pInstance.RN.stockWater = _pInstance.RN.stockWater + _pInstance.OF.waterToRN + _pInstance.UAT.waterToRN + _pInstance.FE.waterToRN;
		_pInstance.RN.stockOil = _pInstance.RN.stockOil + _pInstance.OF.oilToRN + _pInstance.UAT.oilToRN + _pInstance.FE.oilToRN;
		_pInstance.RN.stockMetal = _pInstance.RN.stockMetal + _pInstance.OF.metalToRN + _pInstance.UAT.metalToRN + _pInstance.FE.metalToRN;
		_pInstance.RN.receivedFood = _pInstance.RN.stockFood - prevFoodAmount;
		_pInstance.RN.receivedWater = _pInstance.RN.stockWater - prevWaterAmount;
		_pInstance.RN.receivedOil = _pInstance.RN.stockOil - prevOilAmount;
		_pInstance.RN.receivedMetal = _pInstance.RN.stockMetal - prevMetalAmount;

		//Increased the ship's received resources
		_pInstance.ship.shipFood = _pInstance.FE.foodToShip + _pInstance.OF.foodToShip + _pInstance.UAT.foodToShip + _pInstance.RN.foodToShip;
		_pInstance.ship.shipWater = _pInstance.FE.waterToShip + _pInstance.OF.waterToShip + _pInstance.UAT.waterToShip + _pInstance.RN.waterToShip;
		_pInstance.ship.shipOil = _pInstance.FE.oilToShip + _pInstance.OF.oilToShip + _pInstance.UAT.oilToShip + _pInstance.RN.oilToShip;
		_pInstance.ship.shipMetal = _pInstance.FE.metalToShip + _pInstance.OF.metalToShip + _pInstance.UAT.metalToShip + _pInstance.RN.metalToShip;
	}


	//Update the relationships between the countries
	void UpdateRelationShips () {
		if (_pInstance.FE.metalToOF < 50 || _pInstance.OF.waterToFE < 50) {
			_pInstance.FE_OF -= 25;
			if (_pInstance.FE_OF < 0) {
				_pInstance.FE_OF = 0;
			}
		}
		else if (_pInstance.FE.metalToOF > 75 || _pInstance.OF.waterToFE > 75) {
			if (_pInstance.FE_OF < 75) {
				_pInstance.FE_OF += 25;
			}
			else {
				_pInstance.FE_OF = 100;
			}
		}
		if (_pInstance.FE.metalToUAT < 50 || _pInstance.UAT.foodToFE < 50) {
			if (_pInstance.FE_UAT > 25) {
				_pInstance.FE_UAT -= 25;
			}
			else {
				_pInstance.FE_UAT = 0;
			}
		}
		else if (_pInstance.FE.metalToUAT > 75 || _pInstance.UAT.foodToFE > 75) {
			if (_pInstance.FE_UAT < 75) {
				_pInstance.FE_UAT += 25;
			}
			else {
				_pInstance.FE_UAT = 100;
			}
		}
		if (_pInstance.FE.metalToRN < 50 || _pInstance.RN.oilToFE < 50) {
			if (_pInstance.FE_RN > 25) {
				_pInstance.FE_RN -= 25;
			}
			else {
				_pInstance.FE_RN = 0;
			}
		}
		else if (_pInstance.FE.metalToRN > 75 || _pInstance.RN.oilToFE > 75) {
			if (_pInstance.FE_RN < 75) {
				_pInstance.FE_RN += 25;
			}
			else {
				_pInstance.FE_RN = 100;
			}
		}
		if (_pInstance.OF.waterToRN < 50 || _pInstance.RN.oilToOF < 50) {
			if (_pInstance.OF_RN > 25) {
				_pInstance.OF_RN -= 25;
			}
			else {
				_pInstance.OF_RN = 0;
			}
		}
		else if (_pInstance.OF.waterToRN > 75 || _pInstance.RN.oilToOF > 75) {
			if (_pInstance.OF_RN < 75) {
				_pInstance.OF_RN += 25;
			}
			else {
				_pInstance.OF_RN = 100;
			}
		}
		if (_pInstance.OF.waterToUAT < 50 || _pInstance.UAT.foodToOF < 50) {
			if (_pInstance.OF_UAT > 25) {
				_pInstance.OF_UAT -= 25;
			}
			else {
				_pInstance.OF_UAT = 0;
			}
		}
		else if (_pInstance.OF.waterToUAT > 75 || _pInstance.UAT.foodToOF > 75) {
			if (_pInstance.OF_UAT < 75) {
				_pInstance.OF_UAT += 25;
			}
			else {
				_pInstance.OF_UAT = 100;
			}
		}
		if (_pInstance.UAT.foodToRN < 50 || _pInstance.RN.oilToUAT < 50) {
			if (_pInstance.UAT_RN > 25) {
				_pInstance.UAT_RN -= 25;
			}
			else {
				_pInstance.UAT_RN = 0;
			}
		}
		else if (_pInstance.UAT.foodToRN > 75 || _pInstance.RN.oilToUAT > 75) {
			if (_pInstance.UAT_RN < 75) {
				_pInstance.UAT_RN += 25;
			}
			else {
				_pInstance.UAT_RN = 100;
			}
		}
	}
}
