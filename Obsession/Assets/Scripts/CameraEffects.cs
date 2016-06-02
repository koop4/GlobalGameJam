using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraEffects : MonoBehaviour {

	public GameObject cameraMain;
	public bool effect1;
	public bool effect2;
	public bool effect3;
	public float shakeAmount;

	public float fadeTime = 3f;
	Color colorToFadeTo;

	public CanvasGroup fadeCanvasGroup;

	void Start() {


	}


	
	// Update is called once per frame
	void Update () {

		if (effect1 == true)
		{
			Camera.main.transform.localPosition = Random.insideUnitSphere * shakeAmount;
		}else{
			Camera.main.transform.localPosition = Vector3.zero;
		}

		if (effect2 == true)
		{
			StartCoroutine ("FadeOut");
			Debug.Log ("Avviato");
		}else{

		}

		if (effect3 == true)
		{
			StartCoroutine ("FadeIn");
		}else{

		}
	}

	public IEnumerator FadeOut()
	{
		Debug.Log ("EntraOut");
		while (fadeCanvasGroup.alpha < 1f)
		{
			Debug.Log ("StartFadeOut");
			fadeCanvasGroup.alpha += fadeTime * Time.deltaTime;
			effect2 = false;
			yield return null;
		}
	}


	public IEnumerator FadeIn()
	{
		Debug.Log ("EntraIn");
		while (fadeCanvasGroup.alpha > 0f)
		{
			Debug.Log ("StartFadeOut");
			fadeCanvasGroup.alpha = fadeCanvasGroup.alpha - fadeTime * Time.deltaTime;
			effect3 = false;
			yield return null;
		}
	}




}
