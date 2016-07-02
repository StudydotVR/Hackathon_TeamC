using UnityEngine;
using System.Collections;

public class sw : MonoBehaviour {
    GameObject obj;
    int x,rs;
    public static int sw1 = 0;

    private AudioSource sound01;

	// Use this for initialization
	void Start () {
        obj = GameObject.Find("lever");
    }
	
	// Update is called once per frame
	void Update () {
        if (rs == 1 && x<50)
        {
            sw1 = 1;
            x += 5;
            obj.transform.rotation = Quaternion.Euler(0, 0, x);
        }
        else
        {
            rs = 0;
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sound01 = GetComponent<AudioSource>();
            sound01.PlayOneShot(sound01.clip);
            rs = 1;
            
            Debug.Log("test2");
        }

    }
}
