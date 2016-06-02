using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {
    GameObject player;
    public Transform startMarker;
    public Transform endMarker;
    private Animator animator;
    public string nextLevel;

    // Use this for initialization
    void Awake () {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();
        animator.SetFloat("Speed", 10f);
        animator.SetBool("Ground", true);

        StartCoroutine(MoveObject(player.transform, startMarker.position, endMarker.position, 6f));


    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevel);
        yield return null;
    }

    public IEnumerator MoveObject(Transform thisTransform, Vector3 start, Vector3 end, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
   
        while (i < 1.0f)
        {
          
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(start, end, i);
            yield return null;
        }
        animator.SetFloat("Speed", 0f);
        StartCoroutine(wait());
    }
}
