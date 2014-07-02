using UnityEngine;
using System.Collections;


//This class holds the global variables and ENUMS!!
//Declare enums here and call it from other scipts!!
public class GameVariableManager : MonoBehaviour {

	//Fields
	//The state of the game
	public enum GameState { Menu, Crisis, BeginWeekUpdate, Management, Result, LookAtStar, TransferResources, AIReact, ResourceRecap }
	//The type of the country object
	public enum CountryType { FE, OF, UAT, RN }
	//The type of resource that the country owns, that the country can harvest
	public enum OwnedResourceType { Food, Water, Oil, Metal }


	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
	}
}
