using UnityEngine;
using System.Collections;

public class force : MonoBehaviour {
	Rigidbody rigid;

	void Start(){
		
		rigid = gameObject.GetComponent<Rigidbody> ();
		if(rigid){
			rigid.constraints = RigidbodyConstraints.FreezeAll;

		}
}
	public void Move(float time){
		
		Invoke ("_Move", time);
	}

	void _Move(){
		
		if(rigid){
			rigid.constraints = RigidbodyConstraints.None;
			rigid.AddTorque (new Vector3 (2f * Random.value - 1f, 2f * Random.value - 1f, 2f * Random.value - 1f));
			Invoke ("TimeOut", 10f);
		}
	}

	void TimeOut(){
		DestroyImmediate (gameObject);
	}
}
