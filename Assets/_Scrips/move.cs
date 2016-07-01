using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject pc;

	private Vector3 target;
	public float speed;

	//private bool flag;

	public SwitchController sc;

		void Update()
	{
		if (sc.Get_flag() == true) {

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
