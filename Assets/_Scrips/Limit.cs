using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {

		if(col.gameObject.tag == "Player"){
			//プレイヤーが落下した時
			col.gameObject.transform.position =
				Vector3.zero;   //位置を初期化
			
		}
	}
}
