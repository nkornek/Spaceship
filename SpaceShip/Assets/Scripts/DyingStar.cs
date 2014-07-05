using UnityEngine;
using System.Collections;

public class DyingStar : MonoBehaviour {

	public Camera mainCam;
	public GameObject dyingStar;
	public float smooth;
	private static Vector3 newPos;
	private Vector3 startPos;

	private Vector3 explodeScale;
	public GameObject UICam;
	bool coroutineStarted, endGame;

	// Use this for initialization
	void Start () {
	endGame = false;
	startPos = new Vector3 (7,11,-17);
	newPos = new Vector3 (7,11,-17);

	explodeScale = new Vector3 (3,3,3);
	}

	void FixedUpdate(){
		mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, newPos, smooth * Time.deltaTime);
	}

//	void OnGUI() {
//		if (GUI.Button (new Rect(10, 100, 150, 100), "New Week")){
//		StartCoroutine(backToLand());
//		//mainCam.Transform.position =
//		Vector3 starScale = gameObject.transform.localScale;
//		starScale = new Vector3 (1.1f,1.1f,1.1f);
//		gameObject.transform.localScale += starScale;
//		GameObject.Find ("_GameManager").GetComponent<GameManager>().weekNumber += 1;
//		UICam.SetActive(false);
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		//GAME OVER STATE
		if (gameObject.transform.localScale.x >= explodeScale.x){
			Debug.Log("GAME OVER");
		}

		if (GameManager.instance.gameState == GameVariableManager.GameState.LookAtStar) {
			if (!coroutineStarted) {
				coroutineStarted = true;
				StartCoroutine(backToLand());
			}
		}

		if (GameManager.instance.gameState == GameVariableManager.GameState.Management) {
			UICam.SetActive(true);
		}
		else {
			UICam.SetActive(false);
		}
	}

	public IEnumerator backToLand() {
		newPos = new Vector3 (0,45,0);
		//Vector3 starScale = gameObject.transform.localScale;
		//starScale = new Vector3 (1.1f,1.1f,1.1f);
		gameObject.transform.localScale += new Vector3 (0.50f, 0.50f, 0.50f);
		GameManager.instance.weekNumber += 1;
		yield return new WaitForSeconds(3.0f);
		newPos = startPos;
		//Invoke ("resetUI", 3);
		yield return new WaitForSeconds(3.0f);
		if (endGame == false)
		{
			GameManager.instance.gameState = GameVariableManager.GameState.Crisis;
		}
		else
		{
			GameManager.instance.gameState = GameVariableManager.GameState.EndGame;
		}
		//UICam.SetActive(true);
		coroutineStarted = false;
	}

	void resetUI (){
		UICam.SetActive(true);

	}
}
