using UnityEngine;
using System.Collections;

public class triggerController : MonoBehaviour {
	public float offset = 0.0f;

	// Use this for initialization
	void Start () {
		//float offset = 0.0f;
		Vector3 triggerPosition =  new Vector3(-Mathf.Cos(offset) * (1.15f), Mathf.Sin(offset) * (1.15f), this.transform.position.z);
		do {
			GameObject.Instantiate( this.gameObject,triggerPosition,Quaternion.AngleAxis(0,Vector3.zero));
			offset+=0.3f;
		}
		while(offset<4);
	}		                                     


	void Update () {
	
	}

/*	void OnTriggerEnter(Collider other)
	{

		
	}
*/

}
