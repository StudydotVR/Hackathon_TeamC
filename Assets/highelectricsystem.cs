using UnityEngine;
using System.Collections;

public class highelectricsystem : MonoBehaviour {
    public static  int hes;
    GameObject obj;
	// Use this for initialization
	void Start () {
        obj = GameObject.FindGameObjectWithTag("cloth");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hes = 1;
            obj.gameObject.SetActive(false);
        }
    }
    public int get_hes()
    {
        return hes;
    }
    
}
