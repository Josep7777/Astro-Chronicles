using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float velocidad_baja;
    public float velocidad_powerup;
    public bool estaensuelo = false;
    public bool rebotar = false;
    public bool rebotari = false;
    public float salto=7.0f;
    public float salto_powerup=9.0f;
    public float salto_rebote = 4.0f;
    public Animator animator;
    private PlayerCollisionsController pcc;
    private float tiempo_rebote = 0f;
    private bool flag_rebote_vel = false;
    private float horizontalmove = 0;
    private bool flag_salto;
    private int flag_rebote_izqui;
    private int flag_rebote_dere;
    //private bool flag_tiempo;
    //private float tiempo_aux;

    private bool patata= false;
    void Start()
    {
        pcc = this.GetComponent<PlayerCollisionsController>();
        flag_salto = false;
        flag_rebote_dere = 0;
        flag_rebote_izqui = 0;
        //flag_tiempo = false;
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01) //Comprueba si el jugador no tiene una fuerza aplicada (esta saltando ya)
        {
            flag_salto = false;
        } else
        {
            flag_salto = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tiempo_rebote -= Time.deltaTime;

        if (flag_rebote_izqui==1 && estaensuelo) flag_rebote_izqui = 0;
        if (flag_rebote_dere == 1 && estaensuelo) flag_rebote_dere = 0;

        Rebotar();
        Rebotari();
        Saltar();

        if (tiempo_rebote > 0)
        {
            flag_rebote_vel = true;
            velocidad_baja = velocidad - 3f;
        }

        if (tiempo_rebote<=0)
        {
            if (flag_rebote_vel)
            {
                //flag_rebote_vel = false;
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                transform.position += movement * Time.deltaTime * velocidad_baja;
                velocidad_baja += Time.deltaTime + 0.05f;

               
                    //transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);

                    if (velocidad_baja>=velocidad)
                {
                    flag_rebote_vel = false;
                }


            }
            else
            {
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                horizontalmove = Input.GetAxis("Horizontal") * velocidad;

                animator.SetFloat("velocidad", Mathf.Abs(horizontalmove));

                if ((Input.GetKey(KeyCode.D)))
                {
                    animator.SetBool("Derecha", true);
                }
                else
                {
                    animator.SetBool("Derecha", false);
                }

                if ((Input.GetKey(KeyCode.A)))
                {
                    animator.SetBool("izquierda", true);
                }
                else
                {
                    animator.SetBool("izquierda", false);
                }


                if (pcc.flag_pu_velocidad)
                {
                    transform.position += movement * Time.deltaTime * velocidad_powerup;
                }
                else
                    transform.position += movement * Time.deltaTime * velocidad;
            }
        }
    }

    void Saltar()
    {


        if (estaensuelo==true)
        {
            animator.SetBool("Saltando", false);

        }
        else
        {
            if (patata == false) { 
            animator.SetBool("Saltando", true);
               // patata = true;
            }
        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W)) &&  estaensuelo == true) 

        {
            if (flag_salto == false)

            {
             
                if (pcc.flag_pu_salto)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto_powerup), ForceMode2D.Impulse);
                    pcc.flag_pu_salto = false;
                  //  animator.SetBool("Saltando", true);

                } else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
                   // animator.SetBool("Saltando", true);
                }

                flag_salto = true;
                //Debug.Log("Salto");
            //    animator.SetBool("Saltando", false);
            }
            //Debug.Log("Entra");
        } else
        {
            flag_salto = false;
            //animator.SetBool("Saltando", false);

        }


    }

    
   

    void Rebotar()
    {
        if (rebotar && estaensuelo == false)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && rebotar == true)
            {
                if (flag_rebote_dere == 0)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.0f, salto_rebote), ForceMode2D.Impulse);
                    flag_rebote_dere = 1;
                    tiempo_rebote = 0.4f;
                    //Debug.Log("Dere");
                }

                //rebotari= true;
            }
        }
    }


    void Rebotari()
    {
        if (rebotari && estaensuelo == false)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && rebotari == true)
            {
                if (flag_rebote_izqui == 0)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f, salto_rebote), ForceMode2D.Impulse);
                    flag_rebote_izqui = 1;
                    tiempo_rebote = 0.4f;
                    //Debug.Log("Izqui");
                }

            }
        }
    }
}