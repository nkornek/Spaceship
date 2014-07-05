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
		if (weekNum <= 20)
		{
			gameObject.GetComponent<TextMesh> ().text = "W E E K   " + weekNum.ToString();
		}
		else
		{
			gameObject.GetComponent<TextMesh> ().text = "IT'S  HERE";
		}
	}
}
