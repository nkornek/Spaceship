using UnityEngine;
using System.Collections;

public class Game_Music : MonoBehaviour {

	public AudioClip weeks1, weeks2, weeks3, weeks4, victM, victC, Defeat;
	public AudioSource gameMusic;
	public bool canfade;
	public int weekNum;
	public bool canSwitch;
	public bool win, war;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		gameMusic.clip = weeks1;
		canfade = false;
		canSwitch = true;
		audio.volume = 0.0f;
		audio.Play ();
		audio.loop = true;
		gameOver = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		weekNum = GameObject.Find ("_GameManager").GetComponent<GameManager>().weekNumber;
		if (gameOver == true)
		{
			war = !GameManager.instance.civilized;
			win = (GameManager.instance.WonCountry == GameManager.instance.player.country) ? true : false;
			endMusic();
		}

	//fade out and switch tracks
	if (weekNum == 5 || weekNum == 10 || weekNum == 15 || weekNum == 21)
		{
			if (canfade == false & canSwitch == true)
			{
				canfade = true;
			}
		}
	if (weekNum == 6 || weekNum == 11 || weekNum == 16 || weekNum == 21)
		{
			canSwitch = true;
		}

	if (audio.volume < 0.5f & canfade == false)
		{
			audio.volume += 0.01f;
		}
	if (audio.volume > 0 & canfade == true)
		{
			audio.volume -= 0.01f;
		}
	if (audio.volume == 0.0f & canfade == true)
		{
			if (weekNum == 5)
			{
				ChangeMusic(1);
			}
			else if (weekNum == 10)
			{
				ChangeMusic(2);
			}
			else if (weekNum == 15)
			{
				ChangeMusic(3);
			}
			else if (weekNum == 21)
			{

			}
		}

	}

	void ChangeMusic (int music) {
		switch (music) {
		case 1:
			gameMusic.clip = weeks2;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			audio.loop = true;
			break;
		case 2:
			gameMusic.clip = weeks3;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			audio.loop = true;
			break;
		case 3:
			gameMusic.clip = weeks4;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			audio.loop = true;
			break;
		case 4:
			gameMusic.clip = victC;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			break;
		case 5:
			gameMusic.clip = victM;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			break;
		case 6:
			gameMusic.clip = Defeat;
			canfade = false;
			canSwitch = false;
			audio.Play ();
			break;
		}
	}
	void endMusic(){
		if (win & !war)
		{
			ChangeMusic(4);
		}
		else if (win & war)
		{
			ChangeMusic(5);
		}
		else if (!win)
		{
			ChangeMusic(6);
		}
	}
}
