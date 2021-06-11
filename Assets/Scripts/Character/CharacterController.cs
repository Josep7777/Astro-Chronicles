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
    public float salto=6.5f;
    public float saltoJet;
    public float saltoJetSuelo;
    //public float salto=7.0f;
    public float salto_powerup=9.0f;
    public float salto_rebote = 5.0f;
    public Animator animator;
    private PlayerCollisionsController pcc;
    private float tiempo_rebote = 0f;
    private bool flag_rebote_vel = false;
    private float horizontalmove = 0;
    public float playerMaxFuel;
    public float playerFuel;
    public PlayerFuelBar fBar;
    public GameObject particulasJet;

    private bool flag_salto;
    private int flag_rebote_izqui;
    private int flag_rebote_dere;
    public bool flying;
    private bool sinFuel;
    public bool cutscene = false;
    //private bool flag_tiempo;
    //private float tiempo_aux;
    public AudioSource jumpSoundEffect;
    public AudioSource superJumpSoundEffect;

    private bool inmortal;
    public PlayerHealth ph;
    public PlayerHealthbar healthBar;
    private bool patata= false;
    void Start()
    {
        pcc = this.GetComponent<PlayerCollisionsController>();
        ph = this.GetComponent<PlayerHealth>();
        flag_salto = false;
        flag_rebote_dere = 0;
        flag_rebote_izqui = 0;
        playerFuel = playerMaxFuel;
        inmortal = false;
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
        if (cutscene == false)
        {
            tiempo_rebote -= Time.deltaTime;

            if (flag_rebote_izqui == 1 && estaensuelo) flag_rebote_izqui = 0;
            if (flag_rebote_dere == 1 && estaensuelo) flag_rebote_dere = 0;

        Rebotar();
        Rebotari();
        Saltar();
        JetPack();
            ModoInmortal();
            Rebotar();
            Rebotari();
            Saltar();

            if (estaensuelo)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1F;
            }

            if (tiempo_rebote > 0)
            {
                flag_rebote_vel = true;
                velocidad_baja = 0;
            }

            if (tiempo_rebote <= 0)
            {
                if (flag_rebote_vel)
                {
                    //flag_rebote_vel = false;
                    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                    transform.position += movement * Time.deltaTime * velocidad_baja;
                    velocidad_baja += Time.deltaTime + 0.05f;

                    if (estaensuelo)
                    {
                        velocidad_baja = velocidad;
                    }

                    //transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);

                    if (velocidad_baja >= velocidad)
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
        } else
        {
            animator.SetBool("Derecha", false);
            animator.SetBool("izquierda", false);
            this.GetComponent<Animator>().enabled = false;
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
                    superJumpSoundEffect.Play();
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto_powerup), ForceMode2D.Impulse);
                    pcc.flag_pu_salto = false;
                  //  animator.SetBool("Saltando", true);

                } else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
                    jumpSoundEffect.Play();
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
                    jumpSoundEffect.Play();
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.0f, salto_rebote), ForceMode2D.Impulse);
                    flag_rebote_dere = 1;
                    tiempo_rebote = 0.4f;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
                    //Debug.Log("Dere");
                    /*if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && rebotari == true)
                    {
                        if (flag_rebote_izqui == 0)
                        {

                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f, salto_rebote), ForceMode2D.Impulse);
                            //  flag_rebote_izqui = 1;
                            tiempo_rebote = 0.4f;
                            //Debug.Log("Izqui");
                        }

                    }*/
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
                    jumpSoundEffect.Play();
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f, salto_rebote), ForceMode2D.Impulse);
                    flag_rebote_izqui = 1;
                    tiempo_rebote = 0.4f;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
                    //Debug.Log("Izqui");

                    /*if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && rebotar == true)
                    {
                        if (flag_rebote_dere == 0)
                        {
                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.0f, salto_rebote), ForceMode2D.Impulse);
                            //  flag_rebote_dere = 1;
                            tiempo_rebote = 0.4f;
                            //Debug.Log("Dere");

                        }

                        //rebotari= true;
                    }*/
                }

            }
        }
    }

    void JetPack()
    {
        if (pcc.jetPackFlag == true)
        {
            if ((Input.GetMouseButton(1)) && playerFuel >= 0 && estaensuelo == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, saltoJetSuelo) * velocidad * Time.deltaTime, ForceMode2D.Impulse);
                playerFuel = playerFuel - 100*Time.deltaTime;
                fBar.SetFuel(playerFuel);
                particulasJet.SetActive(true);
            }

            if ((Input.GetMouseButton(1)) && playerFuel >= 0 && estaensuelo == false)
            {

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, saltoJet) * velocidad * Time.deltaTime, ForceMode2D.Impulse);
                playerFuel = playerFuel - 100*Time.deltaTime;
                fBar.SetFuel(playerFuel);
                particulasJet.SetActive(true);
            }

            else
             {
                if (playerFuel <= playerMaxFuel && estaensuelo == true)
                {
                    playerFuel = playerFuel + 200 * Time.deltaTime;
                    fBar.SetFuel(playerFuel);
                }
                particulasJet.SetActive(false);
            }
        }
    }

    void ModoInmortal()
    {
            if (Input.GetKey(KeyCode.I) && inmortal == false)
            {
                inmortal = true;
                ph.playerHealth = ph.playerMaxHealth;
                healthBar.SetHealth(ph.playerHealth);
             }
            if (Input.GetKey(KeyCode.I) && inmortal == true)
            {
                inmortal = false;
            }
    }
}