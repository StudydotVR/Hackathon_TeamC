using UnityEngine;
using System.Collections;
using UnityEngine.UI; //uGUIを使うとき必ず必要

public class SelectStart : MonoBehaviour {
	Button start; //スタートボタン

	void Start () {

		//StartUIと言うキャンバスのSTARTという名前のボタンオブジェクトを取得
		start = GameObject.Find("StartUI/Start").GetComponent<Button>();


		}
}