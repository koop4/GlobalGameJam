using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	public GUISkin customSkin = null;

    public enum Mode { Title, Credits };
    public Mode currentMode = Mode.Title;

    public SpriteRenderer texture;
    public Sprite sprite_title, sprite_credits;

    private Rect defaultTexturePos;

    void Start()
    {
        //this.defaultTexturePos = this.texture.pixelInset;
    }


    void Update()
    {
        if (this.currentMode == Mode.Title)
        {
            this.texture.sprite = sprite_title;
        }
        else 
        {
            this.texture.sprite = sprite_credits;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
                this.currentMode = Mode.Title;
        }
    }

	public void OnGUI(){
        if (this.currentMode == Mode.Title)
        {
            //if (customSkin != null)
            //    GUI.skin = customSkin;


            //int buttonWidth = 200;
            //int buttonHeight = 50;
            //int halfButtonWidth = buttonWidth / 2;
            //int halfScreenWidth = Screen.width / 2;

            //if (GUI.Button(new Rect(halfScreenWidth - halfButtonWidth, 540, buttonWidth, buttonHeight), "Play"))
            //{
            //    Application.LoadLevel("Istruction");
            //}
        }
        else
        {
 
        }

	}
}