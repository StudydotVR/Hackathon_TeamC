using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    private Animator anim;
    private bool isMenuOpening = false;
    private bool isNoticeOpening = false;
    private bool isInputOpening = false;
    private bool isInputsOpening = false;


	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M)) Menu();
        if (Input.GetKeyDown(KeyCode.N)) Notice();
        if (Input.GetKeyDown(KeyCode.I)) ActivateInputMessage();

        if (isInputOpening && Input.GetKeyDown(KeyCode.Space))  OpenInputPanels();
        if (isInputsOpening && Input.GetKeyDown(KeyCode.RightArrow)) ExchangeRight();
    }




    /// <summary>
    /// BackgroundPanelの操作
    /// </summary>
    
    public void Blackout()
    {
        anim.SetTrigger("BP_Blackout");
    }



    /// <summary>
    /// MwnuPanelの操作
    /// </summary>

    public void Menu()
    {
        if (isMenuOpening) { anim.SetBool("MP_Opening", false); isMenuOpening = false; }
        else {               anim.SetBool("MP_Opening", true);  isMenuOpening = true; }
    }

    //Buttonのイベント
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickRetire()
    {
        SceneManager.LoadScene("G_MainScene");
    }


    /// <summary>
    /// NoticePanelの操作
    /// </summary>

    public void Notice()
    {
        if (isNoticeOpening) { anim.SetBool("NP_Opening", false); isNoticeOpening = false;  Time.timeScale = 1; }
        else {                 anim.SetBool("NP_Opening", true);  isNoticeOpening = true;   Time.timeScale = 0; }
    }




    /// <summary>
    /// InputPanelの操作
    /// </summary>
    
    public void DeactivateInputMessage()
    {
        anim.SetBool("IP_Opening", false);
        anim.SetBool("IPs_Opening", false);
        isInputOpening = false;
        isInputsOpening = false;
    }

    public void ActivateInputMessage()
    {
       anim.SetBool("IP_Opening", true);
        isInputOpening = true;
    }

    void OpenInputPanels()
    {
        anim.SetBool("IPs_Opening", true);
        isInputsOpening = true;
    }

    void ExchangeRight()
    {
        anim.SetTrigger("IPs_ExchangeRight");
    }
   
}
