using UnityEngine;
using System.Collections;

public class qs : MonoBehaviour {
    public static int squiz;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            squiz = 1;
        }
    }
}
