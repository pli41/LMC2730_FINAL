using UnityEngine;
using System.Collections;

public class MINIgame1 : MonoBehaviour {
	private string originalText;
	private string finalText;
	private Rect Text;
	private Rect readPanel;
	private Rect writePanel;
	private Rect buttonRect;
	public bool game;
	public bool gameEnd;

	private PlayerController Player;

	// Use this for initialization
	void Start () {
		game = false;
		gameEnd = false;
		originalText = "aaabbbccc";
		finalText = "";
		Text = new Rect (50, 50 , 400, 400);
		readPanel = new Rect (100, 100, 500, 500);
		writePanel = new Rect (600, 100, 500, 500);
		buttonRect = new Rect (400, 450, 100, 50);
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			game = true;
		}
	}

	void OnGUI(){
		if(game){
			GUI.color = Color.red;
			GUI.Window(0, writePanel, showWritePanel, "Write");
			GUI.color = Color.green;
			GUI.Window(1, readPanel, showReadPanel, "Read");
		}
	}

	void showWritePanel(int windowID){
		if(GUI.Button (buttonRect, "Submit")){
			finalResult();
			game = false;
			gameEnd = true;
		}
		finalText = GUI.TextField (Text, finalText);
	}

	void showReadPanel(int windowID){
		GUI.Label (Text, originalText);
	}

	void finalResult(){	
		if(originalText.CompareTo(finalText) != 0){
			Player.GPA --;
		}
	}
}
