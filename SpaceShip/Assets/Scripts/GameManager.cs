using UnityEngine;
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



	//Awake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	
	// Use this for initialization
	void Start () {
		_pInstance.weekNumber = 1;
		//debug code
		_pInstance.gameState = GameVariableManager.GameState.Crisis;
	}


	// Update is called once per frame
	void Update () {
		switch (_pInstance.gameState) {
		case GameVariableManager.GameState.TransferResources:

			//FE.stockWater = FE.stockWater - 
			break;
		}
	}


	//Manager the resource transfers
	void TransferResources () {
		//Decrease the sent resources and total sent resources
		FE.stockFood = FE.stockFood - FE.foodToOF - FE.foodToUAT - FE.foodToShip - FE.foodToShip;
		FE.stockWater = FE.stockWater - FE.waterToOF - FE.waterToUAT - FE.waterToRN - FE.waterToShip;
		FE.stockOil = FE.stockOil - FE.oilToOF - FE.oilToUAT - FE.oilToRN - FE.oilToShip;
		FE.stockMetal = FE.stockMetal - FE.metalToOF - FE.metalToUAT - FE.metalToRN - FE.metalToShip;
		FE.sentFood = FE.foodToOF + FE.foodToUAT + FE.foodToRN + FE.foodToShip;
		FE.sentWater = FE.waterToOF + FE.waterToUAT + FE.waterToRN + FE.waterToShip;
		FE.sentOil = FE.oilToOF + FE.oilToUAT + FE.oilToRN + FE.oilToShip;
		FE.sentMetal = FE.metalToOF + FE.metalToUAT + FE.metalToRN + FE.metalToShip;

		OF.stockFood = OF.stockFood - OF.foodToFE - OF.foodToUAT - OF.foodToShip - OF.foodToShip;
		OF.stockWater = OF.stockWater - OF.waterToFE - OF.waterToUAT - OF.waterToRN - OF.waterToShip;
		OF.stockOil = OF.stockOil - OF.oilToFE - OF.oilToUAT - OF.oilToRN - OF.oilToShip;
		OF.stockMetal = OF.stockMetal - OF.metalToFE - OF.metalToUAT - OF.metalToRN - OF.metalToShip;
		OF.sentFood = OF.foodToFE + OF.foodToUAT + OF.foodToRN + OF.foodToShip;
		OF.sentWater = OF.waterToFE + OF.waterToUAT + OF.waterToRN + OF.waterToShip;
		OF.sentOil = OF.oilToFE + OF.oilToUAT + OF.oilToRN + OF.oilToShip;
		OF.sentMetal = OF.metalToFE + OF.metalToUAT + OF.metalToRN + OF.metalToShip;

		UAT.stockFood = UAT.stockFood - UAT.foodToFE - UAT.foodToOF - UAT.foodToRN - UAT.foodToShip;
		UAT.stockWater = UAT.stockWater - UAT.waterToFE - UAT.waterToOF - UAT.waterToRN - UAT.waterToShip;
		UAT.stockOil = UAT.stockOil - UAT.oilToFE - UAT.oilToOF - UAT.oilToRN - UAT.oilToShip;
		UAT.stockMetal = UAT.stockMetal - UAT.metalToFE - UAT.metalToOF - UAT.metalToRN - OF.metalToShip;
		UAT.sentFood = UAT.foodToOF + UAT.foodToFE + UAT.foodToRN + UAT.foodToShip;
		UAT.sentWater = UAT.waterToOF + UAT.waterToFE + UAT.waterToRN + UAT.waterToShip;
		UAT.sentOil = UAT.oilToOF + UAT.oilToFE + UAT.oilToRN + UAT.oilToShip;
		UAT.sentMetal = UAT.metalToOF + UAT.metalToFE + UAT.metalToRN + FE.metalToShip;

		RN.stockFood = RN.stockFood - RN.foodToFE - RN.foodToOF - RN.foodToUAT - RN.foodToShip;
		RN.stockWater = RN.stockWater - RN.waterToFE - RN.waterToOF - RN.waterToUAT - RN.waterToShip;
		RN.stockOil = RN.stockOil - RN.oilToFE - RN.oilToOF - RN.oilToUAT - RN.oilToShip;
		RN.stockMetal = RN.stockMetal - RN.metalToFE - RN.metalToOF - RN.metalToUAT - OF.metalToShip;
		RN.sentFood = RN.foodToOF + RN.foodToUAT + RN.foodToFE + RN.foodToShip;
		RN.sentWater = RN.waterToOF + RN.waterToUAT + RN.waterToFE + RN.waterToShip;
		RN.sentOil = RN.oilToOF + RN.oilToUAT + RN.oilToFE + RN.oilToShip;
		RN.sentMetal = RN.metalToOF + RN.metalToUAT + RN.metalToFE + RN.metalToShip;


		//Increase the received resources
		int prevFoodAmount = FE.stockFood, prevWaterAmount = FE.stockWater, prevOilAmount = FE.stockOil, prevMetalAmount = FE.stockMetal;
		FE.stockFood = FE.stockFood + OF.foodToFE + UAT.foodToFE + RN.foodToFE;
		FE.stockWater = FE.stockWater + FE.waterToOF + FE.waterToUAT + FE.waterToRN + FE.waterToShip;
		FE.stockOil = FE.stockOil + FE.oilToOF + FE.oilToUAT + FE.oilToRN + FE.oilToShip;
		FE.stockMetal = FE.stockMetal + FE.metalToOF + FE.metalToUAT + FE.metalToRN + FE.metalToShip;
		FE.receivedFood = FE.stockFood - prevFoodAmount;
		FE.receivedWater = FE.stockWater - prevWaterAmount;
		FE.receivedOil = FE.stockOil - prevOilAmount;
		FE.receivedMetal = FE.stockMetal - prevMetalAmount;

		prevFoodAmount = OF.stockFood; 
		prevWaterAmount = OF.stockWater; 
		prevOilAmount = OF.stockOil; 
		prevMetalAmount = OF.stockMetal;
		OF.stockFood = OF.stockFood + OF.foodToFE + OF.foodToUAT + OF.foodToShip + OF.foodToShip;
		OF.stockWater = OF.stockWater + OF.waterToFE + OF.waterToUAT + OF.waterToRN + OF.waterToShip;
		OF.stockOil = OF.stockOil + OF.oilToFE + OF.oilToUAT + OF.oilToRN + OF.oilToShip;
		OF.stockMetal = OF.stockMetal + OF.metalToFE + OF.metalToUAT + OF.metalToRN + OF.metalToShip;
		OF.receivedFood = OF.stockFood - prevFoodAmount;
		OF.receivedWater = OF.stockWater - prevWaterAmount;
		OF.receivedOil = OF.stockOil - prevOilAmount;
		OF.receivedMetal = OF.stockMetal - prevMetalAmount;

		prevFoodAmount = UAT.stockFood; 
		prevWaterAmount = UAT.stockWater; 
		prevOilAmount = UAT.stockOil; 
		prevMetalAmount = UAT.stockMetal;
		UAT.stockFood = UAT.stockFood + UAT.foodToFE + UAT.foodToOF + UAT.foodToRN + UAT.foodToShip;
		UAT.stockWater = UAT.stockWater + UAT.waterToFE + UAT.waterToOF + UAT.waterToRN + UAT.waterToShip;
		UAT.stockOil = UAT.stockOil + UAT.oilToFE + UAT.oilToOF + UAT.oilToRN + UAT.oilToShip;
		UAT.stockMetal = UAT.stockMetal + UAT.metalToFE + UAT.metalToOF + UAT.metalToRN + OF.metalToShip;
		UAT.receivedFood = UAT.stockFood - prevFoodAmount;
		UAT.receivedWater = UAT.stockWater - prevWaterAmount;
		UAT.receivedOil = UAT.stockOil - prevOilAmount;
		UAT.receivedMetal = UAT.stockMetal - prevMetalAmount;

		prevFoodAmount = RN.stockFood; 
		prevWaterAmount = RN.stockWater; 
		prevOilAmount = RN.stockOil; 
		prevMetalAmount = RN.stockMetal;
		RN.stockFood = RN.stockFood + RN.foodToFE + RN.foodToOF + RN.foodToUAT + RN.foodToShip;
		RN.stockWater = RN.stockWater + RN.waterToFE + RN.waterToOF + RN.waterToUAT + RN.waterToShip;
		RN.stockOil = RN.stockOil + RN.oilToFE + RN.oilToOF + RN.oilToUAT + RN.oilToShip;
		RN.stockMetal = RN.stockMetal + RN.metalToFE + RN.metalToOF + RN.metalToUAT + OF.metalToShip;
		RN.receivedFood = RN.stockFood - prevFoodAmount;
		RN.receivedWater = RN.stockWater - prevWaterAmount;
		RN.receivedOil = RN.stockOil - prevOilAmount;
		RN.receivedMetal = RN.stockMetal - prevMetalAmount;

		//Increased the ship's received resources
		ship.shipFood = FE.foodToShip + OF.foodToShip + UAT.foodToShip + RN.foodToShip;
		ship.shipWater = FE.waterToShip + OF.waterToShip + UAT.waterToShip + RN.waterToShip;
		ship.shipOil = FE.oilToShip + OF.oilToShip + UAT.oilToShip + RN.oilToShip;
		ship.shipMetal = FE.metalToShip + OF.metalToShip + UAT.metalToShip + RN.metalToShip;
	}
}
