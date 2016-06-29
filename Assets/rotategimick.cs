using UnityEngine;
using System.Collections;

public class rotategimick : MonoBehaviour
{
    
    private GameObject pc;
    Vector3 scale;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //scale = this.transform.lossyScale;
        if (sw.sw1 == 1)
        {
            this.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
    }
   void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {  
            pc = GameObject.FindWithTag("Player");
            // pc.transform.parent = transform;
            //this.transform.localScale = scale;
            
            pc.transform.SetParent(transform,true);
            Debug.Log("test5");
        }

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.localScale = scale;
            pc.transform.parent = null;
            
        }
    }
    
}


