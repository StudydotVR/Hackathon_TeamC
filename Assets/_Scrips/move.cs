using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject pc;
	Vector3 scale;
	public cswitch cs;
		void Update()
	{
		if (cs.GetSw() == 1) {
			scale = this.transform.lossyScale;
			this.transform.Rotate (Vector3.up * 5 * Time.deltaTime);  
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
