using UnityEngine;
using System.Collections;

public class quizetoquize : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        player = GameObject.Find("Player");
        if (collision.gameObject.tag == "Player")
        {
            player.gameObject.transform.position = new Vector3(371,0,82); 
        }
    }
}
