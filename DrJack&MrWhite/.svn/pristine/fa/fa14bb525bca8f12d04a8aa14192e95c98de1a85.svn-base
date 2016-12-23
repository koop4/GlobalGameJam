using UnityEngine;
using System.Collections;

public class TriggerCreator : MonoBehaviour {
	public float offset = 0.0f;
	public GameObject triggerPrefab;
	public WorldScript world;
	// Use this for initialization
	void Start () {

		do {
			Vector3 triggerPosition =  new Vector3(-Mathf.Cos(offset) * (world.GetGameRadius()), Mathf.Sin(offset) * (world.GetGameRadius()), this.transform.position.z);
			GameObject.Instantiate( this.triggerPrefab,triggerPosition,Quaternion.AngleAxis(0,Vector3.zero));
			offset+=0.3f;
		}
		while(offset<4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
