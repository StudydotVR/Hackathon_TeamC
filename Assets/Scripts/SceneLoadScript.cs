using UnityEngine;
using System.Collections;

public class SceneLoadScript : MonoBehaviour {
	
	public AudioClip audioClip;
	AudioSource Source;

	void Start(){
		Source = gameObject.GetComponent<AudioSource> ();
		Source.clip = audioClip;
	}

	/*void OnClick(){
	//	if (Input.GetKeyDown (KeyCode.A) == true) {
			Source.PlayOneShot (audioClip);
			Invoke("MainScene", 1f);
		//}

	}*/


	public void MainScene() {
		Source.PlayOneShot (audioClip);
		Invoke("Load", 0.8f);

	}

	void Load(){
		Application.LoadLevel("Maze");
	}
}