using UnityEngine;
using System.Collections;

public class View_buttons : MonoBehaviour {
	public GUI_Button Manage, Deploy, End;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameVariableManager.GameState.View)
		{
			Manage.enabled = true;
			Deploy.enabled = true;
			End.enabled = true;
			if (Manage.clicked)
			{
				GameManager.instance.gameState = GameVariableManager.GameState.Management;
			}
			if (Deploy.clicked)
			{
				GameManager.instance.gameState = GameVariableManager.GameState.DeployTroops;
			}
			if (End.clicked)
			{
				GameManager.instance.gameState = GameVariableManager.GameState.TransferResources;
			}
		}
		else
		{
			Manage.enabled = false;
			Deploy.enabled = false;
			End.enabled = false;
		}
	
	}
}
