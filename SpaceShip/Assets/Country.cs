using UnityEngine;
using System.Collections;

public class Country : MonoBehaviour {

	int population;
	int army;
	int qWater;
	int qOil;
	int qFood;
	int qMetal;
	string metal;
	string water;
	string food;
	string oil;

	Country()
	{ 
		population = 0;
		army = 0;
		qWater = 0;
		qOil = 0;
		qFood = 0;
		qMetal = 0;
		water = "Water";
		food = "Food";
		oil = "Oil";
		metal = "Metal";
	}

	void addPopulation(int i){
		population+=i;
	}

	void addArmy(int i){
		army+=i;
	}

	void addWater(int i){
		qWater+=i;
	}

	void addOil(int i){
		qOil+=i;
	}

	void addMetal(int i){
		qMetal+=i;
	}

	void addFood(int i){
		qFood+=i;
	}//

	void subPopulation(int i){
		population+=i;
	}

	
	void subWater(int i){
		qWater-=i;
	}
	
	void subOil(int i){
		qOil-=i;
	}
	
	void subFood(int i){
		qFood-=i;
	}

	void subMetal(int i){
		qMetal -=i;
	}
	
	void subArmy(int i){
		army -=i;
	}

	void givePlayerResource(int i, string t, Country c)
	{
		switch(t)
		{
		case "Oil": subOil(i); break;
		case "Water": subWater(i); break;
		case "Food": subFood(i); break;
		case "Metal": subMetal(i); break;
		default: ; break;
		}
	
		switch(t)
		{
		case "Oil": c.addOil(i); break;
		case "Water": c.addWater(i); break;
		case "Food": c.addFood(i); break;
		case "Metal": c.addMetal(i); break;
		default: ; break;
		}
	}

	public void giveShipResource(int i, string t)
	{
		switch(t)
		{
		case "Oil": subOil(i); break;
		case "Water": subWater(i); break;
		case "Food": subFood(i); break;
		case "Metal": subMetal(i); break;
		default: ; break;
		}
	}

	void calculateNeededResources() //empty, for now
	{

	}

	int getFoodQuantity(){
		return qFood;
	}

	
	int getWaterQuantity(){
		return qWater;
	}
	
	int getMetalQuantity(){
		return qMetal;
	}
	
	int getOilQuantity(){
		return qOil;
	}

	
	int getPopulation(){
		return population;
	}
	


	int getArmy(){
		return army;
	}

	string getSTR_food(){
		return food;
	}
	string getSTR_metal(){
		return metal;
	}
	string getSTR_water(){
		return water;
	}
	string getSTR_oil(){
		return oil;
	}

}
