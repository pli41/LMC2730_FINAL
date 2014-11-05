using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public Texture2D StatusFrame;
	private Rect FramePosition1;
	private Rect FramePosition2;
	public Texture2D HealthBar;
	private Rect HealthBarPosition;
	public Texture2D EnergyBar;
	private Rect EnergyBarPosition;
	public Texture2D DueBomb;

	private float HealthPercentage;
	private float EnergyPercentage;

	private PlayerController Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		CalculateBars ();



	}




	void CalculateBars(){
		if(Player.HealthPoint > 0){
			HealthPercentage = Player.HealthPoint / 100f;
		}
		else{
			HealthPercentage = 0;
		}
		
		if(Player.EnergyPoint > 0){
			EnergyPercentage = Player.EnergyPoint / 100f;
		}
		else{
			EnergyPercentage = 0;
		}
	}

	void OnGUI() {
		DrawDescription ();
		DrawFrames ();
		DrawBars ();
		DrawBombs ();
		DrawGPA ();
	}

	//Descriptions for 2 status bars
	void DrawDescription(){

	}

	void DrawFrames(){
		//Draw Frame for Health bar
		FramePosition1.x = 15;
		FramePosition1.y = 50;
		FramePosition1.width = 200;
		FramePosition1.height = 30;
		GUI.DrawTexture (FramePosition1, StatusFrame);
		//Draw Frame for Energy bar
		FramePosition2.x = 15;
		FramePosition2.y = 100;
		FramePosition2.width = 200;
		FramePosition2.height = 30;
		GUI.DrawTexture (FramePosition2, StatusFrame);


	}

	void DrawBars(){
		//Draw Health bar
		HealthBarPosition.x = FramePosition1.x + 1;
		HealthBarPosition.y = FramePosition1.y + 1;
		HealthBarPosition.width = (FramePosition1.width - 2) * HealthPercentage;
		HealthBarPosition.height = FramePosition1.height - 2;
		GUI.DrawTexture (HealthBarPosition, HealthBar);
		//Draw Health bar
		EnergyBarPosition.x = FramePosition2.x + 1;
		EnergyBarPosition.y = FramePosition2.y + 1;
		EnergyBarPosition.width = (FramePosition2.width - 2) * EnergyPercentage;
		EnergyBarPosition.height = FramePosition2.height - 2;
		GUI.DrawTexture (EnergyBarPosition, EnergyBar);
	}

	void DrawBombs(){
		if(Player.bombs.Count > 0){
			int row = 0;
			int rowCount = 0;
			for(int i = 0;i < Player.bombs.Count; i++ ){
				//Draw bombs

				Rect BombPosition = new Rect(800 + rowCount*50, 100 + row*70, 40, 20);
				GUI.DrawTexture(BombPosition, DueBomb);

				//Draw bombs' information
				Rect TextPosition = new Rect(800 + rowCount*50, 100 + row*70 + 30, 40, 40);
				Bomb thisBomb = (Bomb)Player.bombs[i];
				GUI.Label(TextPosition, thisBomb.CurrentTime.ToString());
				rowCount ++;
				if(rowCount > 5){
					rowCount = 0;
					row++;
				}
			}
		}	    
	}



	void DrawGPA(){
		GUI.Label (new Rect(Screen.width/2 - 80, 50, 160, 100), "GPA : " + Player.GPA);
	}



	   

}
