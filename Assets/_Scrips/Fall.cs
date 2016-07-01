using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	private int flag =0;
	public GameObject ob; 
	private float pos_y ;
	//

	void Start(){
		pos_y = ob.transform.position.y;
	}
	void Update () {
		if (flag == 1) {
			//float y = gameObject.transform.position.y;
			pos_y -= 0.01f;
			transform.position = new Vector3(transform.position.x, pos_y, transform.position.z);

		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			//setflag ();
				Invoke ("setflag", 0.5f);
			//flag = 1;
		}
	}

	void setflag(){
		//Debug.Log ("fall");
		flag = 1;
	}


}
