using UnityEngine;
using System.Collections;

public class boardScript : MonoBehaviour {
	public GameObject board;
	public  Material material;
	static bool isBreak;
	// Use this for initialization
	void Start () {
		isBreak = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		
		if (board.tag == "red" && other.collider.tag == "pool" && !isBreak) {
			board.GetComponent<Renderer> ().material = material;
			Destroy (GameObject.FindGameObjectWithTag ("breakWall"), 1f);
			isBreak = true;
		}
	}
}
