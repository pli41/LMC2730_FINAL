using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public Texture2D StatusFrame;
	private Rect FramePosition1;
	private Rect FramePosition2;
	public Texture2D StressBar;
	private Rect StressBarPosition;
	public Texture2D DueBomb;
	public GameObject BookWall;
	private float StressPercentage;

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
		if(Player.StressPoint > 0){
			StressPercentage = Player.StressPoint / 100f;
		}
		else if(Player.StressPoint > 100){
			StressPercentage = 1;
		}
		else{
			StressPercentage = 0;
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


	}

	void DrawBars(){
		//Draw Health bar
		StressBarPosition.x = FramePosition1.x + 1;
		StressBarPosition.y = FramePosition1.y + 1;
		StressBarPosition.width = (FramePosition1.width - 2) * StressPercentage;
		StressBarPosition.height = FramePosition1.height - 2;
		GUI.DrawTexture (StressBarPosition, StressBar);
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
