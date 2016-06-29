using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dbutton : MonoBehaviour {
    public static int dst = 0;
    // Use this for initialization
    GameObject[] ob;
	void Start () {
        //canvas = GetComponent<Canvas>();
        ob = GameObject.FindGameObjectsWithTag("button");

	}

    // Update is called once per frame
    void Update() {
        if (qs.squiz == 0)
        {
            for (int i = 0; i < ob.Length; i++)
            {
                ob[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < ob.Length; i++)
            {
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