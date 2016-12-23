using UnityEngine;
using System.Collections;

public class PickupObjectScript : MonoBehaviour {

	private const float GRAVITY_STRENGHT =200.0f;
	private bool gravityActive = false;
	public WorldScript world;
	public CharacterScript giocatore;
	public GameObject missedObjSound;

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{


		this.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(this.transform.position.y, this.transform.position.x) * Mathf.Rad2Deg - 90, Vector3.forward);

	if ((this.transform.position - Vector3.zero).magnitude > world.GetGameRadius ()) {
			this.GetComponent<SpriteRenderer> ().enabled = true;
			this.collider2D.enabled= true;
		//	this.transform.Rotate( 0, 0, Time.deltaTime*-50);
	}

	if ((this.transform.position - Vector3.zero).magnitude <= world.GetGameRadius () && this.collider2D.enabled) {
			this.ResetPickUpPosition();
			giocatore.updateScore(this.gameObject,false);
			missedObjSound.audio.Play();
	}

	if ((this.transform.position - Vector3.zero).magnitude > world.GetGameRadius ()/2)
						this.gravityActive = true;
		if (gravityActive)
		{
			this.rigidbody2D.AddForce((Vector3.zero - this.transform.position).normalized * GRAVITY_STRENGHT * Time.deltaTime);
				}

	}

	public int getScore(CharacterScript.CharacterType man){
		if (man == CharacterScript.CharacterType.Chemister) {
				if (this.name == "potion")
						return 2;
				else
						return -15;
		} else {
			if(this.name == "potion")
				return -15;
			else
				return 2;
		}
	}

	public void ResetPickUpPosition(){
		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.collider2D.enabled= false;
		this.transform.position = Vector3.zero;
		this.gameObject.SetActive(false);
		this.rigidbody2D.velocity = Vector3.zero;
		this.gravityActive = false;
	}

	public void playSound(){
		audio.Play ();

	}
	

}
