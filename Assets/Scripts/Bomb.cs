using UnityEngine;
using System.Collections;

public class Bomb{

	public float DueTime;
	public bool State;
	public float CurrentTime;
	public PlayerController Player;

	// Use this for initialization
	public Bomb () {
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		DueTime = Random.Range (20f, 40f);
		State = true;
		CurrentTime = DueTime;
		Debug.Log ("New bomb created with due time = " + DueTime);
	}
	
	// Update is called once per frame
	public void Update () {
		CurrentTime -= Time.deltaTime;
		if(CurrentTime < 0 && State == true){
			Explode();
		}
		Debug.Log("Tik tak");

	}

	void Explode(){
		Player.GPA -= 1.0f;
		Debug.Log("EXPLODED");
		State = false;
	}

	void Dissemble(){

	}

	      
}
