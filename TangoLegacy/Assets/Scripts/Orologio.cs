using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Orologio : MonoBehaviour {

	public Sprite ora0;
	public Sprite ora1;
	public Sprite ora2;
	public Sprite ora3;
	public Sprite ora4;
	public Sprite ora5;
	public Sprite ora6;
	public Sprite ora7;
	bool partito;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetComponent<Image> ().sprite = ora0;

	}

	public void AvviaOrologio(){
		partito = true;
		StartCoroutine ("GiraOrologio");
	}

	// Update is called once per frame
	void Update () {
	
	}

	 IEnumerator GiraOrologio(){
		gameObject.transform.GetComponent<Image> ().sprite = ora1;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora2;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora3;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora4;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora5;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora6;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora7;
		yield return new WaitForSeconds(1.0f);
		gameObject.transform.GetComponent<Image> ().sprite = ora0;
		yield return new WaitForSeconds(1.0f);

		if (partito) {
			StartCoroutine("GiraOrologio");
		}

	}
}
