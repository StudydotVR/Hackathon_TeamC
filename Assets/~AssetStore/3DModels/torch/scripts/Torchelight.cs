using UnityEngine;
using System.Collections;

public class Torchelight : MonoBehaviour {

	public GameObject TorchLight;
	public GameObject MainFlame;
	public GameObject BaseFlame;
	public GameObject Etincelles;
	public GameObject Fumee;
	public float MaxLightIntensity;
	public float IntensityLight;

    private Light torchLight;
    private ParticleSystem.EmissionModule mf_emission;
    private ParticleSystem.EmissionModule bf_emission;
    private ParticleSystem.EmissionModule et_emission;
    private ParticleSystem.EmissionModule fu_emission;


    void Start () {
        torchLight = TorchLight.GetComponent<Light>();
        mf_emission = MainFlame.GetComponent<ParticleSystem>().emission;
        bf_emission = BaseFlame.GetComponent<ParticleSystem>().emission;
        et_emission = Etincelles.GetComponent<ParticleSystem>().emission;
        fu_emission = Fumee.GetComponent<ParticleSystem>().emission;

        torchLight.intensity = IntensityLight;
        mf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
        bf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
        et_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
        fu_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);
    }


	void Update () {
        if (IntensityLight < 0) IntensityLight = 0;
        if (IntensityLight > MaxLightIntensity) IntensityLight = MaxLightIntensity;

        torchLight.intensity = IntensityLight / 2f + Mathf.Lerp(IntensityLight - 0.1f, IntensityLight + 0.1f, Mathf.Cos(Time.time * 30));
        torchLight.color = new Color(Mathf.Min(IntensityLight / 1.5f, 1f), Mathf.Min(IntensityLight / 2f, 1f), Mathf.Min(IntensityLight / 2f, 1f));

        mf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 20f);
        bf_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 15f);
        et_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 7f);
        fu_emission.rate = new ParticleSystem.MinMaxCurve(IntensityLight * 12f);

    }

}
