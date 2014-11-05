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

	private float HealthPercentage;
	private float EnergyPercentage;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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

}
