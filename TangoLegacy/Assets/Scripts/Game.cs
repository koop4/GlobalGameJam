using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	//la variabile charInGame conta da 0 a 2 anzichè da 1 a 3
	private static int charInGame = 0;
	private static float timeCounter = 0;
	public GameObject[] characters = new GameObject[3];

	public Canvas canvas;
	public int dimensioneMappa;
//	public static bool collision= false;
	Character c1;
	Character c2;
	Character c3;

	public Image orologio;
	private bool orologioAvviato;
	//public static ColliderManager cManager;

	public AudioClip collisionAudio;
	public AudioClip spacebar;
	private AudioSource victorySound;

	private int countVictory;
	public Image tango;

	void Start () {
		c1 = characters [0].gameObject.GetComponent<Character> ();
		c2 = characters [1].gameObject.GetComponent<Character> ();
		c3 = characters [2].gameObject.GetComponent<Character> ();
		//salvo la posizione di inizio dei personaggi
		c1.startPos = c1.transform.position;
		c2.startPos = c2.transform.position;
		c3.startPos = c3.transform.position;

		GameObject.FindWithTag ("path"+charInGame).gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;
		c1.gameObject.SetActive(true);
		orologioAvviato = false;
		victorySound = transform.GetChild (0).gameObject.transform.GetComponent<AudioSource> ();
	}


	void Update(){
		//alla pressione della barra, il personaggio visibile si prepara a muoversi e 
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject.FindWithTag ("path"+charInGame).gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
			if(charInGame<2) {
				GameObject.FindWithTag ("path"+(charInGame+1)).gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;
			}
			gameObject.GetComponent<AudioSource>().clip = spacebar;
			//if(!c1.loop || !c2.loop || !c3.loop) gameObject.GetComponent<AudioSource>().Play ();
			characters [charInGame].gameObject.GetComponent<Character> ().loop = true;
			characters [charInGame].gameObject.GetComponent<AudioSource> ().volume=100f;

      canvas.GetComponent<UIScript>().CambiaUI(charInGame);
				
			if (charInGame < 2) {
						charInGame++;
						//viene visualizzato un nuovo personaggio
						characters [charInGame].SetActive (true);
				}
		}
	}



	void FixedUpdate () {


		timeCounter = 	timeCounter+ Time.fixedDeltaTime;
			if (timeCounter >= 1) { 
			//allo scadere di ogni secondo, se ci sono collisioni suki

				if (charInGame == 1 && !orologioAvviato){
					orologio.GetComponent<Orologio>().AvviaOrologio ();
					orologioAvviato = true;
				}
	//		Debug.Log(ColliderManager.anyCollision ());
			if(c3.loop){
				countVictory++;
			}

			if(countVictory==8 && !ColliderManager.anyCollision () ){
				Debug.Log("Hai vinto");
				StartCoroutine("Victory");
				//Victory()
			}
			if(ColliderManager.anyCollision ()) { 
				gameObject.GetComponent<AudioSource>().clip = collisionAudio;

				gameObject.GetComponent<AudioSource>().Play ();
				Reset(); 
			//	collision=false;
			}
			else {
			//	collision = ;
				ColliderManager.clearGrid();

				//altrimenti vengono avviate le animazioni fino alla successiva posizione dei pg in game (ndr. var loop)
					if (c1.loop) {	c1.moveToNewPlace ();	}
					if (c2.loop) {	c2.moveToNewPlace ();	}
					if (c3.loop) {	c3.moveToNewPlace ();	}
					
					//vengono mappate le successive posizioni per il futuro controllo
					//il timer di un secondo viene azzerato



			}	
			timeCounter = 0;
		}
			
	}


	public void Reset(){
		countVictory = 0;

		c1.transform.localScale = c1.facing;
		c2.transform.localScale = c2.facing;
		c3.transform.localScale = c3.facing;
	//	c3.Flip();

		//TODO PLAY SOUND

		c1.gameObject.SetActive (false);
		c2.gameObject.SetActive (false);
		c3.gameObject.SetActive (false);

		c1.gameObject.GetComponent<AudioSource> ().volume = 0f;
		c2.gameObject.GetComponent<AudioSource> ().volume = 0f;
		c3.gameObject.GetComponent<AudioSource> ().volume = 0f;

		// i pg vengono riportati alla posizione di ingresso
		c1.loop = false;
		c2.loop = false;
		c3.loop = false;

		c1.counterPos = 0;
		c2.counterPos = 0;
		c3.counterPos = 0;

		StopAllCoroutines();
		StartCoroutine (AspettaERiavvia (0.4f));
	//	c1.gameObject.transform.position = new Vector3(c1.startPos.transform.position.x)	                                               )
	//	c1.gameObject.transform.position = c1.places[0].transform.position;
		c1.transform.position = c1.places [c1.counterPos].transform.position;
		c2.transform.position = c2.places [c2.counterPos].transform.position;
		c3.transform.position = c3.places [c3.counterPos].transform.position;

	//	c2.gameObject.transform.position = c2.places [0].transform.position;
	//	c3.gameObject.transform.position = c3.places [0].transform.position;
		charInGame = 0;
	//	c1.loop = true;
		c1.gameObject.SetActive (true);
		canvas.GetComponent<UIScript>().ResettaUI();
		ColliderManager.clearGrid ();

	}

	IEnumerator Victory(){
		victorySound.volume = 100f;
		yield  return  new WaitForSeconds (8);
		tango.transform.GetComponent<Image> ().enabled = true;
		yield  return  new WaitForSeconds (8);
		victorySound.volume = 0f;
		Application.LoadLevel (2);

	}

	IEnumerator AspettaERiavvia(float secondi){
		yield return new WaitForSeconds(secondi);
		Application.LoadLevel (1);
	}


}
