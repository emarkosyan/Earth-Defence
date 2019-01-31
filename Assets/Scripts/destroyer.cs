using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    private void Start()
    {
        Invoke("des", 3);
    }

    void des()
    {
        Destroy(gameObject);
    }
}
