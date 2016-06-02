using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

    private const float ANXIETY_LIMIT= 1f;
    private const float ANXIETY_FREQUENCY_STANDARD = 2f;

    private GameObject player;
    private List<GameObject> goalsList;
    public float anxietyFrequency= ANXIETY_FREQUENCY_STANDARD;

    void Start()
    {
        StartCoroutine(checkAnxiety());
        StartCoroutine(augmentAnxiety());
    }

    void Awake()
    {
        player = GameObject.Find("Player").gameObject;
        computeGoalsList();

    }


    private IEnumerator checkAnxiety()
    {
        while (true)
        {
            float anxiety = player.GetComponent<StressUpdater>().getAnxiety();
            if (anxiety >= ANXIETY_LIMIT)
                anxiety = ANXIETY_LIMIT;
            Camera.main.transform.gameObject.GetComponent<VignetteAndChromaticAberration>().intensity = anxiety;
            /*float r = UnityEngine.Random.value;
            if (r < anxiety)
                Camera.main.transform.Rotate(0,0,Random.Range(10,35));*/
            yield return new WaitForSeconds(1f);
        }
    }
    private IEnumerator augmentAnxiety()
    {
        while (true)
        {
             player.GetComponent<StressUpdater>().increaseAnxiety (0.01f);
            if (player.GetComponent<StressUpdater>().getAnxiety() >=ANXIETY_LIMIT)
                gameOver();

            yield return new WaitForSeconds(anxietyFrequency);
        }
    }

    
    public void checkEnd()
    {
        Canvas canvasGoalObject;
        bool win=player.GetComponent<Inventory>().hasAllGoalItems(goalsList);
        canvasGoalObject = GameObject.Find("CanvasGoalObject").GetComponent<Canvas>();
        canvasGoalObject.enabled= true;
        if (win)
        {
            Time.timeScale = 0;
            canvasGoalObject.GetComponentInChildren<Text>().text = "You've reached your goal\n";
            GameObject.Find("ContinueButton").GetComponent<Button>().interactable = true; 
            GameObject.Find("Button").GetComponent<Button>().interactable = false;
        }
        else
        {
            canvasGoalObject.GetComponentInChildren<Text>().text = "Some objects are missing\n";
            GameObject.Find("Button").GetComponent<Button>().interactable = true;
            GameObject.Find("ContinueButton").GetComponent<Button>().interactable = false;
        }
        
    }

    void computeGoalsList()
    {
        GameObject goals = GameObject.Find("Goals");
        goalsList = new List<GameObject>();
        int children = goals.transform.childCount;
        for (int i=0; i< children; i++)
        {
            GameObject child = goals.transform.GetChild(i).gameObject;
            if (child.GetComponent<GoalCollisionHandler>()!=null)
                if(!child.GetComponent<GoalCollisionHandler>().isFinalGoal())
                    goalsList.Add(goals.transform.GetChild(i).gameObject);
        }
    }

    void gameOver()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("GameOver");
    }

    public void changeAnxietyFrequency(float theNewFrequency)
    {
        anxietyFrequency = theNewFrequency;
    }

    public void resetAnxietyFrequency()
    {
        anxietyFrequency = ANXIETY_FREQUENCY_STANDARD;
    }

}
