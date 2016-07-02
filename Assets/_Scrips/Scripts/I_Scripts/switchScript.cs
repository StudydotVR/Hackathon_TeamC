using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {
	public Material[]  materials;
	public GameObject  Iswitch;
	public GameObject  pool;
	public GameObject  door;
	static int[] checkCollision;
	static public bool   getBook;
    //int count;
	// Use this for initialization
	void Start () {
		//count = 0;
		getBook = false;
		checkCollision = new int[3];
		for (int i = 0; i < 3; i++) {
			checkCollision [i] = 0;
		}

	}

	// Update is called once per frame
	void Update () {
	}
	void deleteDoor(){
		getBook = true;
		//	door.GetComponent<Renderer> ().material = materials [2];
		Destroy (door, 1f);
	}
	void OnCollisionEnter(Collision other) {
		
		if (other.collider.tag == "Player") {
			
			switch (Iswitch.tag) {
			case "neutral":
				pool.GetComponent<Renderer> ().material = materials [0];
				checkCollision [0] = 1;

				break;
			case "Acidity":
				pool.GetComponent<Renderer> ().material = materials [1];
				checkCollision [1] = 1;
				break;
			case "Alkalinity":
				pool.GetComponent<Renderer> ().material = materials [2];
				door.GetComponent<Renderer> ().material = materials [3];
				checkCollision [2] = 1;
				break;

			}
			int check = 0;
			for (int i = 0; i < 3; i++) {
				check = check + checkCollision [i];
			}
			if (check == 3 && !getBook) {
				deleteDoor ();
			}

	}
}
	public bool getBool(){
		return getBook;
	}
}