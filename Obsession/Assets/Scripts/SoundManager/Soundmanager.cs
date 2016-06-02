using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Soundmanager : MonoBehaviour
{
    public static Soundmanager instance = null;

    public AudioSource bgSound; // Music sound 1
    public AudioSource anxietySound; // Music sound 2
    public AudioSource anxietyTerrorSound; // Music sound 3
   
    const float _MAXSOUND2 = 0.5f;
    const float _MAXSOUND3 = 1.0f;

    private float anxietyVolume; //volume della musica di anxiety

    void Awake()
    {
        if (instance != null) { 
            Destroy(gameObject);
        } else {  
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            bgSound.volume = 1.0f;


            anxietySound.volume = 0.0f;
            anxietyTerrorSound.volume = 0.0f;

            bgSound.Play();
            anxietySound.Play();
            anxietyTerrorSound.Play();
        }
       
        

    }

   
    
    public void setPlayerObject()

    {
        // Audio Source responsavel por emitir os sons
        AnxietyVolume = GameObject.Find("Player").GetComponent<StressUpdater>().getAnxiety();
    }

    public float AnxietyVolume
    {
        get
        {
            return anxietyVolume;
        } 
        set
        {
            //max lvl in range for volume

            anxietySound.volume = value;
            

        }
    }

	// Update is called once per frame
	void Update () {
        
		if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Credits" || SceneManager.GetActiveScene().name == "GameOver")
        {
            
        }
        else
        {

        
        float Anxiety = GameObject.Find("Player").GetComponent<StressUpdater>().getAnxiety();

        //set correct volume of every soundbackound

        anxietySound.volume = Anxiety * _MAXSOUND2;
        if (Anxiety <= 0.5f)
            anxietyTerrorSound.volume = 0.0f;
        else
        {
        
            anxietyTerrorSound.volume = (Anxiety-0.5f) / (1.0f - 0.5f) * _MAXSOUND3;
        }
            //Debug.Log(anxietyTerrorSound.volume);

        }
    }
}
