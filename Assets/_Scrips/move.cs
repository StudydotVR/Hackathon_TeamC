using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject pc;
	//Vector3 scale;
	public SwitchController sw;
	public AudioClip audioClip;
	AudioSource Source;

	void Start(){
		Source = gameObject.GetComponent<AudioSource> ();
		Source.clip = audioClip;
	}

		void Update()
	{
		if (sw.Get_flag() == true) {
			//scale = this.transform.lossyScale;
			this.transform.Rotate (Vector3.up * 5 * Time.deltaTime);  
			Source.PlayOneShot (audioClip);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			other.transform.SetParent(transform,true);

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			other.transform.SetParent(null,true);

		}
	}

}
