using UnityEngine;
using System.Collections;


//Class for the country objects
public class Country : MonoBehaviour {

	//Fields
	//Don't delete anything from here, still work in progress
	public GameVariableManager.CountryType countryType;
	private GameVariableManager.OwnedResourceType ownedResourceType;
	public int population, military, stockWater, stockOil, stockFood, stockMetal;
	private int relationshipFE, relationshipOF, relationshipUAT, relationshipRN;
	public GameObject roadToFe, roadToOF, roadToUAT, roadToRN;
	public GameObject populationBar, militaryBar;
	public GameObject foodBar, waterBar, oilBar, metalBar;
	public int resourceCap, resourceBarCap, populationCap, populationBarCap, militaryCap, militaryBarCap;
	public int maxResourceGainedPerTurn, sufficientPopulation;
	public bool isAI;
	bool hasUpdated;
	//Determine how much the population increases/decreases every week
	//prevPopulationStat: <0: decreasing / >0: increasing / =0: no change
	int prevPopulationStat, populationChange;
	//Amount transfered to other countries and the ship
	public int foodToFE, waterToFE, oilToFE, metalToFE;
	public int foodToOF, waterToOF, oilToOF, metalToOF;
	public int foodTOUAT, waterToUAT, oilToUAT, metalToUAT;
	public int foodToRN, waterToRN, oilToRN, metalToRN;
	public int foodToShip, waterToShip, oilToShip, metalToShip;
	//Variables needed for limiting harvest rate
	public int limitHarvestRateCounter, limitedPercentage;
	string metal;
	string water;
	string food;
	string oil;


	//Start Function
	void Start () {
		//Initiate the countries' values at the start of the game-------------
		stockFood = stockWater = stockOil = stockMetal = 100;
		population = 100;
		military = 0;
		//--------------------------------------------------------------------

		switch (countryType) {
		case GameVariableManager.CountryType.FE:
			ownedResourceType = GameVariableManager.OwnedResourceType.Metal;
			break;
		case GameVariableManager.CountryType.OF:
			ownedResourceType = GameVariableManager.OwnedResourceType.Water;
			break;
		case GameVariableManager.CountryType.UAT:
			ownedResourceType = GameVariableManager.OwnedResourceType.Food;
			break;
		case GameVariableManager.CountryType.RN:
			ownedResourceType = GameVariableManager.OwnedResourceType.Oil;
			break;
		}
	}


	//Update Function
	void Update () {
		UpdateGraphicsBars ();
		switch (GameManager.instance.gameState) {
		case GameVariableManager.GameState.BeginWeekUpdate:
			if (!hasUpdated) {
				//print ("New Week Update!");
				//print (ownedResourceType);
				NewWeekUpdate ();
				hasUpdated = true;
			}
			break;
		}
	}


	//Update the graphics bars (ressources, population and military)
	void UpdateGraphicsBars () {
		//ensure that no stock can be shown below 0
		//need to add code later so that players cannot give away more stock than they have
		if (stockFood < 0) {stockFood = 0;}
		if (stockMetal < 0) {stockMetal = 0;}
		if (stockOil < 0) {stockOil = 0;}
		if (stockWater < 0) {stockWater = 0;}

		Vector3 foodBarScale = foodBar.transform.localScale;
		foodBarScale.y = (float)stockFood / resourceCap * resourceBarCap;
		foodBar.transform.localScale = foodBarScale;

		Vector3 waterBarScale = waterBar.transform.localScale;
		waterBarScale.y = (float)stockWater / resourceCap * resourceBarCap;
		waterBar.transform.localScale = waterBarScale;

		Vector3 oilBarScale = oilBar.transform.localScale;
		oilBarScale.y = (float)stockOil / resourceCap * resourceBarCap;
		oilBar.transform.localScale = oilBarScale;

		Vector3 metalBarScale = metalBar.transform.localScale;
		metalBarScale.y = (float)stockMetal / resourceCap * resourceBarCap;
		metalBar.transform.localScale = metalBarScale;

		Vector3 populationBarScale = populationBar.transform.localScale;
		populationBarScale.y = (float)population / populationCap * populationBarCap;
		populationBar.transform.localScale = populationBarScale;

		Vector3 militaryBarScale = militaryBar.transform.localScale;
		militaryBarScale.y = (float)military / militaryCap * militaryBarCap;
		militaryBar.transform.localScale = militaryBarScale;
	}


