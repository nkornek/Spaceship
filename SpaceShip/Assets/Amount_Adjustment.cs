using UnityEngine;
using System.Collections;

public class Amount_Adjustment : MonoBehaviour {

	//Fields
	public GUI_Button increaseButton, decreaseButton;
	float amount;

	// Use this for initialization
	void Start () {
		amount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (increaseButton.clicked) {
			amount++;
		}
		if (decreaseButton.clicked) {
			amount--;
		}

		if (increaseButton.hold) {
			amount += Time.deltaTime * 2;
		}
		if (decreaseButton.hold) {
			amount -= Time.deltaTime * 2;
		}
		print (amount);
	}
}
