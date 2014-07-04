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
	public int[] ppl;

	public int numOil;
	public int numFood;
	public int numMetal;
	public int numWater;
	bool hazardOccured;

	// Use this for initialization
	void Start () {
		//Random.seed = (int)(Time.timeSinceLevelLoad*10);
		Random.seed = (int)System.DateTime.Now.Ticks;
		numOil= 0;
		numFood= 0;
		numMetal= 0;
		numWater = 0;
		hazardSentence = " ";	
		totalPlayers = 4;
		hazardOfTheWeek = 0; // default, nothing happens
		maxHarzardOfWeek = 17;
		playerAffected = -1;//no one is affected.
		numOfPlayers = 0; // no one is affected by anything yet
		hazardName = " ";
		ppl = new int[0];
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.gameState == GameVariableManager.GameState.Crisis) {
			if (!hazardOccured) {
				setHazard();
				getHazardString(ppl);
				hazardOccured = true;
			}
		}
		else {
			hazardOccured = false;
		}

		
	}

	public string getHazardString(int [] arrIndex)
	{
		hazardSentence = "";

		if(hazardName == "Tornado" || hazardName == "Hurricane" || hazardName == "Volcano Eruption" || hazardName == "Wildfire" || hazardName =="Revolt")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "The Ferrous Empire and " ;break;
			case GameVariableManager.CountryType.OF: hazardSentence += "The Oceanic Federation and " ; break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "The United Agrarian Territories and " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "The Republic of Naphthalia and " ; break;
			}

			switch(player[arrIndex[1]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "the Ferrous Empire "  ;break;
			case GameVariableManager.CountryType.OF: hazardSentence += "the Oceanic Federation " ; break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "the United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "the Republic of Naphthalia " ; break;
			}
			if(hazardName == "Tornado")
			{
				hazardSentence+= "were ravaged \n by a massive Tornado which carried away half of their food supply.";
			}
			else
			if(hazardName == "Hurricane")
			{

				hazardSentence+= "have been struck \n by a category 5 Hurricane. Catastrophic infrastructure damage \n cost them half of their oil supply.";
			}
			else
				if(hazardName == "Volcano Eruption")
			{

				hazardSentence+= "experienced \n unprecedented Volcanic activity. The intense heat has melted half of their metal supply.";
			}
			else
				if(hazardName == "Wildfire"){
				hazardSentence+= " watched as their \n forests burned in a Wildfire. It took each of them half of their \n Water supply to extinguish the inferno.";
			}
			else
				if(hazardName == "Revolt")
			{
				hazardSentence += "are going through a Revolt."+'\n'+"Half of their workers have gone on strike \n for 4 weeks.";
			}
		}

		else
			if(hazardName == "Flood" || hazardName == "Drought" || hazardName == "Tsunami" || hazardName == "Heatwave")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "The Ferrous Empire " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "The United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "The Oceanic Federation " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "The Republic of Naphthalia " ; break;
			}

			if( (hazardName == "Flood")) //&& (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Food) )
			{
				hazardSentence += "lost half of their food stock to the rising tides."+ "\n"
					+"Many of the United Agrarian Territories' fields were flooded and \n will produce only half of the usual amount of food \n for 3 weeks.";
			}
			else
				if( (hazardName == "Drought")) //&& (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Water) )
			{
				hazardSentence += "was hit by an unseasonal Drought and had to consume half \n of their water stock just to stay alive."+ "\n"
					+"The Oceanic Federation's reservoirs are running low, and they will \n produce only half of the usual amount of water for 3 weeks.";
			}
			else
				if( (hazardName == "Tsunami")) //&& (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil) )
			{
				hazardSentence += "was struck by the largest Tsunami yet recorded. \n Their fuel storage was nearly destroyed, and half of \n their oil stock was lost."+ "\n"
					+"The Republic of Naphthalia's oil fields were also \n  hit by  the wave, and will produce half of the \n usual amount of oil for 3 weeks.";
			}
			else
				if( (hazardName == "Heatwave")) //&& (player[arrIndex[1]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal) )
			{
				hazardSentence += "recorded record-breaking heat in several areas. \n Half of the metal in their stockpile has melted."+ "\n"
					+"The Heat Wave has  also made many of the Ferrous Empire's \n mines unworkable, and they will produce only half as \n much metal as usual for 3 weeks.";
			}
		}
		else
			if(hazardName == "Earthquake" || hazardName == "Stagnant Water" || hazardName == "Solar Flare" || hazardName == "Contaminated Crops")
			{
			if( (hazardName == "Earthquake")) //&& (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal))
				{
				hazardSentence = "The earth shook, cracked, and ruptured under the \n force of a massive Earthquake. Many of the Ferrous Empire's \n mines have collapsed, and they will produce 75% less metal for 4 weeks.";
				}
			else
				
				if((hazardName == "Stagnant Water") )//&& (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Metal))
			{
				hazardSentence = "Atmospheric anomalies have caused the Oceanic Federation's \n reservoirs to turn stagnant. They will be unable \n to produce any water for 3 weeks.";
			}
			else
				if((hazardName == "Solar Flare") )//&& (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil))
			{
				hazardSentence = "Radiation from a large Solar Flare has caused the \n Republic of Naphthalia's oil wells to explode, and they \n have lost their entire fuel stockpile."+"\n"+
						"Oil production will stop for 2 weeks while repairs take place.";
			}
			else
				if((hazardName == "Contaminated Crops") )//&& (player[arrIndex[0]].ownedResourceType == GameVariableManager.OwnedResourceType.Oil))
			{
				hazardSentence = "An unknown pathogen was discovered in the United Agrarian Territories's \n crops. The food that they have recently exported was contaminated,"+"\n"+
					" every country that imported it has \n seen a third of their population perish.";
			}
			}
		else
			if(hazardName == "Plague")
		{
			switch(player[arrIndex[0]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "The Ferrous Empire, " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "The United Agrarian Territories, " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "The Oceanic Federation, " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "The Republic of Naphthalia, " ; break;
			}

			switch(player[arrIndex[1]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "the Ferrous Empire,\n" ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "the United Agrarian Territories,\n" ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "the Oceanic Federation,\n" ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "the Republic of Naphthalia,\n" ; break;
			}

			switch(player[arrIndex[2]].countryType)
			{
			case GameVariableManager.CountryType.FE: hazardSentence += "and the Ferrous Empire " ;break;
			case GameVariableManager.CountryType.UAT: hazardSentence += "and the United Agrarian Territories " ; break;
			case GameVariableManager.CountryType.OF: hazardSentence += "and the Oceanic Federation " ; break;
			case GameVariableManager.CountryType.RN: hazardSentence += "and the Republic of Naphthalia " ; break;
			}
			hazardSentence += "have suffered from an outbreak of disease, \n resulting in the loss of half of their citizens.";
		}
		else
			if(hazardName == "Mass Looting")
		{
			hazardSentence = "Highway bandits have set up along the major roadways.\n Half of all exports will be stolen for the next 3 weeks \n until law enforcement can deal with them.";
		}
		else
			if(hazardName == "Riot")
		{
				hazardSentence = "Riot disaster not implemented!";
		}
		else
			hazardSentence = "The skies are clear, but the shadow of the dying star draws ever closer...";
		return hazardSentence;

	}

	public void setHazard(){
		int disasterHappen, die;
		if (GameManager.instance.weekNumber < 5) {
			disasterHappen = Random.Range (1, 5);
		}
		else if (GameManager.instance.weekNumber < 10) {
			disasterHappen = Random.Range (1, 3);
		}
		else if (GameManager.instance.weekNumber < 20) {
			disasterHappen = Random.Range (1, 2);
		}
		else {
			disasterHappen = Random.Range (1, 2);
		}
		if (disasterHappen == 1) {
			die = Random.Range (1, 14);
		}
		else {
			die = 0;
		}

		//int die = 1;
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
		//	case 12: ContaminatedCrops(); break; //Not implemented
		//	case 13: MassLooting(); break; //Not implemented
		//	case 14: Riot(); break;    //Not implemented
			case 13: Revolt(); break;
			case 14: Tsunami(); break;
			default: Peace(); break;
		}
	}
	
	public void resetLostResources() //Not implemented
	{
		numOil = 0;
		numWater = 0;
		numMetal = 0;
		numFood = 0;
	}

	public void Tsunami()
	{
		resetLostResources();
		ppl = determineAffectedPlayers(1);
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

		ppl = determineAffectedPlayers(2);
		TornadoDamage(player[ppl[0]],player[ppl[1]]);
	}

	public void Drought(){
		resetLostResources();
		ppl = determineAffectedPlayers(1);
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
		ppl = determineAffectedPlayers(2);
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
		ppl = determineAffectedPlayers(3);
		PlagueDamage(player[ppl[0]], player[ppl[1]], player[ppl[2]]);
	}

	public void WildFire(){
		resetLostResources();
		ppl = determineAffectedPlayers(2);
		WildFireDamage(player[ppl[0]], player[ppl[1]]);
	}

	public void Flood(){
		resetLostResources();
		ppl = determineAffectedPlayers(1);
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
		ppl = determineAffectedPlayers(1);
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
		ppl = determineAffectedPlayers(2);
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
		ppl = determineAffectedPlayers(2);
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
		//case 12: hazardName = "Contaminated Crops"; break; //not done yet
		//case 13: hazardName = "Mass Looting"; break; //not done yet
		//case 14: hazardName = "Riot"; break; // not done yet
		case 12: hazardName = "Revolt"; break;
		case 13: hazardName = "Tsunami";break;

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
		r3.population -= (r3.population/2);
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

	//algorithm to make sure each array has unique value for more (number of people between 2-3) 
	public int [] determineAffectedPlayers(int nOfPl){

		int []tempPpl;
		tempPpl = new int[nOfPl];
		bool repeated;

		if(nOfPl > 0 && nOfPl != 4)
		{

			for(int i = 0; i < tempPpl.Length; i++)
			{
				tempPpl[i] = Random.Range(0,4);
			}
			//check if there are duplicate numbers
			if (tempPpl.Length > 1) {
				for(int i = 0; i < tempPpl.Length; i++)
				{
					repeated = false;
					do {
						repeated = false;
						for (int j = 0; j < tempPpl.Length; j++) {
							if (i != j) {
								if (tempPpl[i] == tempPpl[j]) {
									repeated = true;
									tempPpl[i] = Random.Range(0, 4);
								}
							}
						}
					} while (repeated);

				}
			}
		}
		//if ppl.length = 0, it will be an empty array
		return tempPpl;
	}

}