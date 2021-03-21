using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera camara;
    public float zoom;
    private bool flag_tutorial;
    private GameObject jugador;

    private bool bool_paredIzqui;
    private bool bool_paredDere;
    private bool bool_salto;
    private bool bool_disparo;
    private bool primera_vez;

    GameObject paredIzqui;
    GameObject paredDere;
    // Start is called before the first frame update
    void Start()
    {      
        camara = Camera.main;
        flag_tutorial = true;
        jugador = GameObject.FindGameObjectWithTag("Player");
        paredIzqui = new GameObject("ParedIzqui");
        paredDere = new GameObject("ParedDere");
        paredIzqui.AddComponent<BoxCollider2D>();
        paredDere.AddComponent<BoxCollider2D>();
        paredIzqui.GetComponent<BoxCollider2D>().isTrigger = true;
        paredDere.GetComponent<BoxCollider2D>().isTrigger = true;
        bool_paredIzqui = false;
        bool_paredDere = false;
        bool_salto = false;
        bool_disparo = false;
        primera_vez = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (flag_tutorial) tutorial();
        else seguirJugador();

        //camara.fieldOfView = Mathf.Lerp(camara.fieldOfView, zoom, Time.deltaTime);
        
    }

    void tutorial()
    {
        /*****************************El jugador no puede salir de la camara***********************************/
        camara.orthographicSize = zoom; //Ajustar el zoom
        camara.transform.position = new Vector3(0, 0.5f, -10);
        paredIzqui.transform.position = new Vector3(camara.transform.position.x - zoom - 1.8f, jugador.transform.position.y,-10f);
        paredDere.transform.position = new Vector3(camara.transform.position.x + zoom + 1.8f, jugador.transform.position.y, -10f);

        if (jugador.transform.position.x < camara.transform.position.x - zoom-1.8f)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x - zoom - 1.8f, jugador.transform.position.y);
        }

        if (jugador.transform.position.x > camara.transform.position.x + zoom+ 1.8f)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x + zoom + 1.8f, jugador.transform.position.y);
        }
        /**********************************************************************************/

        /*****************************Comprobar colisiones con gameobjects***********************************/
        if ((paredIzqui.GetComponent<BoxCollider2D>().IsTouching(jugador.GetComponent<CircleCollider2D>())) && bool_paredIzqui==false)
        {
            if (primera_vez==false) {
                Debug.Log("Muevete derecha");
                bool_paredIzqui = true;
                
            } else
            {
                primera_vez = false;
            }
        }

        if ((paredDere.GetComponent<BoxCollider2D>().IsTouching(jugador.GetComponent<CircleCollider2D>())) && (bool_paredIzqui) && (bool_paredDere==false))
        {
            Debug.Log("Salta");
            bool_paredDere = true;

        }

        if (bool_paredDere && ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.Space))))
        {
            Debug.Log("Dispara");
            bool_salto = true;

        }

        if (bool_salto)
        {
            Debug.Log("Hola");
            //bool_salto = true;
        }
        /**********************************************************************************/
    }

    void seguirJugador()
    {
        if (jugador != null)
        {
            camara.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
    }
}
