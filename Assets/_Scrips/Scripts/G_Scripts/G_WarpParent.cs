using UnityEngine;
using System.Collections;

public class G_WarpParent : MonoBehaviour {

	//canBack Inspectorでチェックを入れるとHole2からHole1に戻れるようになる
	public bool canBack=false;
	//G_WarpChildクラスの変数、関数を使うための呪文
	private GameObject Hole1,Hole2;
	private G_WarpChild _WarpChild1, _WarpChild2;

	//G_WarpChildクラスの変数、関数を使うための呪文
	private void Start(){
		Hole1 = transform.FindChild ("G_Hole1").gameObject;
		_WarpChild1 = Hole1.GetComponent<G_WarpChild>();
		Hole2 = transform.FindChild ("G_Hole2").gameObject;
		_WarpChild2 = Hole2.GetComponent<G_WarpChild>();
	}

	//G_WarpChildクラスのOnTriggerEnterから
	//HoleName Playerの乗ったワープホールの名前。乗った方からもう一個の方に飛ぶよ
	//player Playerが入ってるよ
	public void Warp(string HoleName,GameObject player){
		if (HoleName == "G_Hole2"&&canBack) {
			player.transform.position = Hole1.transform.position;
			_WarpChild1.isWarp = true;
		}
		if (HoleName == "G_Hole1") {
			player.transform.position = Hole2.transform.position;
			_WarpChild2.isWarp = true;
		}
	}
}
