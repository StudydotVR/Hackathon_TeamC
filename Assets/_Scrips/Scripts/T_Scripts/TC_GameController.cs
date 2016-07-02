using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TC_GameController : MonoBehaviour
{
    public TC_Torchelight[] torchScript;
    public Sh_DoorUp[] doorUpScript;
    public Sh_BoxOpen[] TboxScript;

    private Text noticeText;



    void Start ()
    {
        noticeText = GameObject.FindGameObjectWithTag("Canvas").gameObject.transform.FindChild("NoticePanel").gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>();

        StartCoroutine(StartFloor());
        StartCoroutine(FirstFloor());
        StartCoroutine(SecondFloor());
        StartCoroutine(ThirdFloor());
    }
	
    //地上
    IEnumerator StartFloor()
    {
        yield return new WaitUntil(() => TboxScript[0].GetOpenFlag());
        noticeText.GetComponent<Text>().text = "『カンテラ』を手に入れた!\nこれで松明に炎をつけることができる";
        yield return new WaitForSeconds(1);
        doorUpScript[0].toggleUp();
    }

    //一つ目の部屋
    IEnumerator FirstFloor()
    {
        yield return new WaitUntil(() => torchScript[0].GetCorrectFlag());
        torchScript[0].SetConstant();
        yield return new WaitForSeconds(1);
        doorUpScript[1].toggleUp();
    }

    //二つ目の部屋
    IEnumerator SecondFloor()
    {
        yield return new WaitUntil(() => TboxScript[1].GetOpenFlag());
        noticeText.GetComponent<Text>().text = "『炎色反応の書』を手に入れた！\nカリウムで紫，銅で緑，\nナトリウムで黄，リチウムで赤の炎になる";
        yield return new WaitForSeconds(1);
        doorUpScript[2].toggleUp();
    }

    //三つ目の部屋
    IEnumerator ThirdFloor()
    {
        yield return new WaitUntil(() => torchScript[1].GetCorrectFlag() && torchScript[2].GetCorrectFlag() && torchScript[3].GetCorrectFlag() && torchScript[4].GetCorrectFlag());
        torchScript[1].SetConstant();
        torchScript[2].SetConstant();
        torchScript[3].SetConstant();
        torchScript[4].SetConstant();
        yield return new WaitForSeconds(1);
        doorUpScript[3].toggleUp();
    }
    
}
