using UnityEngine;
using System.Collections;

public class movecube : MonoBehaviour {

	//public NavMeshAgent agent;
	//public Animator animator;

	//int beforce;

	void OnTriggerEnter(Collider other){
		Debug.Log("test");
		if (other.CompareTag ("cube")) {
			other.gameObject.SendMessage ("Move", 1f, SendMessageOptions.DontRequireReceiver);


		}
	}
}
;