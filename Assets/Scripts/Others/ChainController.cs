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
        //Ataque2();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "suelo")
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

            //final_lvl1 = true;
            //SceneManager.LoadScene("FinalLvl1");
        }
    }

    void Ataque1()
    {
        if (contador <= 0.5 && flag_rot_izqui)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 5), ForceMode2D.Impulse);
            contador += Time.deltaTime;
            

            //Debug.Log("Dere");
            //contador -= Time.deltaTime;
        }
        else if (contador <= 0.5 && flag_rot_izqui == false)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 5), ForceMode2D.Impulse);
            contador += Time.deltaTime;
            
        }
    }
}
