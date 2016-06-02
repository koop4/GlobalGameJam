using UnityEngine;
using System.Collections;

public class AutoDestroyObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
