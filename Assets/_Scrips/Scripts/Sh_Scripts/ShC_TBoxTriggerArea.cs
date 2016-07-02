using UnityEngine;
using System.Collections;

public class ShC_TBoxTriggerArea : MonoBehaviour
{
    private Sh_BoxOpen par_boxOpen;

    void Start()
    {
        par_boxOpen = gameObject.transform.parent.gameObject.GetComponent<Sh_BoxOpen>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            par_boxOpen.EnterTriggerArea();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            par_boxOpen.ExitTriggerArea();
        }
    }
}
