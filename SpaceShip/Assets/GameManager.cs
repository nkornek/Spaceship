using UnityEngine;
using System.Collections;


//This is a singleton class that holds the game state amongst other critical info.
//There is only one instance of this class, the instance can be called with:
//GameManager.instance
public class GameManager : MonoBehaviour {

	//Fields
	//Singleton stuff
	private static GameManager _pInstance;
	public static GameManager instance {
		get {
			return _pInstance;
		}
	}

	//The game's game state
	public GameVariableManager.GameState gameState;
	//The game's total week number (starts with 1)
	public int weekNumber;



	//Awake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	
	// Use this for initialization
	void Start () {
		_pInstance.weekNumber = 1;
		//debug code
		_pInstance.gameState = GameVariableManager.GameState.Crisis;
	}
	
	// Update is called once per frame
	void Update () {
		switch (_pInstance.gameState) {

		}
	}
}
