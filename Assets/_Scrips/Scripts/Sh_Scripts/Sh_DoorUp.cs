using UnityEngine;
using System.Collections;

public class Sh_DoorUp : MonoBehaviour
{
    private Animator anim;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }


    public void toggleUp()
    {
        anim.SetBool("IsDoorOpening", true);
    }
}
