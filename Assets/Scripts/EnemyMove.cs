using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    moneySystem ms;
    destroyer ds;
    Transform earth;
    Vector3 normalVector;
    EnemySpawn es;
    public float speed = 100;
    bool isRun = false;
    GameObject partical;
    waveGenerator wg;
    // Use this for initialization
    void Start ()
    {
        earth = GameObject.FindGameObjectWithTag("earth").transform;
        normalVector = (earth.position - transform.position).normalized;
        transform.LookAt(earth);
        transform.GetChild(0).rotation = Quaternion.Euler(0,0, -transform.rotation.z);
        ms = GameObject.FindGameObjectWithTag("canvas_obj").GetComponent<moneySystem>();
        ds = GameObject.FindGameObjectWithTag("canvas_obj").GetComponent<destroyer>();
        wg = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<waveGenerator>();
        es = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EnemySpawn>();
        partical = transform.Find("part*").gameObject;

        Invoke("Run",2);

	}
	void Run()
    {
        Destroy(transform.GetChild(0).gameObject);
        GetComponent<MeshRenderer>().enabled = true;
        isRun = true;
    }
	// Update is called once per frame
	void Update ()
    {
        if (isRun)
        {
            transform.position += normalVector * speed * Time.deltaTime;
        }
        if (es.gameOver)
        {
            Destroy(gameObject);
        }

	}
   
    private void OnCollisionEnter(Collision collision)
    {
        //todo: partical and destroy
        Destroy(gameObject);
        partical.SetActive(true);
        partical.transform.SetParent(null);
        wg.asteroidDestroy();
        switch (collision.collider.name)
        {
            case "Earth":
                //todo: game over
                collision.transform.GetChild(0).gameObject.SetActive(true);
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                wg.gameOverAnim();
                break;
            case "spColider":
                //todo: destroy sputnik
                ms.DestroySputnik();
                Destroy(collision.transform.parent.parent.gameObject);
                break;
        }

    }
}
