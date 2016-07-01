using UnityEngine;
using System.Collections;

public class IC_SwitchScript : MonoBehaviour
{
    public string property;    //酸性=acidity, 塩基性=alkalinity，BTB溶液=BTB
    public GameObject pool;
    public GameObject[] pipe;
    public GameObject pipeB;
    public GameObject pipeG;
    public GameObject pipeY;
    public GameObject waterDropper;

    private CanvasController canvasController;
    private Animator anim;
    private IC_PoolScript poolScript;
    private IC_PoolScript[] pipeScript = new IC_PoolScript[7];
    private IC_PoolScript pipeBscript;
    private IC_PoolScript pipeGscript;
    private IC_PoolScript pipeYscript;
    private bool isAcidity; //加えたのが酸性か（塩基性か）どうか
    private bool playerEnterFlag;

   
    void Start()
    {
        canvasController = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
        anim = GetComponent<Animator>();
        poolScript = pool.GetComponent<IC_PoolScript>();
        for (int i = 0; i < pipe.Length; i++)   pipeScript[i] = pipe[i].GetComponent<IC_PoolScript>();
        pipeBscript = pipeB.GetComponent<IC_PoolScript>();
        pipeGscript = pipeG.GetComponent<IC_PoolScript>();
        pipeYscript = pipeY.GetComponent<IC_PoolScript>();
    }

    void Update()
    {
        if(playerEnterFlag && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(InputSwitch());
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("IsOpening", true);
            canvasController.ActivateInputMessage();
            playerEnterFlag = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("IsOpening", false);
            canvasController.DeactivateInputMessage();
            playerEnterFlag = false;
        }
    }

    IEnumerator InputSwitch()
    {
        waterDropper.GetComponent<Animator>().SetTrigger("IsWaterDropping");
        canvasController.DeactivateInputMessage();
        yield return new WaitForSeconds(1);
        if (property == "acidity")
        {
            isAcidity = true;
            poolScript.SetState(isAcidity);
            StartCoroutine(PipeSetState());
        }
        else if (property == "alkalinity")
        {
            isAcidity = false;
            poolScript.SetState(isAcidity);
            StartCoroutine(PipeSetState());
        }
        else if (property == "BTB")
        {
            StartCoroutine(PipeSetBTB());
        }

        if(playerEnterFlag) canvasController.ActivateInputMessage();
    }


    IEnumerator PipeSetState()
    {
        for(int i=0; i<pipe.Length; i++){
            yield return new WaitForSeconds(0.3f);
            pipeScript[i].SetState(isAcidity);
        }
        Pipe3Setter();
    }

    IEnumerator PipeSetBTB()
    {
        poolScript.SetBTB();    //仮置き
        for (int i = 0; i < pipe.Length; i++){
            yield return new WaitForSeconds(0.3f);
            pipeScript[i].SetBTB();
        }
        Pipe3Setter();
    }

    void Pipe3Setter()
    {
        if (pipeScript[6].GetBTBsetting())
        {
            switch (pipeScript[6].GetNowState())
            {
                case "neutrality": pipeGscript.SetBTB(); pipeGscript.SetState("neutrality"); break;
                case "acidity": pipeYscript.SetBTB(); pipeYscript.SetState("acidity"); break;
                case "alkalinity": pipeBscript.SetBTB(); pipeBscript.SetState("alkalinity"); break;
            }
        }
    }
}

   
