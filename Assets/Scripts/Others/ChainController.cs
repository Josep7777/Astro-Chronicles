using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    private float contador = 1;
    private float contador_ataque1 = 0;
    private bool flag_rot_dere = false;
    private bool flag_rot_izqui = false;
    private bool aux = false;
    public int num_ataque1 = 0;
    private BossController bc;
    private bool no_repetir = false;
    private bool no_repetir2 = false;
    public bool ataque3 = false;
    private float contador2 = 0;
    private float contador3 = 0;
    public GameObject onda;
    private GameObject jugador;
    private bool dere=false;
    public GameObject particulas;
    private bool particula_una = false;
    // Start is called before the first frame update
    void Start()
    {
        num_ataque1 = 0;
        bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (num_ataque1 >= 0)
        {
            Ataque1();
            no_repetir = true;
        }
        else if(no_repetir)
        {
            bc.ataque_acabado1 = true;
            no_repetir = false;
        }

        if (ataque3)
        {
            Ataque3();
            no_repetir2 = true;
        }
        else if (no_repetir2)
        {
            contador3 = 0;
            contador2 = 0;
            particula_una = false;
            bc.ataque_acabado3 = true;
            no_repetir2 = false;
        }
        //Ataque2();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "suelo" || other.gameObject.tag == "izquierda" || other.gameObject.tag == "pared")
        {
            if (!flag_rot_izqui)
            {
                //flag_rot_dere = false;
                flag_rot_izqui = true;
                contador = 0;
                num_ataque1 -= 1;
            } else
            {
                //flag_rot_dere = false;
                flag_rot_izqui = false;
                contador = 0;
            }

        }
    }

    void Ataque1()
    {
        if (contador <= 0.3f && flag_rot_izqui)
        {
            //Debug.Log("a");
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 5), ForceMode2D.Impulse);
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 2, ForceMode2D.Impulse);
            contador += Time.deltaTime;
            
        }
        else if (contador <= 0.3f && flag_rot_izqui == false)
        {
            //Debug.Log("b");
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 5), ForceMode2D.Impulse);
            contador += Time.deltaTime;
            
        }
    }

    void Ataque3()
    {
        contador2 += Time.deltaTime;
        
        if (contador2 <= 2.0f)
        {
            if (particula_una == false) //Iniciar las particulas
            {
                Instantiate(particulas, this.transform.position, Quaternion.identity);
                particula_una = true;
            }
            
            this.transform.localScale = new Vector2(5f + contador2, 5f + contador2); //Escalar
        }
        else if (contador2 <= 2.3f)
        {
            if (this.transform.position.x - jugador.transform.position.x > 0) //Hacer golpe a la izquierda
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4f, 5), ForceMode2D.Impulse);
                onda.transform.position = new Vector2(this.transform.position.x - 1, -2f);
                dere = false;
            }
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 5), ForceMode2D.Impulse);
            else //Hacer golpe a la derecha
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.2f, 0.5f), ForceMode2D.Impulse);
                //Debug.Log("aaaaaaaaaaaaa");
                onda.transform.position = new Vector2(this.transform.position.x + 1, -2f);
                dere = true;
            }

        }
        else if (contador2 <= 4f) //Hacer la onda
        {
            onda.SetActive(true);
            //onda.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);
            if (dere == false)
                onda.transform.position = Vector2.MoveTowards(onda.transform.position, new Vector2(-50f, -2f), 10 * Time.deltaTime);
            else
                onda.transform.position = Vector2.MoveTowards(onda.transform.position, new Vector2(50f, -2f), 10 * Time.deltaTime);
            //Debug.Log("HOlaaa");
        }
        else //Eliminar la onda y volver a escalar arma
        {
            onda.SetActive(false);
            contador3 += Time.deltaTime;
            if (contador3 <= 2.0f)
            {
                //Debug.Log("wasdasd");
                this.transform.localScale = new Vector2(7f - contador3, 7f - contador3);
            }
            else ataque3 = false; //Cuando acabe de escalar, acaba el ataque
        }
    }
}
