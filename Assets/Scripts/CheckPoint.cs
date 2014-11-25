using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public bool activated;
	public int checkPointNum;
	public GameObject QUIZ1;
	private Rect textRect;
	private Rect buttonStartRect;
	private Rect buttonCancelRect;
	private Rect examRect1;
	private PlayerController player;
	public bool exam;
	public GameObject bookWall;
	public GameObject nextCheckPoint;
	private BookWall thisBookWall;
	private CheckPoint[] checkPoints;
	private GameObject[] gameobjects;
	private MINIgame1 game1;
	private bool inExam;
	// Use this for initialization


	void Start () {
		activated = false;
		thisBookWall = bookWall.GetComponent<BookWall> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		exam = false;
		examRect1 = new Rect (400, 100, 500, 500);
		textRect = new Rect (50, 50, 400, 400);
		buttonStartRect = new Rect (170, 450, 100, 50);
		buttonCancelRect = new Rect (270, 450, 100, 50);
		gameobjects = GameObject.FindGameObjectsWithTag("CheckPoints");
		AssignCheckPoints ();
		inExam = false;
		game1 = QUIZ1.GetComponent<MINIgame1> ();
	}

	void AssignCheckPoints(){
		checkPoints = new CheckPoint[gameobjects.Length];
		for(int i=0; i<gameobjects.Length; i++){
			checkPoints[i] = gameobjects[i].GetComponent<CheckPoint> ();
		}
	}

	void StartExam(){
//		foreach (CheckPoint checkPoint in checkPoints) {
//			checkPoint.exam = true;
//		}
		if(activated){
			exam = true;
		}
	}

	void EndExam(){
//		foreach (CheckPoint checkPoint in checkPoints) {
//			checkPoint.exam = false;
//		}
		if(activated){
			exam = false;
			Debug.Log (checkPointNum + " exploded ");
			thisBookWall.explode = true;
			if(player.CheckPoints<5){
				activated = false;
				CheckPoint CP2 = nextCheckPoint.GetComponent<CheckPoint> ();
				CP2.activated = true;
			}
		}

	}

	// Update is called once per frame
	void Update () {
		if(activated){
			if(game1.game){
				inExam = true;
			}
			else{
				inExam = false;
			}

			if(game1.gameEnd){
				EndExam();
				game1.gameEnd = false;
			}
		}
		Debug.Log (checkPointNum + " status: " + activated);

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			if(activated){
				StartExam();
				player.CheckPoints ++;
				deactivate();
			}
		}
	}

	void deactivate(){
		renderer.enabled = false;
		collider.enabled = false;
	}	

	void OnGUI(){
		if(activated){
			if(exam && !inExam){
				player.locked = true;
				GUI.color = Color.red;
				GUI.Window(0, examRect1, showExam, "Exam1");
			}
			else if(exam && inExam){
				player.locked = true;
			}
			else{
				player.locked = false;
			}
		}
	}



	void showExam(int windowID){

		if (GUI.Button (buttonStartRect, "Start")) {
			game1.game = true;
		}
		if(GUI.Button(buttonCancelRect, "Cancel")){
			EndExam ();
		}
		GUI.DragWindow (new Rect (0, 0, 10000, 10000));
		string text = "    In this test, you need to copy the code within a limited amount of time. " +
						"If times runs out or you miscopy any part of the code, you will fail in this test." +
						"" +
						"" +
						"Press Start to begin the exam.";
		GUI.Label(textRect, text);
	}
	                     
}
