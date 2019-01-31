using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

    public Animator cameraAnim;
    public GameObject[] miacvoxMas; public GameObject anjatvoxMas;

    public void startAnim()
    {
        cameraAnim.enabled = true;
        cameraAnim.Play("CameraRotate");
        foreach (GameObject a in miacvoxMas)
        {
            a.SetActive(true);
        }
        anjatvoxMas.SetActive(false);
    }
}
