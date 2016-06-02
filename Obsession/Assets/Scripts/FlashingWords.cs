using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class FlashingWords : MonoBehaviour {

	//public List<string> goodWords;
	public List<string> badWords;
	//public List<GameObject> wordsInScene;
	public GameObject player;
	public GameObject wordPrefab;
	public bool playWords;
	//public int randomNumber;

	public float timeToWait;
	public int amountOfWordsToSpawn;

	Vector2 pos;
	Vector3 posFinal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (timeToWait >= 10f) {
			playWords = true;
			timeToWait = 0f;
		}

		if (playWords) {
			StartCoroutine ("WordsHandler");
		}

		timeToWait += 0.02f;

	}
		


	public IEnumerator WordsHandler(){
		for(int i = 0; i < amountOfWordsToSpawn; i++){

			pos = Random.insideUnitCircle * 3;
			Debug.Log ("i: " + i);
            posFinal = new Vector3(player.gameObject.transform.position.x + pos.x, player.gameObject.transform.position.y + pos.y, -1);
			GameObject obj = Instantiate(wordPrefab, posFinal , wordPrefab.transform.rotation)as GameObject;
            obj.GetComponent<MeshRenderer>().sortingOrder = 4;
			obj.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			obj.gameObject.GetComponent<TextMesh> ().text = badWords[i];
			obj.gameObject.transform.Rotate(0,0, UnityEngine.Random.Range(-10, 10));
			//wordsInScene.Add (wordPrefab);
		}
		playWords = false;
		yield return null;
	}

		
}
