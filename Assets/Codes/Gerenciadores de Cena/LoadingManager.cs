using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour {
	AsyncOperation aop;
	public GameObject barra;
	float smoothprogress=0;
    private Vector3 barraVector;
	// Use this for initialization
	void Start () {
		//carrega a cena sem parar o jogo
		aop=SceneManager.LoadSceneAsync(MainData.NextScene);
		aop.allowSceneActivation = false;//para o carregamento automatico
        barraVector = new Vector3(barra.transform.localScale.x, barra.transform.localScale.y, barra.transform.localScale.z);
	}
	void Update(){
		smoothprogress = Mathf.MoveTowards(smoothprogress, aop.progress,
			Time.deltaTime*2);//escala gradualmente o tamanho da barra
		barra.transform.localScale=
			new Vector3(smoothprogress * barraVector.x, barraVector.y, barraVector.z);//aplica a escala a barra

		if (smoothprogress > 0.89f) {//se a barra esta proxima ao maximo libera o loading
			aop.allowSceneActivation = true;
		}
	}

}
