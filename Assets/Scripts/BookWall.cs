using UnityEngine;
using System.Collections;

public class BookWall : MonoBehaviour {
	public bool explode;
	private GameObject[] books;
	private bool exploded;
	// Use this for initialization
	void Start () {
		books = GameObject.FindGameObjectsWithTag("book");
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
	}

	void destroyAll(){
		for(int i = 0; i < books.Length; i++){
			Destroy(books[i]);
		}
	}


}
