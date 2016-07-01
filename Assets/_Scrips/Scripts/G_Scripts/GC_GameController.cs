using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_GameController : MonoBehaviour {

    
    public GC_TriggerArea[] cameraRotator;
    public Transform[] changedCameraPoint;
    
    private CanvasController canvasController;
  

    void Start()
    {
        canvasController = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();

        StartCoroutine(ChangeSideCamera());
        StartCoroutine(ChangeUpCamera());
    }
	
	


    IEnumerator ChangeSideCamera()
    {
        yield return new WaitUntil(() => cameraRotator[0].GetEnterFlag());
        canvasController.Blackout();
        yield return new WaitForSeconds(0.1f);
        Camera.main.transform.position = changedCameraPoint[0].position;
        Camera.main.transform.rotation = changedCameraPoint[0].rotation;
    }

    IEnumerator ChangeUpCamera()
    {
        yield return new WaitUntil(() => cameraRotator[1].GetEnterFlag());
        canvasController.Blackout();
        yield return new WaitForSeconds(0.1f);
        Camera.main.transform.position = changedCameraPoint[1].position;
        Camera.main.transform.rotation = changedCameraPoint[1].rotation;
    }


    //空に落ちたとき
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("G_MainScene");
        }
    }
}
