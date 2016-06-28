using UnityEngine;
using System.Collections;

public class fallinfScript : MonoBehaviour {
	public  GameObject redBoard;
	public  GameObject blueBoard;
	//public  GameObject redBlueBoard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision other){
		if (other.collider.tag == "Player") {
			//SpringJoint redJoint =  redBoard.GetComponents<SpringJoint> ();
			//SpringJoint blueJoint = blueBoard.GetComponents<SpringJoint> ();
			if (redBoard.GetComponent<Rigidbody>() == null) {
				Rigidbody redRigid = redBoard.AddComponent<Rigidbody>();
				Rigidbody blueRigid = blueBoard.AddComponent<Rigidbody> ();
				//Rigidbody redBlueRigid = redBlueBoard.AddComponent<Rigidbody>();
				redRigid.useGravity = true;
				redRigid.constraints = RigidbodyConstraints.FreezeRotation;


			//	redRigid.isKinematic = true;
				blueRigid.useGravity = true;
				blueRigid.constraints = RigidbodyConstraints.FreezeRotation;

			//	redBlueRigid.useGravity = true;
			//	redBlueRigid.constraints = RigidbodyConstraints.FreezeRotation;


			//	blueRigid.isKinematic = true;
			}

			//redRigid.AddForce (0, 10000000000000, 0);
			//blueRigid.AddForce (0, 10000000000000, 0);

		}
	}
}
