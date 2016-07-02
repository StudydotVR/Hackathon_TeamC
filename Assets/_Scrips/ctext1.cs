using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ctext1 : MonoBehaviour {
	private Text text;
	public qs flag;
	public qs flag2;

	public string[] word; 

	private int next;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.name == "Text1") {
			if (flag.Get_squiz () == 1) {
				text.text = word[0];
			} 
			   if (flag2.Get_squiz () == 1) {
				text.text = "10円玉";
			}
		} 
		else if (this.gameObject.name == "Text2") {
			if (flag.Get_squiz () == 1) {
				text.text = "折り紙";
			} 
			   if (flag2.Get_squiz () == 1) {
				text.text = "カギ";
			}
		}
		else if (this.gameObject.name == "Text3") {
			if (flag.Get_squiz () == 1) {
				text.text = "砂糖";
			} 
			if (flag2.Get_squiz () == 1) {
				text.text = "シャープペンシルの芯";
			}
		}

	}
}
