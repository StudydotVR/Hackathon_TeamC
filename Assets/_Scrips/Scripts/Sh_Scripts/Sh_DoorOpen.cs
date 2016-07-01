using UnityEngine;
using System.Collections;

public class Sh_DoorOpen : MonoBehaviour
{
    public Animator anim;

 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E))
        {
            toggleOp();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            toggleCl();
        }
    }


    public void toggleOp()
    {
        anim.SetBool("IsOpening", true);
    }


    public void toggleCl()
    {
        anim.SetBool("IsOpening", false);
    }
}





