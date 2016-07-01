using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public GameObject door;
	public Material[]  materials;
	//private Animator animator;
	//private bool opened;
	public GameObject parent;
	// Use this for initialization
	void Start () {
		//animator = parent.GetComponent<Animator>();
		//opened = false;
	}


	// Update is called once per frame
	void Update () {
	/*	if (Input.GetKey (KeyCode.R)) {
			door.GetComponent<Renderer>().material = materials [1];
		}*/
		/*if (Input.GetKey (KeyCode.B)) {
			door.GetComponent<Renderer>().material = materials [0];
		}*/
	}

	void OnCollisionEnter(Collision other) {
	if (other.collider.tag == "Acidity" && door.tag == "blueDoor") {
		door.GetComponent<Renderer>().material = materials[1];
		Destroy (other.collider.gameObject);
			Destroy (door, 1f);
		}
	if (other.collider.tag == "Alkalinity" && door.tag == "redDoor") {
		door.GetComponent<Renderer> ().material = materials [0];
		Destroy (other.collider.gameObject);
			Destroy (door, 1f);
		}
/*	if (!opened) {
			opened = true;
			if (transform.tag == "red") {
				animator.SetBool ("DoorRed", opened);
				//		animator.SetBool ("",opened);
			} else {
				animator.SetBool ("animationBlue", opened);
			}
	}*/

	}

}
