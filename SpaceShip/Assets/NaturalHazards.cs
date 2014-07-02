using UnityEngine;
using System.Collections;

public class NaturalHazards : MonoBehaviour {


	public	Country []player;
	public int totalPlayers;
	public int hazardOfTheWeek; // range 0-8, 0 meaning safe week
	public int maxHarzardOfWeek;
	public int playerAffected;
	public int numOfPlayers;
	public string hazardName;

	NaturalHazards(){
		totalPlayers = 4;
		hazardOfTheWeek = 0; // default, nothing happens
		maxHarzardOfWeek = 8;
		playerAffected = -1;//no one is affected.
		numOfPlayers = 0; // no one is affected by anything yet
		hazardName = " ";
		player = new Country[totalPlayers];

		for(int i = 0; i < player.Length; i++)
		{
			player[i] = new Country();
		}
	}


	void setHazardOfTheWeek(){
		hazardOfTheWeek = Random.Range(0,maxHarzardOfWeek+1);
		newHazardOfTheWeek(hazardOfTheWeek);
	}

	void setNumPlayersAffected(){
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
		default: hazardName = "Quiet"; break;
		}
	}

	void HazardDamage(int i, Country p){
		switch(i)
		{
		case 0: ; break;
		case 1: TornadoDamage (p); break;
		case 2: DroughtDamage(p); break;
		case 3: VolcanoDamage(p); break;
		case 4: EarthQuakeDamage(p);break;
		case 5: PlagueDamage(p); break;
		case 6: WildFireDamage(p);break;
		case 7: FloodDamage(p);break;
		default: ; break;
		}
	}

	void TornadoDamage(Country p)
	{
		p.subPopulation(3);
		p.subFood(4);
		p.subArmy(5);
	}

	
	void DroughtDamage(Country p)
	{
		p.subPopulation(10);
		p.subFood(10);
	}

	
	void VolcanoDamage(Country p)
	{
		p.subPopulation(5);
		p.subFood(10);
		p.subArmy(5);
		p.subMetal (10);
		p.subWater(30);
	}

	
	void EarthQuakeDamage(Country p)
	{
		p.subPopulation(2);
		p.subFood(2);
		p.subArmy(2);
		p.subMetal (30);
		p.subWater(10);
		p.subOil (20);
	}

	
	void PlagueDamage(Country p)
	{
		p.subPopulation(30);
		p.subArmy(30);
	}

	void WildFireDamage(Country p){
		p.subArmy (10);
		p.subFood(20);
		p.subOil(40);
		p.subWater(30);
	}

	
	void FloodDamage(Country p)
	{
		p.subPopulation(5);
		p.subFood(5);
		p.subArmy(5);
		p.subMetal (2);
		p.subOil (5);
	}

	void setAffectedPlayers()
	{
		int affectedPlayer = Random.Range (0, 4);
		setHazardOfTheWeek();
		HazardDamage(hazardOfTheWeek, player[affectedPlayer]);
	}

	/*
	//algorithm to make sure each array has unique value for more (number of people between 2-3) 
	//is too time consuming... skip.

	public int [] setEffectedPlayers(int nOfPl){

		int []ppl;
		int num = -1;
		int [] pplIndex = {0,1,2,3};
		if(nOfPl > 0 && nOfPl != 4)
		{
			num = Random.Range(0,4);
			ppl = new int[ num ];

			for(int i = 0; i < ppl.Length; i++)
			{
				ppl[i] = Random.Range(0,4);
			}

			//check if there are duplicate numbers
			for(int i = 0; i < pplIndex.Length; i++)
			{
				for(int j = 0; j < ppl.Length; j++)
				{
					if(ppl[j] == pplIndex[i]) 
				}
			}
		}

		return ppl;
	}

*/

	// Use this for initialization
	void Start () {
		Random.seed = 3123;

	
	}
	
	// Update is called once per frame
	void Update () {
		setHazardOfTheWeek();
		setNumPlayersAffected();
		//Debug.Log ("Players: "+numOfPlayers);
		
	//	Debug.Log ("hazard of week: "+hazardOfTheWeek);
	}
}
