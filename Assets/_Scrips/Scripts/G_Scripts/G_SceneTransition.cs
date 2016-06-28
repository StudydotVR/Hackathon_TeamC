using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class G_SceneTransition : MonoBehaviour {
    //OpenSceneName 開きたいSceneの名前,Inspectorで指定しよう
    //isSceneOpen 一回しか動かないのを保証する
    public string OpenSceneName;
    private bool isSceneOpen = false;

    public GameObject particle;
    private GameObject player;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	//Playerタグのついたオブジェクトが当たるとOpenSceneを実行
	private void OnTriggerEnter(Collider other){
		if(other.tag=="Player"&&isSceneOpen==false){
			StartCoroutine(OpenScene ());
		}
	}

	//Inspectorで指定したScene名のSceneに移動
	private IEnumerator OpenScene(){

        Instantiate(particle, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        yield return new WaitForSeconds(0.3f);
        player.GetComponent<PlayerCharacter>().PlayAction();
        yield return new WaitForSeconds(2);
		SceneManager.LoadScene(OpenSceneName);
		isSceneOpen = true;
	}
}
