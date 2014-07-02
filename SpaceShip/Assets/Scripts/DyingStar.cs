using UnityEngine;
using System.Collections;

public class DyingStar : MonoBehaviour {

	public Camera mainCam;
	public GameObject dyingStar;
	public float smooth;
	private static Vector3 newPos;
	private Vector3 startPos;
	public GameObject UICam;

	// Use this for initialization
	void Start () {
	startPos = new Vector3 (7,11,-17);
	newPos = new Vector3 (7,11,-17);
	}

	void FixedUpdate(){
	//	if (newPos == startPos){
		
	//} else {
		mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, newPos, smooth * Time.deltaTime);
	//}
	}

	void OnGUI() {
		if (GUI.Button (new Rect(10, 100, 150, 100), "New Week")){
		StartCoroutine(backToLand());
		//mainCam.Transform.position =
		Vector3 starScale = gameObject.transform.localScale;
		starScale = new Vector3 (1.1f,1.1f,1.1f);
		gameObject.transform.localScale += starScale;
		GameObject.Find ("_GameManager").GetComponent<GameManager>().weekNumber += 1;
		UICam.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator backToLand() {
		newPos = new Vector3 (0,45,0);
		yield return new WaitForSeconds(5.0f);
		newPos = startPos;
		Invoke ("resetUI", 3);
	}

	void resetUI (){
		UICam.SetActive(true);
		}
}
