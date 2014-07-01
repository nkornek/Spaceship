using UnityEngine;
using System.Collections;

public class DyingStar : MonoBehaviour {

	public Camera mainCam;
	public GameObject dyingStar;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect(10, 100, 150, 100), "New Week")){
		//mainCam.Transform.position =
		Vector3 starScale = gameObject.transform.localScale;
		starScale = new Vector3 (5,5,5);
		gameObject.transform.localScale += starScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
