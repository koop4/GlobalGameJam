using UnityEngine;
using System.Collections;

public class ShakeObject : MonoBehaviour {


	public float speed = 1.0f; //how fast it shakes
	public float amount = 1.0f; //how much it shakes

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xPosition = Mathf.Sin(Time.time * speed);
		float yPosition = Mathf.Sin(Time.time * speed);
		this.gameObject.transform.localPosition = new Vector3(transform.localPosition.x, yPosition, transform.localPosition.z);

	}
}
