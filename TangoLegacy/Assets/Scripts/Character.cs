using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Character : MonoBehaviour {

	public Vector3 startPos;
	public GameObject endPos;
	public Vector3 facing;
	public int counterPos;
	public bool loop;
	public GameObject[] places = new GameObject[8];
  	public int qualePg;

	bool char1Exception=false;

	private AudioSource rumorePersonaggio;

//	Transform nextPlace;

	void Start () {
		counterPos = 0;
		facing = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
 		gameObject.transform.position = places [counterPos].transform.position;
	//	if (gameObject.tag == "char3") {
	//					this.Flip ();
	//				this.transform.FindChild("madre").GetComponent<SpriteRenderer> ().sortingLayerName = "BehindHome";
	//			}

		rumorePersonaggio = transform.GetChild (0).gameObject.transform.GetComponent<AudioSource> ();
	}


	public void moveToNewPlace(){
		//TODO aggiorna la matrice responsabile della gestione delle collisioni 
		if (gameObject.tag == "char2") {	ColliderManager.addCharacterToPosition (this.getNextC2Pos ());	}
		if (gameObject.tag == "char3") {	ColliderManager.addCharacterToPosition (this.getNextC3Pos ());	}
		if (gameObject.tag == "char1") {	ColliderManager.addCharacterToPosition (this.getNextC1Pos ());	}


		// fa partire l'animazione via cooroutine
		if (counterPos < 7) {
			counterPos++;
		} else {
			counterPos = 0;
		}

		//caso eccezione char1 movimento ultimo
		if (gameObject.tag == "char1" && counterPos == 0) {
			this.Flip();

			float startTime = Time.time;
	//		while(Time.time < startTime + 0.5f)
			this.transform.FindChild("padre").GetComponent<SpriteRenderer> ().sortingLayerName = "InternalWall";

				Vector3 target = GameObject.Find("char3sp").transform.position;
			StartCoroutine (MoveObject (gameObject.transform.position, target, 0.5f,true));

		} 
		else {
			//tutti gli altri casi di spostamento
				StartCoroutine (MoveObject (gameObject.transform.position, places [counterPos].transform.position, 1f,false));
		}

	}


	IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime, bool casoUnico)
	{

		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			gameObject.transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		gameObject.transform.position = target;
		if (casoUnico) {
			gameObject.transform.position = startPos;
			rumorePersonaggio.Play ();
		StartCoroutine (MoveObject (gameObject.transform.position, places [1].transform.position, 0.5f,false));
		}
	}


	public void Flip(){
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;
	}

	//questo pg utilizza tutto il tempo (8 unità), 
	//quindi l ultimo movimento uscirà da un lato ed entrerà nell'altro
	public int[] getNextC1Pos(){
		switch(counterPos+1){
		case 1:
			this.transform.FindChild("padre").GetComponent<SpriteRenderer> ().sortingLayerName = "CharacterUp";

			return new int[] {2,1};
		case 2:return new int[] {1,1};
		case 3:return new int[] {1,2}; 
		case 4:return new int[] {1,2}; 
		case 5:
			this.Flip ();
			return new int[] {1,1};
		case 6:
			this.Flip ();
			return new int[] {0,1};
		case 7:
			this.Flip ();
			return new int[] {0,0};

			/*
		case 4:return new int[] {1,2}; 
		case 5:	return new int[] {1,2};
		case 6:return new int[] {1,1};
		case 7:return new int[] {0,1};
		case 8:return new int[] {0,0};*/
		}
		return new int[] {3,3};
	}


	public int[] getNextC2Pos(){
		switch (counterPos + 1) {

		case 1:
			rumorePersonaggio.Play ();
			this.transform.localScale = facing;
			this.transform.FindChild("bambino").GetComponent<SpriteRenderer> ().sortingLayerName = "InternalWall";

			return new int[] {1,0};
		case 2:	return new int[] {1,1};
		case 3:return new int[] {1,2}; 
		case 4:return new int[] {1,2}; 
		case 5:
			this.Flip ();

			return new int[] {1,1};

		case 6:return new int[] {1,0};
		case 7:				
			return new int[] {3,3};

			/*
		case 5:return new int[] {1,2};
		case 6:return new int[] {1,1};
		case 7:return new int[] {1,0};
		case 8:return new int[] {3,3};
*/
		}
		return new int[] {3,3};
}


	public int[] getNextC3Pos(){
		switch(counterPos+1){
		case 1:
			this.transform.localScale = facing;

			//this.transform.FindChild("padre").GetComponent<SpriteRenderer> ().sortingLayerName = "InternalWall";
			rumorePersonaggio.Play ();
			return new int[] {0,0};
		case 2:
			this.Flip();
			this.transform.FindChild("madre").GetComponent<SpriteRenderer> ().sortingLayerName = "CharacterDown";

			return new int[] {0,1};
		case 3:return new int[] {0,1}; 
		case 4:return new int[] {0,1}; 
			return new int[] {0,1};
		case 5:
			this.Flip();

			return new int[] {0,0};
		case 6:
			this.Flip();
			this.transform.FindChild("madre").GetComponent<SpriteRenderer> ().sortingLayerName = "InternalWall";

			return new int[] {3,3};

		case 7:


			return new int[] {3,3};
	//	case 8:return new int[] {3,3};

		}
		return new int[] {3,3};
	}


 //	public Vector3


/*	void FixedUpdate() {
		if ((gameObject.transform.position == startPos) && qualePg == 3) {
						if (gameObject.transform.FindChild ("madre").GetComponent<SpriteRenderer> ().sortingLayerName != "BehindHome") {
								gameObject.transform.FindChild ("madre").GetComponent<SpriteRenderer> ().sortingLayerName = "BehindHome";
						}
				}
		else {
			if( qualePg == 3){
				if (gameObject.transform.FindChild ("madre").GetComponent<SpriteRenderer> ().sortingLayerName == "BehindHome" ){
				gameObject.transform.FindChild ("madre").GetComponent<SpriteRenderer> ().sortingLayerName = "Characters";
				}
			}
		}

	}*/
}