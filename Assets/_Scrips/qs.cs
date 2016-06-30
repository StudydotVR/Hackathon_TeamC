using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class qs : MonoBehaviour
{
	
	public string currentNum ;
	
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject door;

	public ddst fl;

	private Text text1; 
	private Text text2; 
	private Text text3; 



	public string[] word;


    private int squiz = 0;

	void Start () 
	{
		text1 = button1.transform.FindChild ("Text1").gameObject.GetComponent<Text>();
		text2 = button2.transform.FindChild ("Text2").gameObject.GetComponent<Text>();
		text3 = button3.transform.FindChild ("Text3").gameObject.GetComponent<Text>();
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);


	}
	

	void Update ()
	{
		/*if(fl.getflag() == 1){
			fl.setflag (0) ;
			newStart ();*/

	
	/*if (squiz == 0) {
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
		} else {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
		}*/

    }
	void OnTriggerEnter(Collider other)
    {
		
		if (other.gameObject.tag== "Player")
        {
			Debug.Log ("in");
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);

			text1.text = word [0];
			text2.text = word [1];
			text3.text = word [2];
            squiz = 1;

        }
    }
	
	//button1
	public void OnClick1(){
	
	if (currentNum == "first") {
		Debug.Log ("a");
			newStart ();
			
		} 
	else {
			PlayerCharacter.hp-=1;
		}

	}

	//button2
	public void OnClick2(){
	if (currentNum == "second") {
			newStart ();
		}
	else {
		PlayerCharacter.hp-=1;
	}
	}

	//button3
	public void OnClick3(){
	if (currentNum == "third") {
			newStart ();
		}
	else {
		PlayerCharacter.hp-=1;
	}
	}

	public int Get_squiz(){
		return squiz;
	}

	void newStart(){
		door.transform.position += new Vector3 (0,5,0);
		
		//yield return new WaitUntil (()=> fl.getflag() == 1);
		/*text1 = button1.transform.FindChild ("Text1").gameObject.GetComponent<Text>();
		text2 = button2.transform.FindChild ("Text2").gameObject.GetComponent<Text>();
		text3 = button3.transform.FindChild ("Text3").gameObject.GetComponent<Text>();*/
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);
		Debug.Log ("restart");

		//Update();
	}

}
