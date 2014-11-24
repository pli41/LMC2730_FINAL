using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private int MaxChecks = 5;
	public bool locked;
	private bool ReadyForGoal;
	public int CheckPoints;
	public float StressPoint;
	public float GPA;
	public ArrayList bombs;
	public GameObject firstCheckPoint;
	private CheckPoint CP1;
	// Use this for initialization
	void Start () {
		CP1 = firstCheckPoint.GetComponent<CheckPoint> ();
		CP1.activated = true;
		bombs = new ArrayList ();
		GPA = 4.0f;
		StressPoint = 100f;
		CheckPoints = 0;
		ReadyForGoal = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1")){
			StressPoint -= 10f;
		}
		if(Input.GetKeyDown("2")){
			StressPoint += 10f;
		}

		if(Input.GetKeyDown("3")){
			CreateBomb();
		}
		UpdateBombs ();
		CheckCheckPoints ();

	}

	void nextCheckPoint(){

	}

	void CheckCheckPoints(){
		if(CheckPoints == MaxChecks){
			ReadyForGoal = true;
			Debug.Log ("Ready");
		}
	}

	public bool getReadyForGoal(){
		return ReadyForGoal;
	}

	void CreateBomb(){
		bombs.Add (new Bomb ());
	}

	void UpdateBombs(){
		if(bombs.Count > 0){
			for(int i = 0;i < bombs.Count; i++ ){
				Bomb thisBomb = (Bomb)bombs[i];
				thisBomb.Update();
				if(thisBomb.State == false){
					bombs.RemoveAt(i);
					i--;
				}
			}
		}
	}


}
