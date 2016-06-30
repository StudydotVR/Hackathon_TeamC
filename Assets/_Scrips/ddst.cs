using UnityEngine;
using System.Collections;

public class ddst : MonoBehaviour {
    int jtest=0;
	int flag;
	private GameObject ob;
	//private GameObject ob2;

	/*public GameObject button1;
	public GameObject button2;
	public GameObject button3;*/
    // Use this for initialization
    void Start () {
        ob = GameObject.Find("qb");
       // ob2= GameObject.Find("eButton");
    }
	
	// Update is called once per frame
	void Update () {
        if (jtest == 1)
        {
            float y = gameObject.transform.position.y;
            y += 0.01f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

			flag = 1;
        }
    }
	public void OnClick()
    {
        jtest = 1;
        //ob2.SetActive(false);
        Debug.Log("ab");
		//
    }

	public int getflag(){
		
		return flag;
	}
	public void setflag(int _flag){
		flag = _flag;
	}
}
