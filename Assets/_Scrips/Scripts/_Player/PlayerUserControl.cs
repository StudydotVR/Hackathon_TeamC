/*
"PlayerCharacter"スクリプトにユーザーの入力を送るスクリプトです．

入力はすべてここで受け取り，"PlayerCharacter"の中にあるMove関数を呼び出すことで
プレイヤーを操作します．
*/


using UnityEngine;
using System.Collections;

public class PlayerUserControl : MonoBehaviour
{
    private PlayerCharacter character;
    private Transform camTrans;

    void Start ()
    {
        character = GetComponent<PlayerCharacter>();
        camTrans = Camera.main.transform;
    }
	
	void Update ()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        bool running = Input.GetKey(KeyCode.LeftShift);
		bool action = Input.GetKeyDown (KeyCode.P);
		
        //見下ろし視点のときにPlayerを傾かせないため（あんま気にしなくていいよ）
        Vector3 camForward = Vector3.Scale(camTrans.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = moveHorizontal * camTrans.right + moveVertical * camForward;

		character.Move(movement, running, action);
    }

   
}
