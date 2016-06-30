using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dbutton : MonoBehaviour {
    public static int dst = 0;
	public qs flag1;
	public qs flag2;
	//private int nextquiz;
    // Use this for initialization
    GameObject[] ob;

	void Start () {
        //canvas = GetComponent<Canvas>();
        ob = GameObject.FindGameObjectsWithTag("button");
		//nextquiz = 1;

	}

    // Update is called once per frame
    void Update() {
		/*
		if (flag1.Get_squiz() == 0 || flag2.Get_squiz()==0)
        {
            for (int i = 0; i < ob.Length; i++)
            {
                ob[i].SetActive(false);
            }
        }
		else if(flag1.Get_squiz() == 1 || flag2.Get_squiz()==1)
        {
            for (int i = 0; i < ob.Length; i++)
            {
				Debug.Log ("a");
                ob[i].SetActive(true);
            }
        }

        /*else
        {
            foreach (Transform child in canvas.transform)
            {
                if (child.CompareTag("button"))
                {
                    child.gameObject.SetActive(true);
                }
            }
            */
            //gameObject.SetActive(true);
            //}
    }
    void OnClick()
    {
        dst = 1;
    }
    }