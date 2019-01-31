using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitTransform : MonoBehaviour
{
    const float speed = 300;

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxisRaw("Mouse X");
        float rotate = mouseX * Time.deltaTime * speed;
        transform.Rotate(0, 0, -rotate);

    }
}
