using UnityEngine;
using System.Collections;


//Class for the country objects
public class Country : MonoBehaviour {

	//Fields
	//Don't delete anything from here, still work in progress
	public GameVariableManager.CountryType countryType;
	public GameVariableManager.OwnedResourceType ownedResourceType;
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
	public int prevPopulationStat, populationChange;
	//Amount transfered to other countries and the ship
	public int foodToFE, waterToFE, oilToFE, metalToFE;
	public int foodToOF, waterToOF, oilToOF, metalToOF;
	public int foodToUAT, waterToUAT, oilToUAT, metalToUAT;
	public int foodToRN, waterToRN, oilToRN, metalToRN;
	public int foodToShip, waterToShip, oilToShip, metalToShip;
	//Amount of resources sent and received
	public int receivedFood, receivedWater, receivedOil, receivedMetal;
	public int sentFood, sentWater, sentOil, sentMetal;
	//Variables needed for limiting harvest rate
	public int limitHarvestRateCounter; 
	public float limitedPercentage;
	string metal;
	string water;
	string food;
	string oil;
	public float militaryMetalReserve, militaryOilReserve, metalToMilitary, oilToMilitary, militaryBuilt;
	public int reserveTroops, sentTroops, troopsFromFE, troopsFromOF, troopsFromUAT, troopsFromRN, occupyingTroops, foodStolen, waterStolen, metalStolen, oilStolen;

	//troop deployment variables
	public int troopsToFE, troopsToOF, troopsToUAT, troopsToRN, collateralDamage, soldiersLost, totalSoldierDead;
	public bool combatCalled;

	//Civilization Scale
	public WarOrPeaceBar civilizationScale;


