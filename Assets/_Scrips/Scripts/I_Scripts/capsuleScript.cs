using UnityEngine;
using System.Collections;

public class capsuleScript : MonoBehaviour {
	private Rigidbody rigid;
	public PlayerCharacter player;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		//Vector3 playerVector = player.transform.position;
		rigid.AddForce (this.gameObject.transform.forward * 1000);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other) {
	/*	if (other.collider.tag == "Player") {
			
	}*/
		
		/*Vector3 playerVector = other.collider.transform.forward;
		float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);
		Vector3 dir = new Vector3 (Mathf.Cos (angleDir), Mathf.Sin (angleDir), 0.0f);
		rigid.AddForce (dir * 2 playerVector * 2 + new Vector3(0,0,0), ForceMode.VelocityChange);*/
	}
}
