using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CloseMessage : MonoBehaviour {

    // Use this for initialization
    public void closeMessage()
    {
        this.GetComponent<Canvas>().enabled = false;
    }

    public void continueMessage()
    {
        this.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("PreLevel2");
    }

    public void openCredits()
    {
        this.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Credits");
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void openEndLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EndLevel");
    }

    public void play()
    {
        SceneManager.LoadScene("PreLevel");
    }

    public void quit()
    {
        Application.Quit();
    }
}
