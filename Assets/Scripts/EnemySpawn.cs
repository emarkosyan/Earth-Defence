using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{

    public Camera cam;//= camera
    public Transform earth;//= pleyer
    float CamX
    {
        get
        {
            return cam.transform.position.x;
        }
    }

    float CamY
    {
        get
        {
            return cam.transform.position.y;
        }
    }

    float CamZ
    {
        get
        {
            return cam.transform.position.z;
        }
    }

    float SensorX
    {
        get
        {
            return cam.sensorSize.x;
        }
    }

    float SensorY
    {
        get
        {
            return cam.sensorSize.y;
        }
    }

    public float EarthX
    {
        get
        {
            return earth.transform.position.x;
        }
    }

    public float EarthY
    {
        get
        {
            return earth.transform.position.y;
        }
    }

    float EarthZ
    {
        get
        {
            return earth.transform.position.z;
        }
    }

    // Asteroid position
    //float Z => EarthZ;
    /*  float MaxX => CamX + ((CamX - EarthZ) / cam.focalLength) * (CamX + SensorX) / 2;
      float MinX => CamX - ((CamX - EarthZ) / cam.focalLength) * (CamX + SensorX) / 2;
      float MinY => CamY - ((CamZ - EarthZ) / cam.focalLength) * ((Screen.height / Screen.width) * SensorX / 2);
      float MaxY => CamY + ((CamZ - EarthZ) / cam.focalLength) * ((Screen.height / Screen.width) * SensorX / 2);
      */



    public float DeltaX { get { return (EarthZ - CamZ) * SensorX / (2 * cam.focalLength); } }
    public float DeltaY { get { return (EarthZ - CamZ) * Screen.height * SensorX / (2 * cam.focalLength * Screen.width); } }



    float MaxX
    {
        get
        {
            return CamX + DeltaX;
        }
    }

    float MinX
    {
        get
        {
            return CamX - DeltaX;
        }
    }

    float MinY
    {
        get
        {
            return CamY - DeltaY;
        }
    }

    float MaxY
    {
        get
        {
            return CamY + DeltaY;
        }
    }

    int count;
    public void waveStart(float time, int count_S)
    {
        count = count_S;
        InvokeRepeating("NewAsteroid", 0, time);
    }
    public waveGenerator wg;
    void waveEnd()
    {
        CancelInvoke("NewAsteroid");
        Invoke("waveOver", 5);
    }
    public moneySystem ms;
    void waveOver()
    {
        //wg.raundOver = true;
        wg.cv.updateEarthBacel();
        ms.giveMoney(wg.wave);
    }

    void NewAsteroid()
    {
        if (gameOver) return;

        float alpha = Random.Range(0f, 2 * Mathf.PI);
        float deltaX = Mathf.Cos(alpha) > 0 ?
            DeltaY * Mathf.Tan(alpha) :
            -DeltaY * Mathf.Tan(alpha);
        float deltaY;

        float x;//= EarthX + deltaX;
        float y;
        float z = EarthZ;

        if (Mathf.Abs(deltaX) < DeltaX)
        {
            x = CamX + deltaX;
            y = Mathf.Cos(alpha) > 0 ? MaxY : MinY;
            deltaY = -9999;
        }
        else
        {
            x = Mathf.Sin(alpha) > 0 ? MaxX : MinX;
            deltaY = Mathf.Sin(alpha) > 0 ?
                 DeltaX * Mathf.Tan((Mathf.PI / 2) - alpha) :
                -DeltaX * Mathf.Tan((Mathf.PI / 2) - alpha);
            y = CamY + deltaY;
        }

        //todo:Generate new asteroid in (x;y;z)
        GameObject[] enemyes = GameObject.FindGameObjectsWithTag("enemy");

        Vector3 newVector = new Vector3(x, y, z);

        foreach (GameObject e in enemyes)
        {
            if ((e.transform.position - newVector).magnitude < 2)
            {
                NewAsteroid();
                return;
            }
        }

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = newVector;
        //Debug.Log("alpha="+alpha+"; deltaX=" + deltaX + "; deltaY=" + deltaY + "; DeltaX=" + DeltaX + "; DeltaY=" + DeltaY + "; x=" + x + "; y =" + y);
        if (--count == 0)
        {
            waveEnd();         
        }
        //waveText.text = count.ToString();
    }
    public bool gameOver;
    public GameObject enemy;
}