using UnityEngine;
using System.Collections;

public class EndWeekInterface : MonoBehaviour {

	//Fields
	public GUI_Button endWeekButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endWeekButton.clicked) {
			GameManager.instance.gameState = GameVariableManager.GameState.LookAtStar;
		}
	}
}
