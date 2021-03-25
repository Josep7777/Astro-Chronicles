using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;

    public bool estaensuelo = false;
    public bool rebotar = false;
    public bool rebotari = false;

    private bool flag_salto;
    private int flag_rebote_izqui;
    private int flag_rebote_dere;
    private bool flag_tiempo;
    private float tiempo_aux;
    void Start()
    {
        flag_salto = false;
        flag_rebote_dere = 0;
        flag_rebote_izqui = 0;
        flag_tiempo = false;
    }

    // Update is called once per frame
    void Update()
    {
        Saltar();
        Rebotar();
        Rebotari();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * velocidad;

        /*
        if (flag_rebote_dere == 2 || flag_rebote_izqui == 2)
        {
            if (flag_tiempo == false) { 
                tiempo_aux = Time.deltaTime;
                flag_tiempo = true;
            }
            
            if (Time.deltaTime > tiempo_aux + 0.4f) {
                flag_rebote_dere = 0;
                flag_rebote_izqui = 0;
            }
        } else
        {
            flag_tiempo = false;
        }*/
    }

    void Saltar()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) &&  estaensuelo == true) 
        {
            if (flag_salto == false)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7.0f), ForceMode2D.Impulse);

                /*
                if (this.transform.position.y > 7.0f)
                {
                    this.transform.position = new Vector2(this.transform.position.x, 7.0f);
                }*/

                flag_salto = true;
                Debug.Log("Salto");
            }
            //Debug.Log("Entra");
        } else
        {
            flag_salto = false;
        }

    }

    void Rebotar()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && rebotar == true)
        {
            if (flag_rebote_dere==0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.0f, 4.0f), ForceMode2D.Impulse);
                flag_rebote_dere = 1;
                Debug.Log("Dere");
            }
            
            //rebotari= true;
        } else
        {
            flag_rebote_dere = 0;
        }

       
    }


    void Rebotari()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && rebotari == true)
        {
            if (flag_rebote_izqui==0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f, 4.0f), ForceMode2D.Impulse);
                flag_rebote_izqui = 1;
                Debug.Log("Izqui");
            }
            
        } else
        {
            flag_rebote_izqui = 0;
        }
    }
}
