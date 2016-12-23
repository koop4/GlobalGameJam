using UnityEngine;
using System.Collections;

public class Button_start : MonoBehaviour {


    public StartScreen startScreen;


	// Use this for initialization
	void Start () {
	    //lo riposiziono in base alla dimensione dello schermo
        //this.transform.position = new Vector3(this.transform.position)
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.startScreen.currentMode == StartScreen.Mode.Credits)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.collider2D.enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.collider2D.enabled = true;
        }
	}

    void OnMouseDown()
    {
        Application.LoadLevel("Istruction");
    }
}
