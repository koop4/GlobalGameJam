using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {



	//public Text testoPg;
	private string testoPg1;
	private string testoPg2;
	private string testoPg3;


	public Image iconaPg1;
	public Image iconaPg2;
	public Image iconaPg3;

	public Sprite iconaMadre1;
	public Sprite iconaMadre2;
	public Sprite iconaMadre3;

	public Sprite iconaPadre1;
	public Sprite iconaPadre2;
	public Sprite iconaPadre3;

	public Sprite iconaBambino1;
	public Sprite iconaBambino2;
	public Sprite iconaBambino3;

	// Use this for initialization
	void Start () {
		//testoPg.text = "";
		testoPg1 = "Ciao,sono il pg 1";
		testoPg2 = "Ciao,sono il pg 2";
		testoPg3 = "Ciao,sono il pg 3";
		iconaPg1.sprite = iconaPadre2;
		iconaPg2.sprite = iconaBambino1;
		iconaPg3.sprite = iconaMadre1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiaUI(int qualePg){
		if (qualePg < 3) {
			switch (qualePg) {
			case 0://devo scurire il padre, attivare bambino
					iconaPg1.sprite = iconaPadre3;
					iconaPg2.sprite = iconaBambino2;
					break;
			case 1://devo scurire il padre, attivare bimbo
					iconaPg2.sprite = iconaBambino3;
					iconaPg3.sprite = iconaMadre2;
					break;
			case 2://devo scurire il bimbo
				iconaPg3.sprite = iconaMadre3;
					break;

			}
		}
	}

	public  void ResettaUI(){

		iconaPg1.sprite = iconaPadre2;
		iconaPg2.sprite = iconaBambino1;
		iconaPg3.sprite = iconaMadre1;

	}
}