	//Update the resource stats, population and military values of the country at the beginning of a new week
	//And consumes resources for population
	public void NewWeekUpdate () {
		//Consume resources
		if (stockFood >= 50) {
			stockFood -= 50;
		}
		else {
			stockFood = 0;
		}
		if (stockWater >= 50) {
			stockWater -= 50;
		}
		else {
			stockWater = 0;
		}
		if (stockOil >= 25) {
			stockOil -= 25;
		}
		else {
			stockOil = 0;
		}
		if (stockMetal >= 25) {
			stockMetal -= 25;
		}
		else {
			stockMetal = 0;
		}

		//Update population
		//Population Increased
		if (stockFood >= 75 && stockWater >= 75 && stockMetal >= 50 && stockOil >= 50) {
			if (populationChange > 0) {
				populationChange *= 2;
			}
			else {
				populationChange = 1;
			}
		}
		//Population Decreased
		else if (stockFood <= 50 || stockWater <= 50 || stockMetal <= 25 || stockOil <= 25) {
			if (populationChange < 0) {
				populationChange *= 2;
			}
			else {
				populationChange = -1;
			}
		}
		//Population Stays the same
		else {
			populationChange = 0;
		}
		population += populationChange;
		if (population > populationCap) {
			population = populationCap;
		}

		//Update resources harvested
		if (limitHarvestRateCounter > 0) {
			limitHarvestRateCounter--;
			switch (ownedResourceType) {
			case GameVariableManager.OwnedResourceType.Food:
				stockFood += (int)(Mathf.Min((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn * limitedPercentage);
				break;
			case GameVariableManager.OwnedResourceType.Water:
				stockWater += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn * limitedPercentage);
				break;
			case GameVariableManager.OwnedResourceType.Oil:
				stockOil += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn * limitedPercentage);
				break;
			case GameVariableManager.OwnedResourceType.Metal:
				stockMetal += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn * limitedPercentage);
				break;
			}
		}
		else {
			switch (ownedResourceType) {
			case GameVariableManager.OwnedResourceType.Food:
				stockFood += (int)(Mathf.Min((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn);
				break;
			case GameVariableManager.OwnedResourceType.Water:
				stockWater += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn);
				break;
			case GameVariableManager.OwnedResourceType.Oil:
				stockOil += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn);
				break;
			case GameVariableManager.OwnedResourceType.Metal:
				stockMetal += (int)(Mathf.Min ((float)population / sufficientPopulation, 1f) * maxResourceGainedPerTurn);
				break;
			}
		}


		//Update military

	}

//	void givePlayerResource(int i, string t, Country c)
//	{
//		switch(t)
//		{
//		case "Oil": oil -= 1; break;
//		case "Water": subWater(i); break;
//		case "Food": subFood(i); break;
//		case "Metal": subMetal(i); break;
//		default: ; break;
//		}
//		
//		switch(t)
//		{
//		case "Oil": c.addOil(i); break;
//		case "Water": c.addWater(i); break;
//		case "Food": c.addFood(i); break;
//		case "Metal": c.addMetal(i); break;
//		default: ; break;
//		}
//	}
//	
//	public void giveShipResource(int i, string t)
//	{
//		switch(t)
//		{
//		case "Oil": subOil(i); break;
//		case "Water": subWater(i); break;
//		case "Food": subFood(i); break;
//		case "Metal": subMetal(i); break;
//		default: ; break;
//		}
//	}

	//Code not needed, for now
//	Country()
//	{ 
//		population = 0;
//		military = 0;
//		stockWater = 0;
//		stockOil = 0;
//		stockFood = 0;
//		stockMetal = 0;
//		water = "Water";
//		food = "Food";
//		oil = "Oil";
//		metal = "Metal";
//	}
//
//	void addPopulation(int i){
//		population+=i;
//	}
//
//	void addArmy(int i){
//		military+=i;
//	}
//
//	void addWater(int i){
//		stockWater+=i;
//	}
//
//	void addOil(int i){
//		stockOil+=i;
//	}
//
//	void addMetal(int i){
//		stockMetal+=i;
//	}
//
//	void addFood(int i){
//		stockFood+=i;
//	}//
//
//	void subPopulation(int i){
//		population+=i;
//	}
//
//	
//	void subWater(int i){
//		stockWater-=i;
//	}
//	
//	void subOil(int i){
//		stockOil-=i;
//	}
//	
//	void subFood(int i){
//		stockFood-=i;
//	}
//
//	void subMetal(int i){
//		stockMetal -=i;
//	}
//	
//	void subArmy(int i){
//		military -=i;
//	}
//
//
//
//	void calculateNeededResources() //empty, for now
//	{
//
//	}
//
//	int getFoodQuantity(){
//		return stockFood;
//	}
//
//	
//	int getWaterQuantity(){
//		return stockWater;
//	}
//	
//	int getMetalQuantity(){
//		return stockMetal;
//	}
//	
//	int getOilQuantity(){
//		return stockOil;
//	}
//
//	
//	int getPopulation(){
//		return population;
//	}
//	
//
//
//	int getArmy(){
//		return military;
//	}
//
//	string getSTR_food(){
//		return food;
//	}
//	string getSTR_metal(){
//		return metal;
//	}
//	string getSTR_water(){
//		return water;
//	}
//	string getSTR_oil(){
//		return oil;
//	}

}
