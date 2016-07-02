using UnityEngine;
using System.Collections;

public class G_WarpChild : MonoBehaviour {

	private G_WarpParent _WarpParent;
	private GameObject parent;
	public bool isWarp = false;

	private void Start(){
		parent = transform.root.gameObject;
		_WarpParent = parent.GetComponent<G_WarpParent>();
	}

	private void OnTriggerEnter(Collider other){
		if (other.tag == "Player"&&isWarp==false) {
			_WarpParent.Warp (this.gameObject.name,other.gameObject);
		}
	}
	private void OnTriggerExit(Collider other){
		if (other.tag == "Player"&&isWarp==true) {
			isWarp = false;
		}
	}
}
