using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{
    private GameObject camara;
    public Transform posCamara;
    bool camaraOn = false;
    private GameObject jugador;
    public AudioSource gameMusic;
    public Sprite sprite_jugador;
    public GameObject rotacion;
    private float contador;
    public GameObject jefe;
    private DialogueController dc;
    public AudioSource musicaTension;
    private bool iniciarMusica = false;

    private void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        //jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        contador = 0;
        dc = GameObject.FindGameObjectWithTag("gamecontroller").GetComponent<DialogueController>();
    }

    private void Update()
    {
        if (camaraOn)
        {
            camara.transform.position = Vector3.MoveTowards(camara.transform.position, new Vector3(-1.51f, camara.transform.position.y, camara.transform.position.z), 2f * Time.deltaTime); //Mueve la camara
            jugador.GetComponent<SpriteRenderer>().sprite = sprite_jugador; //Pone el sprite por default
            jugador.GetComponent<CharacterController>().cutscene = true; //Evita que el jugador se mueva
            jugador.GetComponent<Shot>().cutscene = true; //Evita que el jugador dispare
            rotacion.GetComponent<WeaponRotation>().cutscene = true; //Evita la rotacion del arma
            if (camara.transform.position == new Vector3(-1.51f, camara.transform.position.y, camara.transform.position.z))
            {
                timer();
            }
        }

    }

    private void timer()
    {
        contador += Time.deltaTime;
        if (contador >= 2)
        {
            jefe.transform.eulerAngles = new Vector3(0, -180, 0);
            if (!iniciarMusica)
            {
                musicaTension.Play();
                iniciarMusica = true;
            }
        }

        if(contador >= 4)
        {
            dc.activar_dialogo=true;
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
