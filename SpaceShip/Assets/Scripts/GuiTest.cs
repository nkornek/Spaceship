using UnityEngine;
using System.Collections;


//Not used in final game (I think)
public class GuiTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button (new Rect(10, 100, 150, 100), "Send Food"))
			Debug.Log("Send Food");
	}
}
