using UnityEngine;
using System.Collections;

public class cswitch : MonoBehaviour {
	GameObject ob;
	private int sw=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			sw = 1;
		}
	}

	public int GetSw()
	{
		return sw;
	}

}
