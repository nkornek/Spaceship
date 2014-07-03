using UnityEngine;
using System.Collections;

public class WarOrPeaceBar : MonoBehaviour {

	int civilizeMeter;
	bool civilized; 

	Country[] players; // 
	NaturalHazards nh;

	// Use this for initialization
	void Start () {
		civilizeMeter = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(civilizeMeter < 50)
		{
			civilized = false;
		}
	}

	void setPlayerArray(Country []p) // copies the country array from the scene 
	{
		players = new Country[p.Length];
		for(int i = 0; i < p.Length; i++)
		{
			players[i] = p[i];
		}
	}

	void updateBar()
	{}



}
