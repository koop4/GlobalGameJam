using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {
	public GameObject day;
	public GameObject swap;
	public GameObject current;
	public GameObject night;
	public int k;
	// Use this for initialization
	void Start () {
		swap = night;
		current = day;
		k = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-1 * Time.deltaTime, 0, 0);
		if (this.transform.position.x < -4*k && swap.transform.position.x < current.transform.position.x) {
			swap.transform.Translate (new Vector3 (17, 0, 0));
			k++;
			GameObject aux = swap;
			swap=current;
			current = aux;

		}
	}
}
