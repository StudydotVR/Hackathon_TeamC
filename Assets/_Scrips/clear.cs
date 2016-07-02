using UnityEngine;
using System.Collections;

public class clear : MonoBehaviour {

	public AudioClip audioClip;
	AudioSource Source;

	void Start(){
		Source = gameObject.GetComponent<AudioSource> ();
		Source.clip = audioClip;
	}
		
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			Source.PlayOneShot (audioClip);
			Invoke("Load", 0.8f);

		}
	}

	void Load(){
		Application.LoadLevel ("Clear");
	}
}