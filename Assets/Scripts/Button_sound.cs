using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Button_sound : MonoBehaviour {

    public AudioSource audio;
    public AudioClip higliting_fx;
    public AudioClip click_fx;

    public void higliting()
    {
        audio.PlayOneShot(higliting_fx);
    }
    public void click()
    {
        audio.PlayOneShot(click_fx);
    }
}
