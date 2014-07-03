using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {

	//Fields
	public GameVariableManager.RoadType roadType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (roadType) {
		case GameVariableManager.RoadType.FE_OF:
			Color temp = renderer.material.color;
			temp.g = (float)GameManager.instance.FE_OF / 100f;
			temp.r = 1f - (float)GameManager.instance.FE_OF / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		case GameVariableManager.RoadType.FE_RN:
			temp = renderer.material.color;
			temp.g = (float)GameManager.instance.FE_RN / 100f;
			temp.r = 1f - (float)GameManager.instance.FE_RN / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		case GameVariableManager.RoadType.FE_UAT:
			temp = renderer.material.color;
			temp.g = (float)GameManager.instance.FE_UAT / 100f;
			temp.r = 1f - (float)GameManager.instance.FE_UAT / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		case GameVariableManager.RoadType.OF_RN:
			temp = renderer.material.color;
			temp.g = (float)GameManager.instance.OF_RN / 100f;
			temp.r = 1f - (float)GameManager.instance.OF_RN / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		case GameVariableManager.RoadType.OF_UAT:
			temp = renderer.material.color;
			temp.g = (float)GameManager.instance.OF_UAT / 100f;
			temp.r = 1f - (float)GameManager.instance.OF_UAT / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		case GameVariableManager.RoadType.UAT_RN:
			temp = renderer.material.color;
			temp.g = (float)GameManager.instance.UAT_RN / 100f;
			temp.r = 1f - (float)GameManager.instance.UAT_RN / 100f;
			temp.b = 0f;
			renderer.material.color = temp;
			break;
		}
	
	}
}
