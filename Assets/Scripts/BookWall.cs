using UnityEngine;
using System.Collections;

public class BookWall : MonoBehaviour {
	public bool explode;
	private GameObject[] books;
	private bool exploded; 
	public int number;
	// Use this for initialization
	void Start () {
		switch (number){
			case 1:
				books = GameObject.FindGameObjectsWithTag("book1");
				break;
			case 2:
				books = GameObject.FindGameObjectsWithTag("book2");
				break;
			case 3:
				books = GameObject.FindGameObjectsWithTag("book3");
				break;
			case 4:
				books = GameObject.FindGameObjectsWithTag("book4");
				break;
			case 5:
				books = GameObject.FindGameObjectsWithTag("book5");
				break;
			default:
				Debug.Log("Unknown bookwall");
				break;
		}

		exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(explode){
			Explode();
			explode = false;
		}

		if(exploded){
			Invoke("destroyAll", 3);
		}
	}

	void Explode(){
		for(int i = 0; i < books.Length; i++){
			books[i].collider.enabled = true;
		}

		for(int i = 0; i < books.Length; i++){
			books[i].rigidbody.constraints = RigidbodyConstraints.None;
		}
		exploded = true;
		gameObject.collider.enabled = false;
	}

	void destroyAll(){
		for(int i = 0; i < books.Length; i++){
			Destroy(books[i]);
		}
	}


}
