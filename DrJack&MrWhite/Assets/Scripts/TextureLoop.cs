using UnityEngine;
using System.Collections;

public class TextureLoop : MonoBehaviour {

    private const float DEFAULT_SWAP_TIME = 5.0f;
    private const float CHARACTER_SWAP_DELAY = 0.6f;

    public enum BackgroundMode { Day, Night };
    public BackgroundMode currentMode;

    private float speed = 0.60f;
    private BackgroundMode lastMode;


    public CharacterScript player;
    private float targetOffset;

    //timer
    private float timer,swapTime = DEFAULT_SWAP_TIME;
    private float timer_characterSwap;

    //flags
    private bool swappingCharacter;

    //sfondo del mondo
    public SpriteRenderer bk_day, bk_night;

	// Use this for initialization
	void Start ()
    {
        this.targetOffset = -0.25f;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //timer
        this.timer += Time.deltaTime;
        if (this.timer >= this.swapTime && player.signal_onVerticalAxis)
        {
            this.timer = 0;
            //swappo
            if (this.currentMode == BackgroundMode.Day)
            {
                this.currentMode = BackgroundMode.Night;
                this.bk_night.gameObject.SetActive(true);
                //this.bk_day.gameObject.SetActive(false);
                //this.bk_night.color= new Color(this.bk_night.color.r, this.bk_night.color.g, this.bk_night.color.b, 0);
			}
            else
            {
                this.currentMode = BackgroundMode.Day;
                this.bk_day.gameObject.SetActive(true);
                //this.bk_night.gameObject.SetActive(false);
                //this.bk_day.color = new Color(this.bk_day.color.r, this.bk_day.color.g, this.bk_day.color.b, 0);


			}
			audio.Play ();
			this.swappingCharacter = true;
        }

        if (this.swappingCharacter)
        {
            this.timer_characterSwap += Time.deltaTime;


            float alphaIn =  Mathf.Clamp(this.timer_characterSwap / (float)CHARACTER_SWAP_DELAY, 0.3f, 1);
            float alphaOut = Mathf.Clamp(this.timer_characterSwap / (float)CHARACTER_SWAP_DELAY, 0.0f, 1);
            if (this.currentMode == BackgroundMode.Day)
            {

                this.bk_day.color = new Color(this.bk_day.color.r, this.bk_day.color.g, this.bk_day.color.b, alphaIn);
                this.bk_night.color = new Color(this.bk_night.color.r, this.bk_night.color.g, this.bk_night.color.b, 1.0f - alphaOut);
                if (alphaOut >= 1)
                {
                    this.bk_night.gameObject.SetActive(false);
                }
            }
            else
            {
                this.bk_day.color = new Color(this.bk_day.color.r, this.bk_day.color.g, this.bk_day.color.b, 1.0f - alphaOut);
                this.bk_night.color = new Color(this.bk_night.color.r, this.bk_night.color.g, this.bk_night.color.b, alphaIn);
                if (alphaOut >= 1)
                {
                    this.bk_day.gameObject.SetActive(false);

                }
            }

            if (this.timer_characterSwap >= CHARACTER_SWAP_DELAY)
            {
                this.swappingCharacter = false;
                this.timer_characterSwap = 0;
                if (this.currentMode == BackgroundMode.Night)
                {
                    this.player.currentType = CharacterScript.CharacterType.Drunk;
                }
                else
                {
                    this.player.currentType = CharacterScript.CharacterType.Chemister;
                }

            }

            
        }


        //this.renderer.material.mainTextureOffset= new Vector2(this.renderer.material.mainTextureOffset.x+ this.speed * Time.deltaTime,0);
        if (this.currentMode != lastMode)
        {
            if (this.currentMode == BackgroundMode.Day)
                this.targetOffset = -0.25f;
            else
                this.targetOffset = +0.25f;
        }

            if(this.renderer.material.mainTextureOffset.x< this.targetOffset)
            {
                this.renderer.material.mainTextureOffset= new Vector2(this.renderer.material.mainTextureOffset.x+ this.speed * Time.deltaTime,0);
                if(this.renderer.material.mainTextureOffset.x >= this.targetOffset)
                    this.renderer.material.mainTextureOffset= new Vector2(this.targetOffset,0);
            }
            else if(this.renderer.material.mainTextureOffset.x> this.targetOffset)
            {
                this.renderer.material.mainTextureOffset= new Vector2(this.renderer.material.mainTextureOffset.x- this.speed * Time.deltaTime,0);
                if(this.renderer.material.mainTextureOffset.x <= this.targetOffset)
                    this.renderer.material.mainTextureOffset= new Vector2(this.targetOffset,0);
            }

        this.lastMode = this.currentMode;
	}
}
