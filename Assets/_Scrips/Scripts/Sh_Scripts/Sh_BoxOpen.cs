

using UnityEngine;
using System.Collections;

public class Sh_BoxOpen : MonoBehaviour
{
    private GameObject canvas;
    private Animator animate;
    private bool openFlag = false;
    private bool playerEnterFlag = false;



    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Start()
    {
        animate = GetComponent<Animator>();

        StartCoroutine(toggleOp());
    }

   
    //PlayerがTriggerAreaに入ったとき
    public void EnterTriggerArea()
    {
        playerEnterFlag = true;
        if (!(openFlag)) canvas.GetComponent<CanvasController>().ActivateInputMessage();
    }

    //PlayerがTriggerAreaから出たとき
    public void ExitTriggerArea()
    {
        playerEnterFlag = false;
        canvas.GetComponent<CanvasController>().DeactivateInputMessage();
    }


    public IEnumerator toggleOp()
    {
        yield return new WaitUntil(()=> playerEnterFlag && !(openFlag) && Input.GetKeyDown(KeyCode.E));

        openFlag = true;
        animate.SetBool("IsOpening", true);
        canvas.GetComponent<CanvasController>().DeactivateInputMessage();
        yield return new WaitForSeconds(1f);
        canvas.GetComponent<CanvasController>().Notice();
        StartCoroutine(CloseNotice());
    }

    IEnumerator CloseNotice()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        canvas.GetComponent<CanvasController>().Notice();
    }

    /*
    public void toggleCl()
    {
        openFlag = false;
        animate.SetBool("IsOpening",false);
    }
    */


    //GameControllerへ
    public bool GetOpenFlag()
    {
        return openFlag;
    }
}