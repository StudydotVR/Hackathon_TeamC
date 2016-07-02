using UnityEngine;
using System.Collections;

public class Switch_Box : MonoBehaviour {

    public GameObject Box;
    private Sh_BoxOpen Open;

    // Use this for initialization
    void Start()
    {
        Open = Box.GetComponent<Sh_BoxOpen>();

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
