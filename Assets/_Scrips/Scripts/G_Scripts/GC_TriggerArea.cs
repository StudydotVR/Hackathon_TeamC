using UnityEngine;
using System.Collections;

public class GC_TriggerArea : MonoBehaviour {

    private bool playerEnterFlag = false;

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnterFlag = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnterFlag = false;
        }
    }

    //GameControllerへ
    public bool GetEnterFlag()
    {
        return playerEnterFlag;
    }


}
