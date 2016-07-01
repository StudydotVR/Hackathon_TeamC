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
    private int udoor;
    private float y = 0;

    public ddst fl;

	private Text text1; 
	private Text text2; 
	private Text text3;
    private bool playerEnter = false;



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
        
        if (udoor == 1)
        {
            door.transform.position += new Vector3(0, y, 0);
            y+=1;
        }

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
            playerEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // playerEnter = false;
        }
    }
	
	//button1
	public void OnClick1(){
        if (playerEnter == true)
        {
            if (currentNum == "first")
            {
                Debug.Log("a");
                newStart();
                playerEnter = false;

            }
            else
            {
                PlayerCharacter.hp -= 1;
            }
        }

	}

	//button2
	public void OnClick2(){
        if (playerEnter == true)
        {
            if (currentNum.Equals("second"))
            {
                newStart();
                playerEnter = false;
            }
            else
            {
                Debug.Log("hp");
                PlayerCharacter.hp -= 1;
            }
        }
	}

	//button3
	public void OnClick3(){
        if (playerEnter == true)
        {
            if (currentNum == "third")
            {
                newStart();
                playerEnter = false;
            }
            else
            {
                PlayerCharacter.hp -= 1;
            }
        }
	}

	public int Get_squiz(){
		return squiz;
	}

	void newStart(){
        udoor = 1;
		
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);
		Debug.Log ("restart");
	}

}
