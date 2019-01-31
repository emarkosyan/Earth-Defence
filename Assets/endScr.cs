using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScr : MonoBehaviour {

    public void quitApp()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public GameObject anjtel,miacnel;
    public void about_miacnel()
    {
        anjtel.SetActive(false);
        miacnel.SetActive(true);
    }
    public void about_anjtel()
    {
        anjtel.SetActive(true);
        miacnel.SetActive(false);
    }
}
