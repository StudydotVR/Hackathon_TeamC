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

    private GameObject target;
    private Vector3 offset;
  
    void Awake()
    {
        //"Player"というタグが付いたオブジェクトを探しtargetに保存します．Sceneに配置したPlayerのタグが"Player"である必要があります．
        target = GameObject.FindGameObjectWithTag("Player");
    }

	
	void Update ()
    {
        Vector3 newPosition = target.transform.position;
        //現在地と目的地とで線形補間してカメラを滑らかに動かしています（あんま気にしなくていいよ）
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothing);


        if (!(rockCamera))
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * 5, 0f);
        }
    }
}
