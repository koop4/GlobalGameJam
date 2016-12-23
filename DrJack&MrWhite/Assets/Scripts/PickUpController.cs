using UnityEngine;
using System.Collections;

public class PickUpController : MonoBehaviour {
	private float timer;
	public GameObject[] pickups;
	public CharacterScript giocatore;
	private float[] strengthLevel = { 136.5f,160.0f,178.0f }; //160,178

	private bool gravityActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject thrown;

		timer += Time.deltaTime;
		if(timer>1 && !pickups[0].activeSelf && !pickups[1].activeSelf){

			int indice = Random.Range(0,3);
			if(indice == 0){
				if(giocatore.currentType== CharacterScript.CharacterType.Chemister)
					thrown = pickups[0];
				else
					thrown = pickups[1];
			}
			else {
				thrown = pickups[Random.Range(0,2)];
			}
				thrown.SetActive(true);
				Vector3 target = giocatore.transform.position;
				Quaternion rotation = Quaternion.Euler(0,0,-28);
				target = rotation*target;

				thrown.rigidbody2D.AddForce((target-this.transform.position).normalized* strengthLevel[indice]);
			thrown.rigidbody2D.AddTorque(100);
				timer=0.0f;
			
		}


	}
}
