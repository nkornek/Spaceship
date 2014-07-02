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

	void setNumPlayersAffected(){ //make crisis generate random affected country + possible default affect
		//country with it.
		numOfPlayers = Random.Range (0,totalPlayers+1);
	}

	void newHazardOfTheWeek(int i){
		switch(i)
		{
		case 0: hazardName = "Quiet"; break;
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


		default: hazardName = "Quiet"; break;
		}
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
		w.limitedPercentage = 0.5;

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
		m.limitedPercentage = 0.25;
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
		f.limitedPercentage = 0.5;
		f.limitHarvestRateCounter = 3;
	}

	void HeatwaveDamage(Country r1, Country m){
		r1.stockMetal -= (r1.stockMetal/2);
		//modifier: metal country produces 1/2 metal for 3 weeks.
		m.limitedPercentage = 0.5;
		m.limitHarvestRateCounter = 3;
	}

	void HurricaineDamage(Country r1, Country r2){
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

	void ReVoltDamage(Country r1, Country r2){
		//modifier: 2 random countries produce 2 resources/1 citizen for 4 weeks
	}


	void setAffectedPlayers()
	{
		int affectedPlayer = Random.Range (0, 5);
		setHazardOfTheWeek(determineAffectedPlayers(affectedPlayer));
	}


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

		return ppl;
	}



	// Use this for initialization
	void Start () {
		Random.seed = 3123;

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
		//setHazardOfTheWeek();
		setNumPlayersAffected();
		//Debug.Log ("Players: "+numOfPlayers);
		
	//	Debug.Log ("hazard of week: "+hazardOfTheWeek);
	}
}
