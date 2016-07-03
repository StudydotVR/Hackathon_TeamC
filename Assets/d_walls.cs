using UnityEngine;
using System.Collections;

public class d_walls : MonoBehaviour {
   GameObject one;
    public GameObject wall;
    //private int num;
    
	// Use this for initialization
	void Start () {
        one = GameObject.FindGameObjectWithTag("wall");
    }
	
	// Update is called once per frame
	void Update () {
       // highelectricsystem hs= one.GetComponent<highelectricsystem>();
        if (highelectricsystem.hes == 1)
        {
            one.SetActive(false);
        }
	}
}
