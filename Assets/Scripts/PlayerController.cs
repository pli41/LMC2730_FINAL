using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float HealthPoint;
	public float EnergyPoint;
	public float GPA;
	public ArrayList bombs;

	// Use this for initialization
	void Start () {
		bombs = new ArrayList ();
		GPA = 4.0f;
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

		if(Input.GetKeyDown("3")){
			CreateBomb();
		}
		UpdateBombs ();
		 
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
