using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public bool win, war, pop;
	public GUIText endText;
	public GUITexture background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.gameState == GameVariableManager.GameState.EndGame)
		{	
			pop = (GameManager.instance.player.country.population > 0)? true : false;
			war = !GameManager.instance.civilized;
			endText.enabled = background.enabled = true;
			win = (GameManager.instance.WonCountry == GameManager.instance.player.country) ? true : false;
			GameObject.Find ("Game Music").GetComponent<Game_Music>().gameOver = true;
			if (!win & !pop)
			{
				endText.text = "DEFEAT!\n\nTry as we might, the struggles which we faced proved to be too much to bear.\n Our once mighty nation collapsed under the weight of \nits people, and the dying star was only partly to blame.\n\n\nWe have failed each other, and now all of our nations are doomed.";
			}
			else if (!win & pop)
			{
				endText.text = "DEFEAT!\n\nTry as we might, the struggles which we faced proved to be too much to bear.\nOur neighbors surpassed us, and we were abandoned here to die.\n\n\nThe notion that our race lives on in the stars is but a small consolation\n as we now await our end.";
			}
			else if (win & !war)
			{
				endText.text = "VICTORY!\n\nAgainst all odds, we have triumphed!\nNow, as our nation heads for the stars, he have heavy hearts for the loss of\nour neighbors, but the promise of new, unexplored planets, gives us hope.\n\n\nTheir sacrifice will not be forgotten.";
			}
			else if (win & war)
			{
				endText.text = "VICTORY!\n\nAgainst all odds, we have triumphed!\nIn the end, it took our great might to win the day. We must look to the\nfuture, and put these grim events behind us.\n\n\nWe can only hope that our salvation was worth the cost.";
			}
		}
		else {
			endText.enabled = background.enabled = false;
		}
	

	}
}
