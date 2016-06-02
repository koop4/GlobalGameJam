using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SafePoint : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D theOther)
    {
        SceneManager.LoadScene("Credits");
    }
}
