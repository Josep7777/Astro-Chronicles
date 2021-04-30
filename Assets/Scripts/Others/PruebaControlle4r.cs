using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaControlle4r : MonoBehaviour
{
    private float contador = 1;
    private float contador_ataque1 = 0;
    private bool flag_rot_dere = false;
    private bool flag_rot_izqui = false;
    private bool aux = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ataque1();
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
            } else
            {
                //flag_rot_dere = false;
                flag_rot_izqui = false;
                contador = 0;
            }

            //final_lvl1 = true;
            Debug.Log("Hola");
            //SceneManager.LoadScene("FinalLvl1");
        }
    }

    void Ataque1()
    {
        if (contador <= 0.5 && flag_rot_izqui)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 5), ForceMode2D.Impulse);
            contador += Time.deltaTime;
            //contador -= Time.deltaTime;
        }
        else if (contador <= 0.5 && flag_rot_izqui == false)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 5), ForceMode2D.Impulse);
            contador += Time.deltaTime;
        }
    }
}
