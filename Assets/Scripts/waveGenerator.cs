using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waveGenerator : MonoBehaviour
{

    public EnemySpawn em;
    public int wave=1;
    //public bool raundOver;
    public Canvas_controller cv;

    void Start()
    {

    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Return) && raundOver)
        {
            //cv.Main_State(false);
            
        }*/
    }
    public Animator CameraAnim;
    public GameObject EndScene, sputnikParent, shit;
    public void gameOverAnim()
    {
        EndScene.SetActive(true);
        CameraAnim.Play("CameraRotBack");
        em.gameOver = true;
        for (int i = 0; i < sputnikParent.transform.childCount; i++)
        {
            sputnikParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        shit.SetActive(false);
        Invoke("cursorOn", 1);
    }

    void cursorOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void newWave()
    {
        cv.DrawWave(wave);
        //raundOver = false;
        Invoke("ws", 2);
    }
    int count;
    void ws()
    {
        count = (int)Mathf.Pow((float)++wave, 2);
        waveText.text = count.ToString();
        em.waveStart(deltaTime-=deltaTime/10, count);
    }

    public void asteroidDestroy()
    {
        count--;
        waveText.text = count.ToString();
    }

    float deltaTime = 3;
    public Text waveText;

}
