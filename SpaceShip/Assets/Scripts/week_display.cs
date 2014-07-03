using UnityEngine;
using System.Collections;

public class week_display : MonoBehaviour {
	public int weekNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		weekNum = GameManager.instance.weekNumber;
		gameObject.GetComponent<TextMesh> ().text = "Week " + weekNum.ToString();
	
	}
}
