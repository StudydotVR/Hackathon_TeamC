using UnityEngine;
using System.Collections;

public class Sh_Button : MonoBehaviour {

    public GameObject Box;
    private Sh_BoxOpen Open;
    private Animator animate;

   
    void Start()
    {
        Open = Box.GetComponent<Sh_BoxOpen>();
        animate = GetComponent<Animator>();
    }

 
    public void togglePU()
    {
        animate.SetBool("PushPushButton", true);
    }

    void OnTriggerEnter(Collider other)
    {
        togglePU();
        Open.toggleOp();
    }
}
