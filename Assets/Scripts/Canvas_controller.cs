using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Canvas_controller : MonoBehaviour
{

    public Animator Asteroids_anim,wave_anim, updateEartBacvoxMas, sputnikBacvoxMas,main_anim;
    Text waves;
    public GameObject money;
    public AudioClip shop_click_Enough_money, shop_click_not_money;
    public AudioSource Shop_Click;

    private void Start()
    {
        Asteroids_anim = transform.Find("Asteroids*").GetComponent<Animator>();
        wave_anim = transform.Find("Waves*").GetComponent<Animator>();
        waves = transform.Find("Waves*").GetChild(0).GetComponent<Text>();
        main_anim = transform.Find("Shop*").GetChild(0).GetComponent<Animator>();
        waves.transform.gameObject.SetActive(false);

        Shop_Click = GameObject.FindGameObjectWithTag("button_click").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            asteroidsState(true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            asteroidsState(false);
        }
    }

    public void asteroidsState(bool isOn)
    {
        if (isOn)
        {
            Asteroids_anim.Play("AsteroidOn_Off");
        }
        else
        {
            Asteroids_anim.Play("Asteroids_Off");
        }
    }

    /*public void Main_State(bool isOn)
    {
        if (isOn)
        {
            main_anim.Play("MoveUp");
        }
        else
        {
            main_anim.Play("Main_Down");
        }
    }*/

    const float wavesAnimTime = 1.25f;

    public void DrawWave(int wave)
    {
        waves.text = "Wave " + wave;
        waves.transform.gameObject.SetActive(true);
        wave_anim.Play("waves_On");
        Invoke("Wave_Off", wavesAnimTime);
    }

    void Wave_Off()
    {
        wave_anim.Play("New State");
        waves.transform.gameObject.SetActive(false);
    }
    bool updateEartIsOn = true;
    public GameObject newWaveButton;
    public void updateEarthBacel()
    {
        if (updateEartIsOn)
        {
            newWaveButton.SetActive(false);
            updateEartIsOn = false;
            updateEartBacvoxMas.Play("Bacvox_Mas_Move");
            asteroidsState(true);
            money.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {            
            updateEartIsOn = true;
            updateEartBacvoxMas.Play("Bacvox_Mas_BAck");
            newWaveButton.SetActive(true);
            asteroidsState(false);
            money.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    /*bool sputnikIsOn;
    public void sputnikBacel()
    {
        if (sputnikIsOn)
        {
            sputnikIsOn = false;
            sputnikBacvoxMas.Play("Bacvox_Mas_Move");
        }
        else
        {
            if (updateEartIsOn)
            {
                updateEartIsOn = false;
                updateEartBacvoxMas.Play("Bacvox_Mas_Move");
            }
            sputnikIsOn = true;
            sputnikBacvoxMas.Play("Bacvox_Mas_BAck");
        }
    }*/
}
