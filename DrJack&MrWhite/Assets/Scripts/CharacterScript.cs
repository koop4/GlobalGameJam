﻿using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{

    public int score_life;
    private float score_points;
    public float Score_points { get { return this.score_points; } }
    private const float DEFAULT_SPEED = 1.5f;
    private const float GRAVITY_STRENGTH = 0.150f;
    private const float JUMP_STRENGTH = 0.04f;
    private const float JUMP_STRENGTH_HORIZONTAL = 0.0f;
    private const float ANIMATION_SPEED = 9.5f;
    private const float WALKING_OFFSET = 0.1f;
    public GameObject soundGood;
    public GameObject soundBad;
    public GUIText GUIScore;
	public float increaser;

    public enum CharacterType { Chemister, Drunk };
    public CharacterType currentType;

    public float Speed = DEFAULT_SPEED;
    private float earthRadius = 4.6f;

    private float _offset = 0, walkOffset;
    private float vSpeed = 0;

    private float timeCounter;

    //timers
    private float timer_animation;

    //riferimenti agli altri oggetti
    public WorldScript world;

    //sprites
    public Sprite[] sprite_chemister;
    public Sprite[] sprite_drunk;

    //flags
    private bool canJump = true;

    //signals
    public bool signal_onVerticalAxis;


    // Use this for initialization
    void Start()
    {
        //  this.Speed = DEFAULT_SPEED;
        this.score_life = 100;
    }

    // Update is called once per frame
    void Update()
    {
		increaser += Time.deltaTime;
		if (increaser > 1) {
			increaser=0.0f;
			if(this.score_life<100)
				this.score_life++;
		}

        this.transform.position = new Vector3(-Mathf.Cos(this.timeCounter * this.Speed) * (this.earthRadius + this._offset + this.walkOffset), Mathf.Sin(this.timeCounter * this.Speed) * (this.earthRadius + this._offset + this.walkOffset), this.transform.position.z);
        this.timeCounter += Time.deltaTime;
        this.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(this.transform.position.y, this.transform.position.x) * Mathf.Rad2Deg - 90, Vector3.forward);

        //ottengo il radius del mondo a seconda della sua dimensione
        this.earthRadius = this.world.GetGameRadius();
        this._offset += vSpeed;
        this.walkOffset = Mathf.Abs(Mathf.Sin(timeCounter * 6) * WALKING_OFFSET);

        //controllo se mi trovo sull'asse verticale
        if (Mathf.Abs(Vector3.Angle(this.transform.position, Vector3.up)) <= 6 || Mathf.Abs(Vector3.Angle(this.transform.position, Vector3.down)) <= 6)
            this.signal_onVerticalAxis = true;
        else
            this.signal_onVerticalAxis = false;

        //se sono a contatto con il terreno
        if (this._offset == 0)
        {
            //quando tocco terra resetto il flag canJump
            this.canJump = true;

        }
        else if (this._offset < 0)
        {
            //sono entrato nel terreno
            this.vSpeed = 0;
            this._offset = 0;
        }
        else //sono in aria
        {
            //aggiorno la gravità
            this.vSpeed -= GRAVITY_STRENGTH * Time.deltaTime;

        }

        if (this.canJump && Input.GetKeyDown(KeyCode.Space))
        {
            if (this._offset == 0)
                this.Jump(1);
            else
                this.Jump(1.2f);
        }

        //aggiorno lo sprite in base al tipo corrente
        this.timer_animation += Time.deltaTime * ANIMATION_SPEED * this.Speed;
        if (this.currentType == CharacterType.Chemister)
            this.GetComponent<SpriteRenderer>().sprite = this.sprite_chemister[(int)(this.timer_animation % this.sprite_chemister.Length)];
        else
            this.GetComponent<SpriteRenderer>().sprite = this.sprite_drunk[(int)(this.timer_animation % this.sprite_chemister.Length)];

        //agiorno posizione camera
        //Camera.main.transform.position = new Vector3(this.transform.FindChild(.position.x, this.transform.position.y, Camera.main.transform.position.z);

        //aggiorno gui punteggio
        this.score_points += Time.deltaTime * 100;
        this.GUIScore.text = ((int)(this.score_points)).ToString();
        Vector3 textPos = Vector3.MoveTowards(Camera.main.transform.position,Vector3.zero,4f);
        this.GUIScore.transform.position = Camera.main.WorldToViewportPoint(textPos);
    }



    private void Jump(float multiplier)
    {
        audio.Play();
        this.vSpeed = 0;
        this.vSpeed += JUMP_STRENGTH * multiplier;
        this.timeCounter += JUMP_STRENGTH_HORIZONTAL;
        //se sono già in aria e salto ancora, disabilito il salto
        if (this._offset > 0)
            this.canJump = false;
    }

    void OnTriggerEnter2D(Collider2D pickup)
    {
        pickup.gameObject.SendMessage("playSound");

        //pickup.gameObject.SendMessage("getScore",this.currentType);
        if (pickup.gameObject.tag == "PickUp")
        {
            pickup.gameObject.SendMessage("ResetPickUpPosition");
            this.updateScore(pickup.gameObject, true);
        }

    }

    public void updateScore(GameObject pickUp, bool caso)
    {

        if (caso) //prendo l'oggetto
        {
            if (this.currentType == CharacterScript.CharacterType.Chemister)
            {
                if (pickUp.gameObject.name == "Potion")
                {
                    this.score_life += 2;
                    this.score_points += 200;
                    soundGood.audio.Play();
                }
                else
                {
                    this.score_life += -40;
                    soundBad.audio.Play();
                }
            }
            else
            {
                if (pickUp.gameObject.name == "Potion")
                {
                    this.score_life += -40;
                    soundBad.audio.Play();
                }
                else
                {
                    this.score_life += 2;
                    this.score_points += 200;
                    soundGood.audio.Play();
                }
            }
        }
        else  //l'oggetto cade
        {
            if (this.currentType == CharacterScript.CharacterType.Chemister)
            {
                if (pickUp.gameObject.name == "Potion")
                    this.score_life -= 20;
                else
                {   this.score_life += 2;
                    this.score_points += 200;
                }
            }
            else //drunk
            {
                if (pickUp.gameObject.name == "Potion")
                {
                    this.score_life += 2;
                    this.score_points += 200;
                }
                else
                    this.score_life -= 20;
            }

        }
        if (this.score_life > 100)
            this.score_life = 100;
        //else
        //    if (this.score_life <= 0)
        //            //Application.LoadLevel ("gameOver");
    }

}
