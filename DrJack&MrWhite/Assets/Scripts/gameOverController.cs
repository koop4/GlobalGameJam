using UnityEngine;
using System.Collections;

public class gameOverController : MonoBehaviour {

    public GUIText text;

    private float timer;

    void Start()
    {
        this.timer = 0;
        int score = GameObject.Find("FinalScore").GetComponent<ScoreContainer>().score;
        text.text = "Your Score: " + score;
    }


	void Update() {
        this.timer += Time.deltaTime;
	if (Input.anyKey && timer >1.3f)
			Application.LoadLevel ("Main");
	}
}
