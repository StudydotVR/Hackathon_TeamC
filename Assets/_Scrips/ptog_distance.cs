using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ptog_distance : MonoBehaviour {
    public GameObject player;
    public GameObject goal;
    public Text text;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 Apos = player.transform.position;
        Vector3 Bpos = goal.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);
        //Debug.Log("Distance : " + dis);
        text.text = "ゴールまでの距離:" + dis.ToString();
}
}
