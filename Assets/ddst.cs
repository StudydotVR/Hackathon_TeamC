using UnityEngine;
using System.Collections;

public class ddst : MonoBehaviour {
    int jtest=0;
    GameObject ob;
    GameObject[] ob2;
    // Use this for initialization
    void Start () {
        ob = GameObject.Find("qb");
        ob2= GameObject.FindGameObjectsWithTag("button");
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
            float y = 0;
            for (y = 0; y < 10; y += 0.01f)
            {
                gameObject.transform.localPosition=new Vector3(4.37f, 11.06f+y*Time.deltaTime, 10.36f);
            }
        }
    }
    public void OnClick()
    {
        jtest = 1;
        //ob.gameObject.transform.Translate(up*Time.deltaTime,0,0);
        for (int i = 0; i < ob2.Length; i++)
        {
            ob2[i].SetActive(false);
        }
        

    }
}
