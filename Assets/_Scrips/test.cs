using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	//public GameObject ob;

	void OnCollisionStay( Collision collision )
	{
		//　動く床に接触したら親子関係にする
		if (collision.gameObject.tag == "test")
		{
			transform.parent = collision.gameObject.transform;
		}
	}
	void OnCollisionExit()
	{
		transform.parent = null;
		//grounded = false;
	}
}
