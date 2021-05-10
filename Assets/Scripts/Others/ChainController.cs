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
    public bool ataque3 = false;
    private float contador2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        num_ataque1 = 0;
        bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
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
            bc.ataque_acabado = true;
            no_repetir = false;
        }

        if (ataque3)
        {
            Ataque3();
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
            this.transform.localScale = new Vector2(5f + contador2, 5f + contador2);
        } else if(contador2<=2.3f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5f, 5), ForceMode2D.Impulse);
        }
    }
}
