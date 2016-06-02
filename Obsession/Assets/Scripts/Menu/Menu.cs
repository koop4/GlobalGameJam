using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    
    public class Menu : MonoBehaviour {

		public float XStartLogo;
		public float YStartLogo;
		public float XDSLogo;
		public float YDSLogo;

        public float XStartButton;
        public float YStartButton;
        public float XDSButton;
        public float YDSButton;


        public float XStartCredits;
        public float YStartCredits;
        public float XDCredits;
        public float YDCredits;

        public float XStartQuit;
        public float YStartQuit;
        public float XDQuit;
        public float YDQuit;

		public Texture Logo;
        public Texture StartB;
        public Texture Credits;
        public Texture Quit;

        
        // Use this for initialization
        void Start () {
			XStartLogo = 3f;
			YStartLogo = 10f;
			XDSLogo = 3f;
			YDSLogo = 4f;
			XStartButton = 10f;
            YStartButton = 6f;
            XDSButton = 3f;
            YDSButton = 8f;
			XStartCredits = 10f;
			YStartCredits = 3f;
            XDCredits = 3f;
            YDCredits = 9f;
			XStartQuit = 10f;
			YStartQuit = 2f;
            XDQuit = 3f;
            YDQuit = 8f;
        }
	
        // Update is called once per frame
        void OnGUI() {
            float W = Screen.width;
            float H = Screen.height;
			//GUI.DrawTexture(new Rect(W/XStartLogo,H/YStartLogo,W/XDSLogo,H/YDSLogo),Logo, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(W/XStartButton,H/YStartButton,W/XDSButton,H/YDSButton),StartB, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(W/XStartCredits,H/YStartCredits,W/XDCredits,H/YDCredits),Credits, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect (W/XStartQuit,H/YStartQuit,W/XDQuit,H/YDQuit),Quit, ScaleMode.StretchToFill);
            GUI.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
            if(GUI.Button(new Rect(W/XStartButton,H/YStartButton,W/XDSButton,H/YDSButton),"Start")){
                SceneManager.LoadScene("PreLevel");

            }
            if(GUI.Button(new Rect(W/XStartCredits,H/YStartCredits,W/XDCredits,H/YDCredits),"Credits")){
                SceneManager.LoadScene("Credits");

            }
            if (GUI.Button (new Rect (W/XStartQuit,H/YStartQuit,W/XDQuit,H/YDQuit), "Quit")) {

                Debug.Log ("Che ne dici se usciamo?");
                Application.Quit();
            }
            if(Input.GetMouseButtonDown(0))
                Debug.Log("Pressed left click.");

        }
        
    }
    
}
