using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    private Camera camara;
    public float zoomTuto;
    public float zoomJuego;
    public GameObject a;
    public GameObject d;
    public GameObject w;
    public GameObject puntero;
    public GameObject raton;
    public GameObject respawn;

    private GameObject jugador;

    private bool flag_tutorial;
    //private bool flag_puntero;
    private bool bool_paredIzqui;
    private bool bool_paredDere;
    private bool bool_salto;
    //private bool bool_disparo;
    private bool primera_vez;
    private bool flag_aux = false;

    GameObject paredIzqui;
    GameObject paredDere;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Nivel1") {
            flag_tutorial = true;
            //flag_puntero = false;

            a.gameObject.SetActive(true);
            d.gameObject.SetActive(false);
            w.gameObject.SetActive(false);
            puntero.gameObject.SetActive(false);
            raton.gameObject.SetActive(false);



            paredIzqui = new GameObject("ParedIzqui");
            paredDere = new GameObject("ParedDere");
            paredIzqui.AddComponent<BoxCollider2D>();
            paredDere.AddComponent<BoxCollider2D>();
            paredIzqui.GetComponent<BoxCollider2D>().isTrigger = true;
            paredDere.GetComponent<BoxCollider2D>().isTrigger = true;

            bool_paredIzqui = false;
            bool_paredDere = false;
            bool_salto = false;
            //bool_disparo = false;
            primera_vez = true;


            a.transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y * 1.5f);
            d.transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y * 1.5f);
            w.transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y * 1.5f);
            puntero.transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y * 1.7f);
            raton.transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y * 1.3f);
    }
        camara = Camera.main;

        jugador = GameObject.FindGameObjectWithTag("Player");

        camara.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y * 2, -10);

    }

    // Update is called once per frame
    void Update()
    {
        if (flag_tutorial && VariablesController.Muerto == false && SceneManager.GetActiveScene().name == "Nivel1") tutorial();
        else
        {
            if (flag_aux == false && SceneManager.GetActiveScene().name == "Nivel1") {
                jugador.transform.position = respawn.transform.position;
                flag_aux = true;
            }
            seguirJugador();
        }

        //camara.fieldOfView = Mathf.Lerp(camara.fieldOfView, zoom, Time.deltaTime);
        
    }

    void tutorial()
    {
        /*****************************El jugador no puede salir de la camara***********************************/
        camara.orthographicSize = zoomTuto; //Ajustar el zoom
                                            //camara.transform.position = new Vector3(0, 0.5f, -10);

        //paredIzqui.transform.position = new Vector3(camara.transform.position.x - zoomTuto - 1.8f, jugador.transform.position.y,-10f);
        paredIzqui.transform.position = new Vector2(camara.transform.position.x - zoomTuto/0.6f, jugador.transform.position.y);
        //paredDere.transform.position = new Vector3(camara.transform.position.x + zoomTuto + 1.8f, jugador.transform.position.y, -10f);
        paredDere.transform.position = new Vector2(camara.transform.position.x + zoomTuto/0.6f, jugador.transform.position.y);

        if (jugador.transform.position.x < camara.transform.position.x - zoomTuto / 0.6f)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x - zoomTuto / 0.6f, jugador.transform.position.y);
        }

        if (jugador.transform.position.x > camara.transform.position.x + zoomTuto / 0.6f)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x + zoomTuto / 0.6f, jugador.transform.position.y);
        }
        /**********************************************************************************/

        /*****************************Comprobar colisiones con gameobjects***********************************/
        if ((paredIzqui.GetComponent<BoxCollider2D>().IsTouching(jugador.GetComponent<CapsuleCollider2D>())) && bool_paredIzqui==false)
        {
            if (primera_vez==false) { //Usado para evitar un bug al iniciar
                //Debug.Log("Muevete derecha");
                a.gameObject.SetActive(false);
                d.gameObject.SetActive(true);

                bool_paredIzqui = true;
                
            } else
            {
                primera_vez = false;
            }
        }

        if ((paredDere.GetComponent<BoxCollider2D>().IsTouching(jugador.GetComponent<CapsuleCollider2D>())) && (bool_paredIzqui) && (bool_paredDere==false))
        {
            //Debug.Log("Salta");
            d.gameObject.SetActive(false);
            w.gameObject.SetActive(true);
            bool_paredDere = true;

        }

        if (bool_paredDere && ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.Space))))
        {
            //Debug.Log("Dispara");
            bool_salto = true;

        }

        if (bool_salto)
        {
            //Debug.Log("Hola");
            w.gameObject.SetActive(false);
            puntero.gameObject.SetActive(true);
            raton.gameObject.SetActive(true);
            puntero.gameObject.transform.position = new Vector2(Mathf.Lerp(camara.transform.position.x-2.5f, camara.transform.position.x +2.5f, Mathf.PingPong(Time.time*0.7f, 1)), puntero.gameObject.transform.position.y);
            if (Input.GetMouseButtonDown(0))
            {
                puntero.gameObject.SetActive(false);
                raton.gameObject.SetActive(false);
                //jugador.transform.position = respawn.transform.position;
                flag_tutorial = false;
            }
        }
        /**********************************************************************************/
    }

    void seguirJugador()
    {
        if (jugador != null)
        {
            camara.orthographicSize = Mathf.Lerp(camara.orthographicSize, zoomJuego, Time.deltaTime);
            camara.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10);
        }
    }

}
