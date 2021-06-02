using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    private GameObject camara;
    public Transform posCamara;
    bool camaraOn = false;
    private CharacterController cc;
    public AudioSource gameMusic;

    private void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (camaraOn)
        {
            camara.transform.position = Vector3.MoveTowards(camara.transform.position, new Vector3(-1.51f, camara.transform.position.y, camara.transform.position.z), 2f * Time.deltaTime);
            cc.cutscene = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camara.GetComponent<CameraController>().gameMusic.Stop();
            //gameMusic.Stop;
            camara.GetComponent<CameraController>().enabled = false;
            //camara.transform.position = new Vector3(-1.51f, camara.transform.position.y, camara.transform.position.z); //Vector3.MoveTowards(camara.transform.position, new Vector3(-1.5f, camara.transform.position.y, camara.transform.position.z), 2f*Time.deltaTime);
            camaraOn = true;
        }
    }
}
