using UnityEngine;
using System.Collections;

public class udfloor1 : MonoBehaviour {
   int flag=0;
    float pkeep;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (flag == 0)
        {
            float x = 0;
            x += 0.01f;
           
            transform.Translate(0, x, 0);
            if (x >=10)
            { 
                pkeep = x;
                 flag = 1;
            }
           
        }
        
        if (flag == 1)
        {
            float x;
            x = pkeep;
            x -=0.01f;
            transform.Translate(0, x, 0);
            if (x ==0.0f)
            {
                flag = 0;
            }
        }
        

	}
}
