using UnityEngine;
using System.Collections;

public class MenuStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
				}
	}
}
