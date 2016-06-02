using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class RitualObjectTrigger : MonoBehaviour {

    private GameObject player;
    private IEnumerator removeAnxietyCoroutine;
    /*private bool firstTime=false;

    void OnTriggerStay2D(Collider2D theOther)
    { 
        player = theOther.transform.gameObject;
       
        if (pressingDown()&&!firstTime)
        {
            StartCoroutine(preparingRitual());
        }
    }
    void PlayDestroySound()
    {
        gameObject.GetComponent<AudioSource>().Play();

    }

    private bool pressingDown()
    {
        return Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }

    private IEnumerator preparingRitual()
    {
        firstTime = true;
        float startTime, actualTime, duration, time;
        bool ritualStarted = false;
        time = 1f;
        startTime = Time.time;
        while (pressingDown())
        {
            actualTime = Time.time;
            duration = actualTime - startTime;
            if (duration >= 2f && !ritualStarted)
            {
                startRitual();
                ritualStarted = true;
            }
            yield return new WaitForSeconds(time);
        }
        yield return null;
    }

    private void startRitual()
    {
        this.transform.gameObject.SetActive(false);
        player.GetComponent<StressUpdater>().decreaseAnxiety(0.5f);
        firstTime = false;
    }*/

    void OnTriggerEnter2D(Collider2D theOther)
    {
        player = theOther.transform.gameObject;
        player.gameObject.GetComponent<PlatformerCharacter2D>().triggerRitual();
        removeAnxietyCoroutine = removeAnxiety();
        StartCoroutine(removeAnxietyCoroutine);
    }

    private IEnumerator removeAnxiety()
    {
        while (player.GetComponent<StressUpdater>().getAnxiety() > 0)
        {
            player.GetComponent<StressUpdater>().decreaseAnxiety(0.1f);
            yield return new WaitForSeconds(0.5f);
        }
            
    }
    void OnTriggerExit2D(Collider2D theOther)
    {
        StopCoroutine(removeAnxietyCoroutine);
        //player = null;
    }

}
