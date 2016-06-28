/*
プレイヤーキャラクターの"性質"を定義しているスクリプトです．

入力は"PlayerUserControl"で受け取り，入力された値がMove関数に引数として送られてきます．

public変数
・walkSpeed      歩く速さです．
・runSpeed       走る速さです．
・rotateSpeed    方向転換する速さです．

Playerができる動き
・歩く（WSAD，アローキー）
・走る（歩き中にShift）
・アクション（Pキー）     ←遊びで作っただけ
*/


using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    
    public float walkSpeed = 1;
    public float runSpeed = 3;
    public float rotateSpeed = 15 * 60;
    
    private Animator anim;
    private bool enableMovement = true; 
   
    void Start ()
    {
        anim = GetComponent<Animator>();
    }


    //↓public関数は他のスクリプトから呼び出すことができます．
	public void Move(Vector3 movement, bool running, bool action)
    {
        float moveSpeed;
        if (running)    moveSpeed = runSpeed;
        else            moveSpeed = walkSpeed;

        if (action)     PlayAction();

        if (movement.magnitude > 0f && enableMovement)
        {
            transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        //AnimatorController(PlayerAC)内の変数を変更してアニメーションを遷移させます．
        anim.SetBool("IsWalking", !(movement.magnitude == 0f));
        anim.SetBool("IsRunning", running && !(movement.magnitude == 0f));
    }

    public void PlayAction()
    {
        enableMovement = false;
        anim.SetTrigger("PlayAction");
    }

    //Animation Event.
    public void EndAction()
    {
        enableMovement = true;
    }
}
