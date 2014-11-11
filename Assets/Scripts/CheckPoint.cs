using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	private Rect examRect1;
	private Rect examRect2;
	private PlayerController player;
	private bool exam;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		exam = false;
		examRect1 = new Rect(100, 100, 500, 500);
		examRect2 = new Rect(650, 100, 500, 500);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.G)){
			exam = false;
			Debug.Log("AAA");
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			exam = true;
			player.CheckPoints ++;
			deactivate();
		}
	}

	void deactivate(){
		renderer.enabled = false;
		collider.enabled = false;
	}	

	void OnGUI(){
		if(exam){
			GUI.color = Color.red;
			GUI.Window(0, examRect1, showExam, "Exam1");
			GUI.color= Color.blue;
			GUI.Window(1, examRect2, showExam, "Exam2");
		}
	}
	
	void showExam(int windowID){
		if(GUI.Button(new Rect(10, 20, 120, 50), "Hello World"))
			Debug.Log("AAAAA");
		GUI.DragWindow (new Rect (0, 0, 10000, 10000));
	}
	                     
}
