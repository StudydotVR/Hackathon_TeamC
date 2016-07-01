using UnityEngine;
using System.Collections;

public class TC_TorchTriggerArea : MonoBehaviour {

    private TC_Torchelight par_Torchelight;

    void Start()
    {
        par_Torchelight = gameObject.transform.parent.gameObject.GetComponent<TC_Torchelight>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            par_Torchelight.EnterTriggerArea();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            par_Torchelight.ExitTriggerArea();
        }
    }
}
