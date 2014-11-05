using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float HealthPoint;
	public float EnergyPoint;

	// Use this for initialization
	void Start () {
		HealthPoint = 100f;
		EnergyPoint = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1")){
			HealthPoint -= 10f;
		}
		if(Input.GetKeyDown("2")){
			EnergyPoint -= 10f;
		}

		   
	}
}
