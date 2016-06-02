using UnityEngine;
using System.Collections;

public class ObstaclePeople : MonoBehaviour {


    private GameObject player;
    private IEnumerator increaseAnxietyCoroutine;
   
    void OnTriggerEnter2D(Collider2D theOther)
    {
        player = theOther.transform.gameObject;
        increaseAnxietyCoroutine = increaseAnxiety();
        StartCoroutine(increaseAnxietyCoroutine);
    }

    private IEnumerator increaseAnxiety()
    {
        while (player.GetComponent<StressUpdater>().getAnxiety() > 0)
        {
            player.GetComponent<StressUpdater>().increaseAnxiety(0.01f);
            yield return new WaitForSeconds(0.5f);
        }

    }
    void OnTriggerExit2D(Collider2D theOther)
    {
        StopCoroutine(increaseAnxietyCoroutine);
        //player = null;
    }
}
