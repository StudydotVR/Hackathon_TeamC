using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour{
	private Rigidbody rb;
	private int count;
	public float speed;
	public Text countText;
	public Text winText;

void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

void FixedUpdate()
{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement);
}

void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUP") {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
	}


}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 8) 
		{
			countText.text = " ";
			winText.text = "YOU WIN";
	    }
    }
}