	//Start Function
	void Start () {
		//Initiate the countries' values at the start of the game-------------
		stockFood = stockWater = stockOil = stockMetal = 100;
		relationshipFE = relationshipOF = relationshipRN = relationshipUAT = 100;
		population = 100;
		military = 0;
		combatCalled = false;
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

		civilizationScale = GameObject.Find ("Civilization_Scale").GetComponent<WarOrPeaceBar> ();
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
		case GameVariableManager.GameState.Management:
			DistributeResources ();
			hasUpdated = false;
			combatCalled = false;
			break;
		case GameVariableManager.GameState.Combat:
			if (!combatCalled)
			{
				CombatPhase();
				combatCalled = true;
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

		//Update military numbers

		if (militaryMetalReserve > 5 & militaryOilReserve > 5)
		{
			if (militaryMetalReserve >= militaryOilReserve)
			{
				militaryBuilt = Mathf.Floor(militaryOilReserve / 5);
				military += (int)militaryBuilt;
				militaryMetalReserve -= militaryBuilt * 5;
				militaryOilReserve -= militaryBuilt * 5;
			}
			else if (militaryMetalReserve < militaryOilReserve)
			{
				militaryBuilt = Mathf.Floor(militaryMetalReserve / 5);
				military += (int)militaryBuilt;
				militaryMetalReserve -= militaryBuilt * 5;
				militaryOilReserve -= militaryBuilt * 5;
			}
		}
		sentTroops = troopsToFE + troopsToOF + troopsToUAT + troopsToRN;
		reserveTroops = military - sentTroops;

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
		else if (stockFood < 50 || stockWater < 50 || stockMetal < 25 || stockOil < 25) {
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
	}


	//Update relationShips
	void UpdateRelationships () {

	}

	//Calculate how to distribute the resources
	void DistributeResources () {
		if (isAI) {
			switch (countryType) {
			case GameVariableManager.CountryType.FE:
				metalToOF = (int)((stockMetal - 75f) / 3 * (float)GameManager.instance.FE_OF / 100f);
				metalToUAT = (int)((stockMetal - 75f) / 3 * (float)GameManager.instance.FE_UAT / 100f);
				metalToRN = (int)((stockMetal - 75f) / 3 * (float)GameManager.instance.FE_RN / 100f);
				int restOfMetal = stockMetal - 75 - metalToOF - metalToUAT - metalToRN;
				//metalToShip = (int)((stockMetal - 75f - metalToOF - metalToUAT - metalToRN));
				metalToShip = (int)(restOfMetal * ((float)civilizationScale.civilizedMeter / 100f));
				metalToMilitary = restOfMetal - metalToShip;
				int restOfOil = stockOil - 75 - oilToOF - oilToUAT - oilToRN;
				oilToShip = (int)(restOfOil * ((float)civilizationScale.civilizedMeter / 100f));
				oilToMilitary = restOfOil - metalToMilitary;

				break;
			case GameVariableManager.CountryType.OF:
				waterToFE = (int)((stockWater - 75f) / 3 * (float)GameManager.instance.FE_OF / 100f);
				waterToUAT = (int)((stockWater - 75f) / 3 * (float)GameManager.instance.OF_UAT / 100f);
				waterToRN = (int)((stockWater - 75f) / 3 * (float)GameManager.instance.OF_RN / 100f);
				waterToShip = (int)(stockWater - 75 - waterToFE - waterToUAT - waterToRN);
				restOfMetal = stockMetal - 75 - metalToFE - metalToUAT - metalToRN;
				//metalToShip = (int)((stockMetal - 75f - metalToOF - metalToUAT - metalToRN));
				metalToShip = (int)(restOfMetal * ((float)civilizationScale.civilizedMeter / 100f));
				metalToMilitary = restOfMetal - metalToShip;
				restOfOil = stockOil - 75 - oilToFE - oilToUAT - oilToRN;
				oilToShip = (int)(restOfOil * ((float)civilizationScale.civilizedMeter / 100f));
				oilToMilitary = restOfOil - metalToMilitary;
				break;
			case GameVariableManager.CountryType.UAT:
				foodToFE = (int)((stockFood - 75f) / 3 * (float)GameManager.instance.FE_UAT / 100f);
				foodToOF = (int)((stockFood - 75f) / 3 * (float)GameManager.instance.OF_UAT / 100f);
				foodToRN = (int)((stockFood - 75f) / 3 * (float)GameManager.instance.UAT_RN / 100f);
				foodToShip = (int)(stockFood - 75 - foodToFE - foodToOF - foodToRN);
				restOfMetal = stockMetal - 75 - metalToFE - metalToOF - metalToRN;
				//metalToShip = (int)((stockMetal - 75f - metalToOF - metalToUAT - metalToRN));
				metalToShip = (int)(restOfMetal * ((float)civilizationScale.civilizedMeter / 100f));
				metalToMilitary = restOfMetal - metalToShip;
				restOfOil = stockOil - 75 - oilToFE - oilToOF - oilToRN;
				oilToShip = (int)(restOfOil * ((float)civilizationScale.civilizedMeter / 100f));
				oilToMilitary = restOfOil - metalToMilitary;
				break;
			case GameVariableManager.CountryType.RN:
				oilToFE = (int)((stockOil - 75f) / 3 * (float)GameManager.instance.FE_RN / 100f);
				oilToOF = (int)((stockOil - 75f) / 3 * (float)GameManager.instance.OF_RN / 100f);
				oilToUAT = (int)((stockOil - 75f) / 3 * (float)GameManager.instance.UAT_RN / 100f);
				oilToShip = (int)(stockOil - 75 - oilToFE - oilToOF - oilToUAT);
				restOfMetal = stockMetal - 75 - metalToFE - metalToOF - metalToUAT;
				//metalToShip = (int)((stockMetal - 75f - metalToOF - metalToUAT - metalToRN));
				metalToShip = (int)(restOfMetal * ((float)civilizationScale.civilizedMeter / 100f));
				metalToMilitary = restOfMetal - metalToShip;
				restOfOil = stockOil - 75 - oilToFE - oilToOF - oilToUAT;
				oilToShip = (int)(restOfOil * ((float)civilizationScale.civilizedMeter / 100f));
				oilToMilitary = restOfOil - metalToMilitary;
				break;
			}
		}
	}

	void CombatPhase (){
		sentTroops = troopsToFE + troopsToOF + troopsToUAT + troopsToRN;
		reserveTroops = military - sentTroops;
		occupyingTroops = troopsFromFE + troopsFromOF + troopsFromRN + troopsFromUAT;
		//kill troops on both sides
		if (occupyingTroops > reserveTroops & occupyingTroops != 0 & reserveTroops != 0) 
		{
			if (troopsFromFE > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
					{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToUAT/5);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToUAT -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToOF/5);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToOF -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToRN/5);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToRN -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromOF > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToUAT/5);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToUAT -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToFE/5);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToFE -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToRN/5);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToRN -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromUAT > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToFE/5);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().troopsToFE -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToOF/5);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;				
					GameManager.instance.UAT.GetComponent<Country>().troopsToOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToRN/5);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;					
					GameManager.instance.UAT.GetComponent<Country>().troopsToRN -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromRN > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToFE/5);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToFE -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToOF/5);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToUAT/5);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToUAT -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
			}
			soldiersLost = (int) Mathf.Floor(reserveTroops/4);
			reserveTroops -= soldiersLost;
			military -= soldiersLost;
		}
		//invading army is smaller than reserve

		else if (occupyingTroops < reserveTroops & occupyingTroops != 0 & reserveTroops != 0) 
		{
			if (troopsFromFE > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToUAT/4);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToUAT -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToOF/4);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToOF -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.FE.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.FE.GetComponent<Country>().troopsToRN/4);
					GameManager.instance.FE.GetComponent<Country>().military -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().troopsToRN -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					GameManager.instance.FE.GetComponent<Country>().totalSoldierDead += GameManager.instance.FE.GetComponent<Country>().soldiersLost;
					troopsFromFE -= GameManager.instance.FE.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromOF > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToUAT/4);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToUAT -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToFE/4);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToFE -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.OF.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.OF.GetComponent<Country>().troopsToRN/4);
					GameManager.instance.OF.GetComponent<Country>().military -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().troopsToRN -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					GameManager.instance.OF.GetComponent<Country>().totalSoldierDead += GameManager.instance.OF.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.OF.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromUAT > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToFE/4);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().troopsToFE -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToOF/4);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().troopsToOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
				{
					GameManager.instance.UAT.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.UAT.GetComponent<Country>().troopsToRN/4);
					GameManager.instance.UAT.GetComponent<Country>().military -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().troopsToRN -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					GameManager.instance.UAT.GetComponent<Country>().totalSoldierDead += GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.UAT.GetComponent<Country>().soldiersLost;
				}
			}
			if (troopsFromRN > 0)
			{
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToFE/4);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToFE -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToOF/4);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
				if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					GameManager.instance.RN.GetComponent<Country>().soldiersLost = (int) Mathf.Ceil(GameManager.instance.RN.GetComponent<Country>().troopsToUAT/4);
					GameManager.instance.RN.GetComponent<Country>().military -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().troopsToUAT -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					GameManager.instance.RN.GetComponent<Country>().totalSoldierDead += GameManager.instance.RN.GetComponent<Country>().soldiersLost;
					troopsFromOF -= GameManager.instance.RN.GetComponent<Country>().soldiersLost;
				}
			}

			soldiersLost = (int) Mathf.Floor(reserveTroops/5);
			reserveTroops -= soldiersLost;
			military -= soldiersLost;
		}
		//kill population
		if (occupyingTroops > 0 & reserveTroops > 0 & population > 4)
		{
			population -= 4;
			if (troopsFromFE >0)
			{
				GameObject.Find("FE").GetComponent<Country>().collateralDamage += 4;
			}
			if (troopsFromOF >0)
			{
				GameObject.Find("OF").GetComponent<Country>().collateralDamage += 4;
			}
			if (troopsFromUAT >0)
			{
				GameObject.Find("UAT").GetComponent<Country>().collateralDamage += 4;
			}
			if (troopsFromRN >0)
			{
				GameObject.Find("RN").GetComponent<Country>().collateralDamage += 4;
			}
		}
		else if (occupyingTroops > 0 & population > 8)
		{
			population -= 8;
			if (troopsFromFE >0)
			{
				GameObject.Find("FE").GetComponent<Country>().collateralDamage += 8;
			}
			if (troopsFromOF >0)
			{
				GameObject.Find("OF").GetComponent<Country>().collateralDamage += 8;
			}
			if (troopsFromUAT >0)
			{
				GameObject.Find("UAT").GetComponent<Country>().collateralDamage += 8;
			}
			if (troopsFromRN >0)
			{
				GameObject.Find("RN").GetComponent<Country>().collateralDamage += 8;
			}
		}
		//steal resources

		//steal metal from FE
		if (ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
			{
			if (troopsFromOF > troopsFromUAT & troopsFromOF > troopsFromRN)
				{
				GameManager.instance.OF.GetComponent<Country>().metalStolen = (int) Mathf.Floor(stockMetal / 2);
				stockMetal = (int) Mathf.Ceil(stockMetal / 2);
				}
			else if (troopsFromUAT > troopsFromOF & troopsFromUAT > troopsFromRN)
				{
				GameManager.instance.UAT.GetComponent<Country>().metalStolen = (int) Mathf.Floor(stockMetal / 2);
				stockMetal = (int) Mathf.Ceil(stockMetal / 2);
				}
			else if (troopsFromRN > troopsFromOF & troopsFromRN > troopsFromUAT)
				{
				GameManager.instance.RN.GetComponent<Country>().metalStolen = (int) Mathf.Floor(stockMetal / 2);
				stockMetal = (int) Mathf.Ceil(stockMetal / 2);
				}
			}
		//steal water from OF
		if (ownedResourceType == GameVariableManager.OwnedResourceType.Water)
		{
			if (troopsFromFE > troopsFromUAT & troopsFromFE > troopsFromRN)
			{
				GameManager.instance.FE.GetComponent<Country>().waterStolen = (int) Mathf.Floor(stockWater / 2);
				stockWater = (int) Mathf.Ceil(stockWater / 2);
			}
			else if (troopsFromUAT > troopsFromFE & troopsFromUAT > troopsFromRN)
			{
				GameManager.instance.UAT.GetComponent<Country>().waterStolen = (int) Mathf.Floor(stockWater / 2);
				stockWater = (int) Mathf.Ceil(stockWater / 2);
			}
			else if (troopsFromRN > troopsFromFE & troopsFromRN > troopsFromUAT)
			{
				GameManager.instance.RN.GetComponent<Country>().waterStolen = (int) Mathf.Floor(stockWater / 2);
				stockWater = (int) Mathf.Ceil(stockWater / 2);
			}
		}
		//steal food from UAT
		if (ownedResourceType == GameVariableManager.OwnedResourceType.Food)
		{
			if (troopsFromFE > troopsFromOF & troopsFromFE > troopsFromRN)
			{
				GameManager.instance.FE.GetComponent<Country>().foodStolen = (int) Mathf.Floor(stockFood / 2);
				stockFood = (int) Mathf.Ceil(stockFood / 2);
			}
			else if (troopsFromOF > troopsFromFE & troopsFromOF > troopsFromRN)
			{
				GameManager.instance.OF.GetComponent<Country>().foodStolen = (int) Mathf.Floor(stockFood / 2);
				stockFood = (int) Mathf.Ceil(stockFood / 2);
			}
			else if (troopsFromRN > troopsFromFE & troopsFromRN > troopsFromOF)
			{
				GameManager.instance.RN.GetComponent<Country>().foodStolen = (int) Mathf.Floor(stockFood / 2);
				stockFood = (int) Mathf.Ceil(stockFood / 2);
			}
		}
		//steal fuel from RN
		if (ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
		{
			if (troopsFromFE > troopsFromOF & troopsFromFE > troopsFromUAT)
			{
				GameManager.instance.FE.GetComponent<Country>().oilStolen = (int) Mathf.Floor(stockOil / 2);
				stockOil = (int) Mathf.Ceil(stockOil / 2);
			}
			else if (troopsFromOF > troopsFromFE & troopsFromOF > troopsFromUAT)
			{
				GameManager.instance.OF.GetComponent<Country>().oilStolen = (int) Mathf.Floor(stockOil / 2);
				stockOil = (int) Mathf.Ceil(stockOil / 2);
			}
			else if (troopsFromUAT > troopsFromFE & troopsFromUAT > troopsFromOF)
			{
				GameManager.instance.UAT.GetComponent<Country>().oilStolen = (int) Mathf.Floor(stockOil / 2);
				stockOil = (int) Mathf.Ceil(stockOil / 2);
			}
		}
		//add own stolen resources into stock
		stockFood += foodStolen;
		stockWater += waterStolen;
		stockMetal += metalStolen;
		stockOil += oilStolen;
		
	}
	

}
