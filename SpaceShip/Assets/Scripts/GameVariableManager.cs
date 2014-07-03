using UnityEngine;
using System.Collections;


//This class holds the global variables and ENUMS!!
//Declare enums here and call it from other scipts!!
public class GameVariableManager : MonoBehaviour {

	//Fields
	//The state of the game
	public enum GameState { Menu, StartGame, LookAtStar, Crisis, BeginWeekUpdate, Management, TransferResources, ResourceRecap, AIReact, EndWeek }
	//The type of the country object
	public enum CountryType { FE, OF, UAT, RN }
	//The type of resource that the country owns, that the country can harvest
	public enum OwnedResourceType { Food, Water, Oil, Metal }
	//The type of roads
	public enum RoadType { FE_RN, FE_OF, FE_UAT, OF_UAT, OF_RN, UAT_RN }


	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
	}
}
