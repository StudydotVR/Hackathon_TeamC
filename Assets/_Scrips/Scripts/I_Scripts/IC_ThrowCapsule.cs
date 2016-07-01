using UnityEngine;
using System.Collections;

public class IC_ThrowCapsule : MonoBehaviour {

    public GameObject capsuleRedObject;
    public GameObject capsuleBlueObject;
    //public GameObject switchSObj;

    private switchScript switchS;
    private bool capsuleBlue;
    private bool capsuleRed;

    void Start () {
        //switchS = switchSObj.GetComponent<switchScript>();
    }
	

	void Update () {
        capsuleBlue = Input.GetKeyDown (KeyCode.B);
		capsuleRed = Input.GetKeyDown (KeyCode.R);
        Vector3 pos = transform.forward;

        pos = pos + new Vector3(0, 0.5f, 0);
        //pos.x = pos.x 

        //bool getBool = switchS.getBool();
        if (true)
        {
            if (capsuleBlue)
            {
                Instantiate(capsuleBlueObject, transform.position + pos * 1.1f, Quaternion.LookRotation(transform.forward));
            }
            if (capsuleRed)
            {
                Instantiate(capsuleRedObject, transform.position + pos * 2, Quaternion.LookRotation(transform.forward));
            }
        }
    }


}
