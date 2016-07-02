using UnityEngine;
using System.Collections;

public class ShC_Switch : MonoBehaviour
{
    private Animator anim;
    private Renderer buttonColor;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        buttonColor = transform.FindChild("Button_Push").gameObject.GetComponent<Renderer>();
    }
	
	
	public void PushingAnimator()
    {
        anim.SetBool("IsPushing", true);
       
	}

    //Animation Event.
    public void ToggleSwitch()
    {
        buttonColor.material.color = Color.blue;
    }
}
