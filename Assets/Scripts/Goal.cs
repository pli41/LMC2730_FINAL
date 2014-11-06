using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			if(player.getReadyForGoal()){
				Debug.Log("Victory");
			}
		}

	}
}
