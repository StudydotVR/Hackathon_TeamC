using UnityEngine;
using System.Collections;

public class IC_PoolScript : MonoBehaviour
{
    public float changeColorSpeed = 2f;

    private Material material;
    private Color toColor;
    private string nowState = "neutrality"; //中性=neutrality, 酸性=acidity, 塩基性=alkalinity 
    private bool isBTBsetting;

	void Start ()
    {
        material = GetComponent<Renderer>().material;
	}
	
	
	void Update ()
    {
        if (isBTBsetting == false) return;

        if (nowState == "neutrality") toColor = new Color(0, 1, 0, 0.5f);
        if (nowState == "acidity") toColor = new Color(1, 1, 0, 0.5f);
        if (nowState == "alkalinity") toColor = new Color(0, 0, 1, 0.5f);

        material.color = Color.Lerp(material.color, toColor, Time.deltaTime * changeColorSpeed);

    }



    /// <summary>
    /// GameControllerから
    /// </summary>

    public string GetNowState() {   return nowState;    }
    public bool GetBTBsetting() { return isBTBsetting; }
    public void SetBTB()        {   isBTBsetting = true;}

    public void SetState(string in_toState) { nowState = in_toState; }  //直接，状態を変える

    public void SetState(bool in_isAcidity) //何を加えたかで判定
    {
        if (in_isAcidity){
            switch (nowState) {
                case "neutrality": nowState = "acidity";    break;
                case "acidity":                             break;
                case "alkalinity": nowState = "neutrality"; break;
            }
        }
        if (!(in_isAcidity)){
            switch (nowState) {
                case "neutrality": nowState = "alkalinity";  break;
                case "acidity": nowState = "neutrality";     break;
                case "alkalinity":                           break;
            }
        }
    }
    
}
