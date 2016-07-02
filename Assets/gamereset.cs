using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gamereset : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (PlayerCharacter.hp == 0)
		{
			SceneManager.LoadScene("Maze");

		}	
	}
}
