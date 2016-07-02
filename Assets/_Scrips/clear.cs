using UnityEngine;
using System.Collections;

public class clear : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			Application.LoadLevel ("Clear");
		}


	}
}