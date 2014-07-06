using UnityEngine;
using System.Collections;

public class TextLoc : MonoBehaviour {
	public Country thisCountry;
	private Vector3 oldPos;
	private Vector3 newPos;
	public int resource;

	// Use this for initialization
	void Start () {
		oldPos = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = oldPos;

		if (resource == 0){
			float amount = (thisCountry.stockFood-18)*0.01f;
			newPos = new Vector3(0,amount,0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.stockFood.ToString();
		} else if (resource == 1){
			float amount = (thisCountry.stockWater-18)*0.01f;
			newPos = new Vector3(0,amount,0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.stockWater.ToString();
		} else if (resource == 2){
			float amount = (thisCountry.stockOil-18)*0.01f;
			newPos = new Vector3(0,amount,0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.stockOil.ToString();
		} else if (resource == 3){
			float amount = (thisCountry.stockMetal-18)*0.01f;
			newPos = new Vector3(0,amount,0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.stockMetal.ToString();
		} else if (resource == 4){
			float amount = (thisCountry.population+100)*0.01f;
			newPos = new Vector3(0,amount,0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.population.ToString()+"%";
		} else if (resource == 5){
			float amount = (thisCountry.military+75)*0.007f;
			newPos = new Vector3(0,(amount),0);
			gameObject.GetComponent<TextMesh>().text = thisCountry.military.ToString();
		}
		oldPos.y = newPos.y;
	}
}
