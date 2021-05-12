using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{

    //public Vector3 axis;
    //public float angle;
    public GameObject jugador;
    /*public GameObject suelo;
    public GameObject paredDere;
    public GameObject paredIzqui;*/

    //private Transform centre;
    //private Vector3 desiredPos;

    void Start()
    {
        //centre = jugador.transform;
        //transform.position = (transform.position - centre.position).normalized * 1 + centre.position;
    }

    private void Update()
    {       
        Vector3 posicion_raton = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        posicion_raton.Normalize();
        float angulo = Mathf.Atan2(posicion_raton.y, posicion_raton.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        //transform.RotateAround(jugador.transform.position, new Vector3(0f, 0f, 1f), angle);
        
        if (angulo < -90 || angulo > 90)
        {

            if (jugador.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -angulo);




            }
            else if (jugador.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -angulo);


            }

        }
    }

}
