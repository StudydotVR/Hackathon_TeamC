using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public GameObject Door;
    private Sh_DoorOpen Open;
    
	// Use this for initialization
	void Start ()
    {
    Open = Door.GetComponent<Sh_DoorOpen>();
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Open.toggleOp();
        //Door.GetComponent<DoorOpen>().toggle();
    }
}
