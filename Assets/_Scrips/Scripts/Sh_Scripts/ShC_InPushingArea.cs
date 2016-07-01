using UnityEngine;
using System.Collections;

public class ShC_InPushingArea : MonoBehaviour
{
    private ShC_Switch par_switch; 

    void Start()
    {
        par_switch = gameObject.transform.parent.gameObject.GetComponent<ShC_Switch>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            par_switch.PushingAnimator();
        }
    }
   
}
