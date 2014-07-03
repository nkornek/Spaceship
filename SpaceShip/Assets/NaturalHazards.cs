using UnityEngine;
using System.Collections;

public class NaturalHazards : MonoBehaviour {


	public	Country []player;
	public int totalPlayers; //how many countries
	public int hazardOfTheWeek; // range 0-8, 0 meaning safe week
	public int maxHarzardOfWeek;
	public int playerAffected;
	public int numOfPlayers; //affected by the hazard
	public string hazardName;
	public string hazardSentence;

	public int numOil;
	public int numFood;
	public int numMetal;
	public int numWater;

	// Use this for initialization
	void Start () {
		Random.seed = 3123;
		numOil= 0;
		numFood= 0;
		numMetal= 0;
		numWater = 0;


		hazardSentence = " ";	
		totalPlayers = 4;
		hazardOfTheWeek = 0; // default, nothing happens
		maxHarzardOfWeek = 13;
		playerAffected = -1;//no one is affected.
		numOfPlayers = 0; // no one is affected by anything yet
		hazardName = " ";
		player = new Country[totalPlayers];
		
		for(int i = 0; i < player.Length; i++)
		{
			player[i] = new Country();
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//old system.
		//setAffectedPlayers();
		//new system.
		setHazard();
		
	}
	//just in case we need it again
	/*
	void setHazardOfTheWeek(int [] plrArr){
		if(plrArr.Length ==1)
		{
			if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal){
				EarthQuakeDamage(player[plrArr[0]]);
				newHazardOfTheWeek(4);
			}
			else
				if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Water){
				StagnantWaterDamage(player[plrArr[0]]);
				newHazardOfTheWeek(10);
			}
			else
				if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil){
				SolarFlareDamage(player[plrArr[0]]);
				newHazardOfTheWeek(11);
			}
			else 
			{
				RiotDamage(player[plrArr[0]]);
				newHazardOfTheWeek(14);
			}
		}
		else
		if(plrArr.Length == 2){
		

				if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Water ||
				   player[plrArr[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Water)
					{
						if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Water)
							DroughtDamage(player[plrArr[0]],player[plrArr[1]]);
						else
						DroughtDamage(player[plrArr[1]],player[plrArr[0]]);
						newHazardOfTheWeek(2);
					}
				else
				if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Food ||
				   player[plrArr[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Food)
				{
					if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Food)
						FloodDamage(player[plrArr[0]],player[plrArr[1]]);
					else
						FloodDamage(player[plrArr[1]],player[plrArr[0]]);
					newHazardOfTheWeek(7);
				}
				else
				if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal ||
				   player[plrArr[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
				{
					if(player[plrArr[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
						HeatwaveDamage(player[plrArr[0]],player[plrArr[1]]);
					else
						HeatwaveDamage(player[plrArr[1]],player[plrArr[0]]);
						newHazardOfTheWeek(8);
				}
				else
				{
					int randomDamage = Random.Range(1, 4);
					if(randomDamage == 1)
					{
						HurricaineDamage(player[plrArr[0]], player[plrArr[1]]); // random
					newHazardOfTheWeek(9);
					}	
					else
					if(randomDamage == 2){
						ReVoltDamage(player[plrArr[1]],player[plrArr[0]]); // random
						newHazardOfTheWeek(15);
					}
					else
					{
						TornadoDamage(player[plrArr[0]], player[plrArr[1]]); // random
						newHazardOfTheWeek(1);
					}
			}

		}
		else
		if(plrArr.Length == 3)
		{
			PlagueDamage(player[plrArr[0]], player[plrArr[1]], player[plrArr[2]]);
			newHazardOfTheWeek(5);
		}
		else
		if(plrArr.Length ==4)
		{
				MassLootDamage(player[plrArr[0]], player[plrArr[1]], player[plrArr[2]], player[plrArr[3]]);
			newHazardOfTheWeek(13);
		}
		else
			newHazardOfTheWeek(0);
	}
*/
	/*
	void setNumPlayersAffected(){ //make crisis generate random affected country + possible default affect
		//country with it.
		numOfPlayers = Random.Range (0,totalPlayers+1);


	}*/

	public string getHazardString(int [] arrIndex)
	{
		hazardSentence = "";

		if(hazardName == "Tornado" || hazardName == "Hurricane" || hazardName == "Volcano" || hazardName == "Wildfire" || hazardName =="Revolt")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire and " ;break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation and " ; break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories and" ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia and" ; break;
			}

			switch(player[arrIndex[1]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire "  ;break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation " ; break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia " ; break;
			}
			if(hazardName == "Tornado")
			{
			hazardSentence+= " was stuck by a Tornado and both have lost 1/2 their food supply.";
			}
			else
			if(hazardName == "Hurricane")
			{

				hazardSentence+= " was stuck by a Hurricane and both have lost 1/2 their oil supply.";
			}
			else
				if(hazardName == "Volcano Eruption")
			{

				hazardSentence+= " sufferred from a Volcanic Eruption and both have lost 1/2 their metal supply.";
			}
			else
				if(hazardName == "Wildfire"){
				hazardSentence+= " sufferred from a Wildfire and both have lost 1/2 their water supply.";
			}
			else
				if(hazardName == "Revolt")
			{
				hazardSentence += " is going through a Revolt. They will produce 50% of their resources for 4 weeks.";
			}
		}

		else
			if(hazardName == "Flood" || hazardName == "Drought" || hazardName == "Tsunami" || hazardName == "Heatwave")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire  " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation  " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia " ; break;
			}

