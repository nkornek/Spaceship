using UnityEngine;
using System.Collections;

public class ArmyIndicators : MonoBehaviour {
	
	public SpriteRenderer feToOF, feToUAT, feToRN, ofToFE, ofToUAT, ofToRN, uatToFE, uatToOF, uatToRN, rnToFE, rnToOF, rnToUAT;
	public GameObject FE, OF, UAT, RN;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//FE
		if (FE.GetComponent<Country>().troopsFromOF > 0)
		{
			ofToFE.enabled = true;
		}
		else
		{
			ofToFE.enabled = false;
		}
		if (FE.GetComponent<Country>().troopsFromUAT > 0)
		{
			uatToFE.enabled = true;
		}
		else
		{
			uatToFE.enabled = false;
		}
		if (FE.GetComponent<Country>().troopsFromRN > 0)
		{
			rnToFE.enabled = true;
		}
		else
		{
			rnToFE.enabled = false;
		}
		//OF
		if (OF.GetComponent<Country>().troopsFromFE > 0)
		{
			feToOF.enabled = true;
		}
		else
		{
			feToOF.enabled = false;
		}
		if (OF.GetComponent<Country>().troopsFromUAT > 0)
		{
			uatToOF.enabled = true;
		}
		else
		{
			uatToOF.enabled = false;
		}
		if (OF.GetComponent<Country>().troopsFromRN > 0)
		{
			rnToOF.enabled = true;
		}
		else
		{
			rnToOF.enabled = false;
		}
		//UAT
		if (UAT.GetComponent<Country>().troopsFromOF > 0)
		{
			ofToUAT.enabled = true;
		}
		else
		{
			ofToUAT.enabled = false;
		}
		if (UAT.GetComponent<Country>().troopsFromFE > 0)
		{
			feToUAT.enabled = true;
		}
		else
		{
			feToUAT.enabled = false;
		}
		if (UAT.GetComponent<Country>().troopsFromRN > 0)
		{
			rnToUAT.enabled = true;
		}
		else
		{
			rnToUAT.enabled = false;
		}
		//RN
		if (RN.GetComponent<Country>().troopsFromOF > 0)
		{
			ofToRN.enabled = true;
		}
		else
		{
			ofToRN.enabled = false;
		}
		if (RN.GetComponent<Country>().troopsFromUAT > 0)
		{
			uatToRN.enabled = true;
		}
		else
		{
			uatToRN.enabled = false;
		}
		if (RN.GetComponent<Country>().troopsFromFE > 0)
		{
			feToRN.enabled = true;
		}
		else
		{
			feToRN.enabled = false;
		}
	
	}
}
