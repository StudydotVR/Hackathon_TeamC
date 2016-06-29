using UnityEngine;
using System.Collections;

public class ddst : MonoBehaviour {
    int jtest=0;
    GameObject ob;
    GameObject ob2;
    // Use this for initialization
    void Start () {
        ob = GameObject.Find("qb");
        ob2= GameObject.Find("eButton");
    }
	
	// Update is called once per frame
	void Update () {
        /*Debug.Log(dbutton.dst);
        if (dbutton.dst == 1)
        {
            ob.gameObject.SetActive(false);
        }
        */
        if (jtest == 1)
        {
            float y = gameObject.transform.position.y;
            y += 0.01f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
               
        }
    }
    public void OnClick()
    {
        jtest = 1;
        //ob.gameObject.transform.Translate(up*Time.deltaTime,0,0);
       // for (int i = 0; i < ob2.Length; i++)
        //{
            ob2.SetActive(false);
            Debug.Log("ab");
        //}
        

    }
}
