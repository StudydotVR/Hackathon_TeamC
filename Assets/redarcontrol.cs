using UnityEngine;
using System.Collections;

public class redarcontrol : MonoBehaviour {

	public GameObject target;
	// Use this for initialization
	void Start () {
		target.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			target.SetActive (true);
			Invoke ("off_radar", 1.0f);


		}
	}
	void off_radar(){
		

		Debug.Log ("off");
		target.SetActive (false);
	}




}
