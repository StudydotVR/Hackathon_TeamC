using UnityEngine;
using System.Collections;

public class TC_Torchelight : MonoBehaviour
{
    
    public GameObject TorchLight;
    public GameObject MainFlame;
    public GameObject FlamBlue;
    public GameObject FlamGreen;
    public GameObject FlamRed;
    public GameObject FlamYellow;
    public GameObject firstFlame;       //初期の炎が何色か指定
    public float MaxLightIntensity;
	public float IntensityLight = 1;
    public bool constantFlame;          //操作できないTorch（ただの置物のときチェック）
    public string correctColor;

    private GameObject canvas;
    private Light torchLight;
    private ParticleSystem.EmissionModule mf_emission;
    private ParticleSystem.EmissionModule bf_emission;
    private ParticleSystem.EmissionModule et_emission;
    private ParticleSystem.EmissionModule fu_emission;
    private GameObject changeFlame;
    private string nowColor = "";
    private bool correctFlag = false;
    private bool playerEnterFlag = false;


    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Start ()
    {
        torchLight = TorchLight.GetComponent<Light>();
        mf_emission = firstFlame.GetComponent<ParticleSystem>().emission;
        bf_emission = firstFlame.transform.FindChild("base_flam").GetComponent<ParticleSystem>().emission;
        et_emission = firstFlame.transform.FindChild("etincelles").GetComponent<ParticleSystem>().emission;
        fu_emission = firstFlame.transform.FindChild("fumee").GetComponent<ParticleSystem>().emission;

        torchLight.intensity = IntensityLight;
        mf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
        bf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
        et_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
        fu_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);

        changeFlame = firstFlame;
    }


	void Update ()
    {
        if (IntensityLight < 0) IntensityLight = 0;
        if (IntensityLight > MaxLightIntensity) IntensityLight = MaxLightIntensity;

        torchLight.intensity = IntensityLight / 2f + Mathf.Lerp(IntensityLight - 0.1f, IntensityLight + 0.1f, Mathf.Cos(Time.time * 30));
        torchLight.color = new Color(Mathf.Min(IntensityLight / 1.5f, 1f), Mathf.Min(IntensityLight / 2f, 1f), Mathf.Min(IntensityLight / 2f, 1f));

        mf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
        bf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
        et_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
        fu_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);

        if (playerEnterFlag)
        {
            if (constantFlame) return;

            if (Input.GetKeyDown(KeyCode.Space)) { changeFlame = MainFlame; nowColor = ""; }
            if (Input.GetKeyDown(KeyCode.B)) { changeFlame = FlamBlue; nowColor = "Blue"; }
            if (Input.GetKeyDown(KeyCode.G)) { changeFlame = FlamGreen; nowColor = "Green"; }
            if (Input.GetKeyDown(KeyCode.R)) { changeFlame = FlamRed; nowColor = "Red"; }
            if (Input.GetKeyDown(KeyCode.Y)) { changeFlame = FlamYellow; nowColor = "Yellow"; }
            if (Input.GetKeyDown(KeyCode.K)) { IntensityLight = 0; return; }

            if (Input.GetKeyDown(KeyCode.E))
            {
                LightTorch();
            }
        }
    }

   
    void LightTorch()
    {
        //いったん全部非アクティブに
        MainFlame.SetActive(false);
        FlamBlue.SetActive(false);
        FlamGreen.SetActive(false);
        FlamRed.SetActive(false);
        FlamYellow.SetActive(false);

        //つけたい炎だけアクティブに
        changeFlame.SetActive(true);

        mf_emission = changeFlame.GetComponent<ParticleSystem>().emission;
        bf_emission = changeFlame.transform.FindChild("base_flam").GetComponent<ParticleSystem>().emission;
        et_emission = changeFlame.transform.FindChild("etincelles").GetComponent<ParticleSystem>().emission;
        fu_emission = changeFlame.transform.FindChild("fumee").GetComponent<ParticleSystem>().emission;

        //炎が変わるたびに初期化
        IntensityLight = 0;
        torchLight.intensity = IntensityLight;
        mf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
        bf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
        et_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
        fu_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);

        //炎をつける
        IntensityLight = 1;

        //正しい色の炎かどうか
        if (nowColor == correctColor) correctFlag = true;
        else correctFlag = false;
    }


    //PlayerがTriggerAreaに入ったとき
    public void EnterTriggerArea()
    {
        if (constantFlame) return;

        playerEnterFlag = true;
        if (!(constantFlame)) canvas.GetComponent<CanvasController>().ActivateInputMessage();
        //Debug.Log("aaa");
    }

    //PlayerがTriggerAreaから出たとき
    public void ExitTriggerArea()
    {
        if (constantFlame) return;

        playerEnterFlag = false;
        canvas.GetComponent<CanvasController>().DeactivateInputMessage();
    }


    //GameControllerへ
    public bool GetCorrectFlag()
    {
        return correctFlag;
    }

    public void SetConstant()
    {
        constantFlame = true;
        canvas.GetComponent<CanvasController>().DeactivateInputMessage();
    }
}

