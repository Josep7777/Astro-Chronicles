using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float velocidad_powerup;
    public bool estaensuelo = false;
    public bool rebotar = false;
    public bool rebotari = false;
    CoinController coincontroller;
    void Start()
    {
         coincontroller = this.GetComponent<CoinController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if(Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0);
          }
          if (Input.GetKey(KeyCode.UpArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
          }
        */
        Saltar();
        Rebotar();
        Rebotari();
             
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        if (coincontroller.flag_pu_velocidad)
        {
            //Debug.Log("Hola");
            transform.position += movement * Time.deltaTime * velocidad_powerup;
        } else
        transform.position += movement * Time.deltaTime * velocidad;
    }

    void Saltar()
    {
        if (Input.GetKey(KeyCode.UpArrow) &&  estaensuelo == true) 
        {
            if (coincontroller.flag_pu_salto)
            {
                //Debug.Log("Salta mas");
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);
                coincontroller.flag_pu_salto = false;
            } else
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1.5f), ForceMode2D.Impulse);      
        }

    }

    void Rebotar()
    {

        if (Input.GetKey(KeyCode.Space) && rebotar == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.25f, 0.25f), ForceMode2D.Impulse);
            //rebotari= true;
        }

       
    }


    void Rebotari()
    {

        if (Input.GetKey(KeyCode.Space) && rebotari == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.25f, 0.25f), ForceMode2D.Impulse);
        }
    }
}
