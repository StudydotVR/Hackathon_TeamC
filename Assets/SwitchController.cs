using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	public float speed;

	private Vector3 target;
	private bool flag;


	void Start () {
		target = transform.position - new Vector3 (0, 0.4f, 0);

	}

	void OnTriggerEnter (Collider col) {

		if(col.gameObject.tag == "Player"){
			//Debug.Log ("on");

			flag = true;

		}
	}

	void Update () {
		if(flag == true){
		float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}

	}

	public bool Get_flag(){
		return flag;
	}
}