			if( (hazardName == "Flood") && (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Food) )
			{
				hazardSentence += " lost 1/2 their food stock."+ "/n"
					+"United Agrarian Territories will produce 1/2 the amount of food for 3 weeks.";
			}
			else
				if( (hazardName == "Drought") && (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Water) )
			{
				hazardSentence += " lost 1/2 their water stock."+ "/n"
					+"Oceanic Federation will produce 1/2 the amount of water for 3 weeks.";
			}
			else
				if( (hazardName == "Tsunami") && (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil) )
			{
				hazardSentence += " lost 1/2 their oil stock."+ "/n"
					+"Republic of Naphthalia will produce 1/2 the amount of oil for 3 weeks.";
			}
			else
				if( (hazardName == "Heatwave") && (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal) )
			{
				hazardSentence += " lost 1/2 their metal stock."+ "/n"
					+"Ferrous Empire will produce 1/2 the amount of metal for 3 weeks.";
			}
		}
		else
			if(hazardName == "Earthquake" || hazardName == "Stagnant Water" || hazardName == "Solar Flare" || hazardName == "Contaminated Crops")
			{
			if( (hazardName == "Earthquake") && (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal))
				{
				hazardSentence = "Ferrous Empire's  metal production dropped by 25% for 4 weeks.";
				}
			else
				
				if((hazardName == "Stagnant Water") && (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal))
			{
				hazardSentence = "Oceanic Federation's water production will stop for 3 weeks.";
			}
			else
				if((hazardName == "Solar Flare") && (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil))
			{
				hazardSentence = "Republic of Naphthalia's oil lost their entire oil stock and "+"/n"+
						" oil production will stop for 2 weeks.";
			}
			else
				if((hazardName == "Contaminated Crops") && (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil))
			{
				hazardSentence = "United Agrarian's previous food export was contaminated and "+"/n"+
					" every country that imported it lost 1/3 of their population.";
			}
			}
		else
			if(hazardName == "Plague")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire, " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories, " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation, " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia, " ; break;
			}

			switch(player[arrIndex[1]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire, " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories, " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation, " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia," ; break;
			}

			switch(player[arrIndex[2]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += " and Ferrous Empire  " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += " and United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += " and Oceanic Federation  " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "and Republic of Naphthalia " ; break;
			}
			hazardSentence = "will produce nothing for 3 weeks.";
		}
		else
			if(hazardName == "Mass Looting")
		{
			hazardSentence = "Every country's export were stolen for 3 weeks.";
		}
		else
			if(hazardName == "Riot")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "Ferrous Empire " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "Oceanic Federation " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "Republic of Naphthalia " ; break;
			}
			hazardSentence = "is undergoing a riot. Their resources will cost 1.5x more for 3 weeks.";
		}

		return hazardSentence;

	}

	public void setHazard(){
		int die = Random.Range (0, 16);
		newHazardOfTheWeek(die);
		switch(die)
		{
			case 1: Tornado(); break;
			case 2: Drought(); break;
			case 3: Volcano(); break;
			case 4: Earthquake(); break;
			case 5: Plague(); break;
			case 6: WildFire(); break;
			case 7: Flood(); break;
			case 8: HeatWave(); break;
			case 9: Hurricane(); break;
			case 10: StagnantWater(); break;
			case 11: SolarFlare(); break;
			case 12: ContaminatedCrops(); break;
			case 13: MassLooting(); break;
			case 14: Riot(); break;
			case 15: Revolt(); break;
		case 16:	Tsunami(); break;
			default: Peace(); break;
		}
	}
	
	public void resetLostResources()
	{
		numOil = 0;
		numWater = 0;
		numMetal = 0;
		numFood = 0;
	}

	public void Tsunami()
	{
		resetLostResources();
		int [] ppl = determineAffectedPlayers(1);
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
			{
				TsunamiDamage(player[ppl[0]], player[i]);
			}
		}
	}

	public void Tornado()
	{
		resetLostResources();

		int [] ppl = determineAffectedPlayers(2);
		TornadoDamage(player[ppl[0]],player[ppl[1]]);
	}

	public void Drought(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(1);
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Water)
			{
				DroughtDamage(player[ppl[0]], player[i]);
			}
		}
	}

	public void Volcano(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(2);
		VolcanoDamage(player[ppl[0]], player[ppl[1]]);
	}

	public void Earthquake(){
		resetLostResources();
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
			{
				EarthQuakeDamage(player[i]);
			}
		}
	}

	public void Plague(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(3);
		PlagueDamage(player[ppl[0]], player[ppl[1]], player[ppl[2]]);
	}

	public void WildFire(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(2);
		WildFireDamage(player[ppl[0]], player[ppl[1]]);
	}

	public void Flood(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(1);
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Food)
			{
				DroughtDamage(player[ppl[0]], player[i]);
			}
		}
	}

	public void HeatWave(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(1);
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Metal)
			{
				DroughtDamage(player[ppl[0]], player[i]);
			}
		}
	}

	public void Hurricane(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(2);
		HurricaneDamage(player[ppl[0]], player[ppl[1]]);
	}

	public void StagnantWater(){
		resetLostResources();
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Water)
			{
				StagnantWaterDamage(player[i]);
			}
		}
	}

	public void SolarFlare(){
		resetLostResources();
		for(int i = 0; i < 4; i++)
		{
			if(player[i].ownedResourceType == GameVariableManager.OwnedResourceType.Oil)
			{
				SolarFlareDamage( player[i]);
			}
		}
	}

	public void ContaminatedCrops(){ //blank for now

	}

	public void MassLooting(){
		resetLostResources();
		MassLootDamage(player[0], player[1], player[2], player[3]);
	}

	public void Riot(){// not done for now

	}

	public void Revolt(){
		resetLostResources();
		int [] ppl = determineAffectedPlayers(2);
		RevoltDamage(player[ppl[0]], player[ppl[1]]);
	}

	public void Peace(){
		resetLostResources();

	}

	public void newHazardOfTheWeek(int i){
		switch(i)
		{
		case 1: hazardName = "Tornado"; break;
		case 2: hazardName = "Drought"; break;
		case 3: hazardName = "Volcano Eruption"; break;
		case 4: hazardName = "Earthquake";break;
		case 5: hazardName = "Plague"; break;
		case 6: hazardName = "Wildfire";break;
		case 7: hazardName = "Flood";break;
		case 8: hazardName = "Heatwave"; break;
		case 9: hazardName = "Hurricane"; break;
		case 10: hazardName = "Stagnant Water"; break;
		case 11: hazardName = "Solar Flare"; break;
		case 12: hazardName = "Contaminated Crops"; break;
		case 13: hazardName = "Mass Looting"; break;
		case 14: hazardName = "Riot"; break;
		case 15: hazardName = "Revolt"; break;
		case 16: hazardName = "Tsunami";break;

		default: hazardName = "Quiet"; break;
		}
	}
		

	void TsunamiDamage(Country r, Country c)
	{
		r.stockOil -= (r.stockOil/2);
		c.limitHarvestRateCounter = 3;
		c.limitedPercentage = 0.5f;
	}

	void TornadoDamage(Country r, Country c) //country loses 1/2 their food supply
	{	


		r.stockFood -= (r.stockFood/2);
		c.stockFood -= (c.stockFood/2);
	}

	
	void DroughtDamage(Country r, Country w) 
	{
		r.stockWater -= (r.stockWater/2); //for random country
		//water prod country reduce. water prod. by 1/2 for 3 weeks
		w.limitHarvestRateCounter = 3;
		w.limitedPercentage = 0.5f;

	}

	
	void VolcanoDamage(Country r1, Country r2)
	{
		r2.stockMetal -= (r2.stockMetal/2);
		r1.stockMetal -= (r1.stockMetal/2);
	}

	
	void EarthQuakeDamage(Country m) //only metal country
	{
		//modifier to add where country prod. only 1 metal per country. 
	//ex: 100 ppl, prod. 100 metal
		m.limitHarvestRateCounter = 4;
		m.limitedPercentage = 0.25f;
	}

	
	void PlagueDamage(Country r1, Country r2, Country r3) // 3 random countries lose 1/2 population
	{
		r1.population -= (r1.population/2);
		r2.population -= (r2.population/2);
		r2.population -= (r2.population/2);
	}

	void WildFireDamage(Country r1, Country r2){
		r1.stockWater -= (r1.stockWater/2);	
		r2.stockWater -= (r2.stockWater/2);
	}

	
	void FloodDamage(Country r1, Country f){
		r1.stockFood -= (r1.stockFood/2); // random country loses 1/2 their food supply
		//modifier: food prod. country will prod. 1/2 their amount of food for 3 weeks
		f.limitedPercentage = 0.5f;
		f.limitHarvestRateCounter = 3;
	}

	void HeatwaveDamage(Country r1, Country m){
		r1.stockMetal -= (r1.stockMetal/2);
		//modifier: metal country produces 1/2 metal for 3 weeks.
		m.limitedPercentage = 0.5f;
		m.limitHarvestRateCounter = 3;
	}

	void HurricaneDamage(Country r1, Country r2){
		r1.stockOil -= (r1.stockOil/2);
		r2.stockOil -= (r2.stockOil/2);
	}

	void StagnantWaterDamage(Country r){
		//modifier: country produces nothing for 3 weeks
		r.limitedPercentage = 0;
		r.limitHarvestRateCounter = 3;
	}

	void SolarFlareDamage(Country f){
		f.stockOil -= f.stockOil; //fuel country loses all their fuel
		//modifier: fuel country doesn't produce anything for 3 weeks
		f.limitedPercentage = 0;
		f.limitHarvestRateCounter = 3;
	}

	void ContaminatedCropDamage(Country pr){
		//country/countries that received food from Food prod country lose 1/3 their population
		pr.population -= (pr.population/3);
	}

	void MassLootDamage(Country r1, Country r2, Country r3, Country r4){
		//modifier: every country's exports are reduced to 0 for 3 weeks
	}
	void RiotDamage(Country r){
		//modifier: 1 random country uses 1/5x their usual resource to sustain population
		//for 3 weeks.
	}

	void RevoltDamage(Country r1, Country r2){
		r1.limitedPercentage = 0.5f;
		r2.limitedPercentage = 0.5f;
		r1.limitHarvestRateCounter = 4;
		r2.limitHarvestRateCounter = 4;
	}

	/*
	void setAffectedPlayers()
	{
		int affectedPlayer = Random.Range (0, 5);
		setHazardOfTheWeek(determineAffectedPlayers(affectedPlayer));
	}
*/

	//algorithm to make sure each array has unique value for more (number of people between 2-3) 
	//hasn't been tested yet.

	public int [] determineAffectedPlayers(int nOfPl){

		int []ppl;
		int num = -1;
		num = Random.Range(0,5);
		ppl = new int[ num ];

		bool [] pplIndex = {false,false,false,false};
		if(nOfPl > 0 && nOfPl != 4)
		{

			for(int i = 0; i < ppl.Length; i++)
			{
				ppl[i] = Random.Range(0,4);
			}

			//check if there are duplicate numbers
			for(int i = 0; i < pplIndex.Length; i++)
			{
					   while(pplIndex[ppl[i]] == true){
							ppl[i] = Random.Range(0,4);
					}

				if(pplIndex[ppl[i]] == false)
				{
					pplIndex[ppl[i]] = true;
				}

			}
		}
		//if ppl.length = 0, it will be an empty array
		return ppl;
	}




}