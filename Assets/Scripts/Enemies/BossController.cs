using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int ataque;
    public float cd_ataques = 0;
    public bool ataque_acabado1 = true;
    public bool ataque_acabado2 = true;
    public bool ataque_acabado3 = true;
    private GameObject jugador;
    public GameObject cadena;
    public GameObject cadena_entera;
    public GameObject[] cadenas_techo = new GameObject[5];
    public bool[] cadenas_tiradas = new bool[5];
    private ChainController cc;
    private float contador=0;
    private bool ataque2=false;
    public int probabilidad_cadenas = 0;
    private Animator anim;
    public bool entrada = false;
    public GameObject zona_jefe;
    public AudioSource caidaCadena;
    public AudioSource ataqueRango;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        cc = cadena.gameObject.GetComponent<ChainController>();
        anim = gameObject.GetComponent<Animator>();
        for (int i=0;i<cadenas_tiradas.Length;i++)
        {
            cadenas_tiradas[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (entrada)
        {
            zona_jefe.SetActive(true);
            anim.SetFloat("Direccion", this.transform.position.x - jugador.transform.position.x);

            probabilidad_cadenas = Random.Range(0, 15000);

            if (probabilidad_cadenas == 10 && cadenas_tiradas[0] == false)
            {
                //Debug.Log("Wa");
                cadenas_techo[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cadenas_tiradas[0] = true;
                caidaCadena.Play();
            }
            else if (probabilidad_cadenas == 500 && cadenas_tiradas[1] == false)
            {
                //Debug.Log("Wa");
                cadenas_techo[1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cadenas_tiradas[1] = true;
                caidaCadena.Play();
            }
            else if (probabilidad_cadenas == 230 && cadenas_tiradas[2] == false)
            {
                //Debug.Log("Wa");
                cadenas_techo[2].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cadenas_tiradas[2] = true;
                caidaCadena.Play();
            }
            else if (probabilidad_cadenas == 23 && cadenas_tiradas[3] == false)
            {
                //Debug.Log("Wa");
                cadenas_techo[3].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cadenas_tiradas[3] = true;
                caidaCadena.Play();
            }
            else if (probabilidad_cadenas == 687 && cadenas_tiradas[4] == false)
            {
                //Debug.Log("Wa");
                cadenas_techo[4].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                cadenas_tiradas[4] = true;
                caidaCadena.Play();
            }

            if (cd_ataques <= 0)
            {
                if (ataque2 == false) ataque = 0; //ataque = Random.Range(0, 4); //ataque = 3; //ataque = Random.Range(0, 4); //ataque = 0; //ataque = Random.Range(0, 4); //ataque = 1; //ataque = Random.Range(0, 3); //ataque = 2; //

                switch (ataque)
                {
                    case 0:
                        cd_ataques = Random.Range(0.5f, 2);
                        ataque_acabado1 = false;
                        cc.num_ataque1 = 3;
                        //Debug.Log("A");
                        
                        break;

                    case 1:
                        //Debug.Log("B");
                        //cd_ataques = Random.Range(1, 5);
                        ataque2 = true;
                        ataque_acabado2 = false;
                        Embestida();
                        break;

                    case 2:
                        //Debug.Log("B");
                        //cd_ataques = Random.Range(1, 5);
                        ataque2 = true;
                        ataque_acabado2 = false;
                        Embestida();
                        break;

                    case 3:
                        //Embestida();
                        ataque_acabado3 = false;
                        cc.ataque3 = true;
                        cd_ataques = Random.Range(0.5f, 2);
                        ataqueRango.Play();
                        //Debug.Log("C");
                        break;
                }
            }
            else
            {
                if (ataque_acabado1 && ataque_acabado2 && ataque_acabado3) cd_ataques -= Time.deltaTime;
            }
        }

        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jugador.transform.position.x*2, 0), ForceMode2D.Impulse);
    }

    public void Embestida()
    {
        //Debug.Log("EA");
        anim.SetBool("Embestir", true);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jugador.transform.position.x*2f, 0), ForceMode2D.Impulse);
        this.transform.position = Vector2.MoveTowards(transform.position, new Vector2(jugador.transform.position.x,this.transform.position.y), 5*Time.deltaTime);
        //cadena_entera.transform.position = Vector2.MoveTowards(transform.position, jugador.transform.position, 5 * Time.deltaTime);

        contador += Time.deltaTime;

        if (contador >= 1f)
        {
            //Debug.Log("Wa");
            anim.SetBool("Embestir", false);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            ataque2 = false;
            contador = 0;
            cd_ataques = Random.Range(0.5f, 2);
            ataque_acabado2 = true;
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
