using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera camara;
    public float zoom;
    private bool flag_tutorial;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
        camara = Camera.main;
        flag_tutorial = true;
        jugador = GameObject.FindGameObjectWithTag("Player");

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
        camara.orthographicSize = zoom; //Ajustar el zoom
        camara.transform.position = new Vector3(0, 0, -10);
        
        if(jugador.transform.position.x < camara.transform.position.x - zoom-2)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x - zoom - 2, jugador.transform.position.y);
        }

        if (jugador.transform.position.x > camara.transform.position.x + zoom+2)
        {
            jugador.transform.position = new Vector2(camara.transform.position.x + zoom + 2, jugador.transform.position.y);
        }


    }

    void seguirJugador()
    {

        if (jugador != null)
        {
            camara.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10);
        }
    }
}
