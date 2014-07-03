using UnityEngine;
using System.Collections;

public class WarOrPeaceBar : MonoBehaviour {

	int civilizeMeter;


	Country[] players;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setPlayerArray(Country []p) // copies the country array from the scene 
	{
		players = new Country[p.Length];
		for(int i = 0; i < p.Length; i++)
		{
			players[i] = p[i];
		}
	}

	void updateBar(



}
