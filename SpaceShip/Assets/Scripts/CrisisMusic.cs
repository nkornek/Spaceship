using UnityEngine;
using System.Collections;

public class CrisisMusic : MonoBehaviour {

	public AudioClip tornado;
	public AudioClip drought;
	public AudioClip volcano;
	public AudioClip earthquake;
	public AudioClip plague;
	public AudioClip wildfire;
	public AudioClip flood;
	public AudioClip heatwave;
	public AudioClip hurricane;
	public AudioClip stagnant_water;
	public AudioClip solar_flare;
	public AudioClip contaminated_crops;
	public AudioClip mass_looting;
	public AudioClip riot;
	public AudioClip revolt;
	public AudioClip tsunami;


	public AudioSource crisisMusic;
	NaturalHazards nh;

	// Use this for initialization
	void Start () {
		nh = GetComponent<NaturalHazards>();
		crisisMusic.clip = tornado;
	}
	
	// Update is called once per frame
	void Update () {
		newCrisisMusic(nh.hazardName);
		Debug.Log (nh.hazardName);
	}

	public void newCrisisMusic(string crisis){

		switch(crisis)
		{
		case "Tornado":crisisMusic.clip = tornado;break;
		case "Drought":crisisMusic.clip = drought;break;
		case "Volcano Eruption":crisisMusic.clip = volcano;;break;
		case "Earthquake":crisisMusic.clip = earthquake;break;
		case "Plague":crisisMusic.clip = plague;break;
		case "Wildfire":crisisMusic.clip = wildfire;break;
		case "Flood":crisisMusic.clip = flood;break;
		case "Heatwave":crisisMusic.clip = heatwave;break;
		case "Hurricane":crisisMusic.clip = hurricane;break;
		case "Stagnant Water":crisisMusic.clip = stagnant_water;break;
		case "Solar Flare":crisisMusic.clip = solar_flare;break;
		case "Contaminated Crops":crisisMusic.clip = contaminated_crops;break;
		case "Mass Looting":crisisMusic.clip = mass_looting;break;
		case "Riot":crisisMusic.clip = riot;break;
		case "Revolt":crisisMusic.clip = revolt;break;
		case "Tsunami":crisisMusic.clip = tsunami;break;
		default: ;break;
		}

		audio.Play();

	}
}
