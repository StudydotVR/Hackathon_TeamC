using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject pc;
	Vector3 scale;

	void Update()
	{
		scale = this.transform.lossyScale;
		this.transform.Rotate(Vector3.up*3*Time.deltaTime);  

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			other.transform.SetParent(transform,true);

		}

	}
	/*void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{  
			
			pc = GameObject.FindWithTag("Player");
			pc.transform.parent = transform;
			this.transform.localScale = scale;
			Debug.Log("test5");
		}

	}*/
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			other.transform.SetParent(null,true);

		}
	}

}
