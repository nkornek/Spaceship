using UnityEngine;
using System.Collections;

public class FlagPole : MonoBehaviour {
	public Sprite[] winnerFlag;
	public SpriteRenderer render;
	public Country FE, OF, UAT, RN, WonCountry;
	public float FEtotal, OFtotal, UATtotal, RNtotal;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		FEtotal = FE.GetComponent<Country>().population+FE.GetComponent<Country>().military;
		OFtotal = OF.GetComponent<Country>().population+OF.GetComponent<Country>().military;
		UATtotal = UAT.GetComponent<Country>().population+UAT.GetComponent<Country>().military;
		RNtotal = RN.GetComponent<Country>().population+RN.GetComponent<Country>().military;


	if (FEtotal > OFtotal && FEtotal > UATtotal && FEtotal > RNtotal){
		render.sprite = winnerFlag[0];
	} else if (OFtotal > FEtotal && OFtotal > UATtotal && OFtotal > RNtotal){
		render.sprite = winnerFlag[1];
	} else if (UATtotal > FEtotal && UATtotal > OFtotal && UATtotal > RNtotal){
		render.sprite = winnerFlag[2];
	} else if (RNtotal > FEtotal && RNtotal > OFtotal && RNtotal > UATtotal){
		render.sprite = winnerFlag[3];
	} else {
		render.sprite = winnerFlag[4];
	}
}
}
