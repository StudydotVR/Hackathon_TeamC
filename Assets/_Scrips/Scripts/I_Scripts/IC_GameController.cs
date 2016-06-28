using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IC_GameController : MonoBehaviour
{
    public IC_PoolScript pipeGscript;
    public IC_PoolScript pipeYscript;
    public IC_PoolScript pipeBscript;
    public GameObject[] changedCamera;
    public Sh_DoorUp[] doorScript;
    public Sh_BoxOpen[] TboxScript;

    private CanvasController canvasController;
    private Text noticeText;
    private IC_ThrowCapsule playerSkill;
    
    
	
    void Start ()
    {
        canvasController = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
        noticeText = GameObject.FindGameObjectWithTag("Canvas").gameObject.transform.FindChild("NoticePanel").gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>();
        playerSkill = GameObject.FindGameObjectWithTag("Player").GetComponent<IC_ThrowCapsule>();

        //StartFloor
        StartCoroutine(StartFloor());

        //FirstFloor
        StartCoroutine(FirstFloor());

        //SecondFloor
        StartCoroutine(SecondFloor());
    }
    
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            
        }
        
	}    

    //初期の部屋
    IEnumerator StartFloor()
    {
        yield return new WaitUntil(() => TboxScript[0].GetOpenFlag());
        noticeText.GetComponent<Text>().text = "『BTBの書』を手に入れた！\nBTB溶液を加えた水溶液は酸性で黄，\n中性で緑，塩基性で青になる";
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeCamera(0));
    }
    
    //一つ目の部屋
    IEnumerator FirstFloor()
    {
        //条件を満たすまで実行を中断
        yield return new WaitUntil(() => pipeGscript.GetNowState() == "neutrality" && pipeYscript.GetNowState() == "acidity" && pipeBscript.GetNowState() == "alkalinity");
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeCamera(1));
    }

    //二つ目の部屋
    IEnumerator SecondFloor()
    {
        //条件を満たすまで実行を中断
        yield return new WaitUntil(() => TboxScript[1].GetOpenFlag());
        noticeText.GetComponent<Text>().text = "『リトマス試験紙の書』を手に入れた！\n酸性のとき青いリトマス紙は赤に，\n塩基性のとき赤いリトマス紙は青になる";
        playerSkill.enabled = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeCamera(2));
    }





    //各フロアクリア時のカメラ切り替え
    IEnumerator ChangeCamera(int i)
    {
        canvasController.DeactivateInputMessage();
        yield return new WaitForSeconds(0.1f);
        canvasController.Blackout();
        yield return new WaitForSeconds(0.1f);
        changedCamera[i].SetActive(true);
        yield return new WaitForSeconds(2f);
       doorScript[i].toggleUp();
        yield return new WaitForSeconds(2f);
        canvasController.Blackout();
        yield return new WaitForSeconds(0.1f);
        changedCamera[i].SetActive(false);
    }


    //空から落ちたとき
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
