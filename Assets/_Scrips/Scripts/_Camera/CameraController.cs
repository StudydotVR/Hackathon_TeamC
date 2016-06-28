/*
カメラをプレイヤーに追従させるスクリプトです．

public変数のsmoothingはカメラ移動の滑らかさのことです．
また，rockCameraのチェックを外すと，マウスで左右が見渡せるようになります．
*/


using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
   
    public float smoothing = 5f;
    public bool rockCamera = true;
    public float fpsRotateSpeed = 1;

    private GameObject canvas;
    private GameObject player;
    private Vector3 offset;
    private Transform child_cameraTrans;
    private bool fpsMode = false;
    //private Vector3 firstPosition;
    private Quaternion firstRotation;           //最初のCameraAxisの回転角を保持
    private Vector3 firstCameraPosition;        //最初のカメラの位置を保持
    private Quaternion firstCameraRotation;     //最初のカメラの回転角を保持   
    private float rotateH;                      //fpsでの横軸回転
    private float rotateV;                      //fpsでの縦軸回転
//    private CanvasController canvasController;
    private bool enableChangeCamera = true; 
    
  
    void Awake()
    {
        //"Player"というタグが付いたオブジェクトを探しplayerに保存します．Sceneに配置したPlayerのタグが"Player"である必要があります．
        player = GameObject.FindGameObjectWithTag("Player");
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
        child_cameraTrans = transform.FindChild("Main Camera").transform;
    }

    void Start()
    {
//        canvasController = canvas.GetComponent<CanvasController>();
        //firstPosition = transform.position;
        firstRotation = transform.rotation;
        firstCameraPosition = child_cameraTrans.localPosition;
        firstCameraRotation = child_cameraTrans.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && enableChangeCamera)
        {
            enableChangeCamera = false;
            //canvasController.Blackout();
            Time.timeScale = 0;
            StartCoroutine(ChangeCamera());
        }

        if (fpsMode)    FPSMode();
        else            TPSMode();

        //カメラ切り替え時スローに
        Time.timeScale = Mathf.Lerp(Time.timeScale, 1, Time.deltaTime * 4);

        
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(0.05f);
        if (fpsMode == false) { fpsMode = true; ChangeFPS(); }
        else                  { fpsMode = false; ChangeTPS(); }
        yield return new WaitForSeconds(0.1f);
        enableChangeCamera = true;
    }

    void ChangeFPS()
    {
        player.SetActive(false);
        transform.position = transform.position + new Vector3(0, 1, 0);
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
        child_cameraTrans.localPosition = new Vector3(0, 0, 0);
        child_cameraTrans.localRotation = Quaternion.LookRotation(new Vector3(0, 0, 1));

    }

    void ChangeTPS()
    {
        player.SetActive(true);
        player.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.Scale(child_cameraTrans.forward, new Vector3(1, 0, 1))), 100);
        transform.position = transform.position + new Vector3(0, -1, 0);
        transform.rotation = firstRotation;
        child_cameraTrans.localPosition = firstCameraPosition;
        child_cameraTrans.localRotation = firstCameraRotation;
    }

    void FPSMode()
    {
        rotateH = -Input.GetAxis("Mouse Y");
        rotateV = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0, rotateV * fpsRotateSpeed, 0);
        child_cameraTrans.eulerAngles += new Vector3(rotateH * fpsRotateSpeed, 0, 0);
    }

    void TPSMode()
    {
        Vector3 newPosition = player.transform.position;
        //現在地と目的地とで線形補間してカメラを滑らかに動かしています（あんま気にしなくていいよ）
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothing);

        if (!(rockCamera))
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * 5, 0f);
        }
    }
}
