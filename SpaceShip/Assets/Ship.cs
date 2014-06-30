using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	int qWater;
	int qOil;
	int qFood;
	int qMetal;
	string metal;
	string water;
	string food;
	string oil;


	Ship()
	{
		qWater = 0;
		qOil = 0;
		qFood = 0;
		qMetal = 0;
		water = "Water";
		food = "Food";
		oil = "Oil";
		metal = "Metal";
	}

	void getResource(int i, string t, Country c)
	{
		c.giveShipResource(i, t);
		switch(t)
		{
		case "Oil": addOil(i); break;
		case "Water": addWater(i); break;
		case "Food": addFood(i); break;
		case "Metal": addMetal(i); break;
		default: ; break;
		}
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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
