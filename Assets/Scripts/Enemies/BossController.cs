using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int ataque;
    public float cd_ataques = 0;
    public bool ataque_acabado = true;
    private GameObject jugador;
    public GameObject cadena;
    private ChainController cc;
    private float contador=0;
    private bool ataque2=false;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        cc = cadena.gameObject.GetComponent<ChainController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd_ataques <= 0)
        {
            if(ataque2==false) ataque = Random.Range(0, 3);

            switch (ataque)
            {
                case 0:
                    cd_ataques = Random.Range(1,5);
                    ataque_acabado = false;
                    cc.num_ataque1 = 3;
                    Debug.Log("A");
                    break;

                case 1:
                    //cd_ataques = Random.Range(2, 5);
                    //contador = 0.5f;
                    ataque2 = true;
                    ataque_acabado = false;
                    Embestida();
                    Debug.Log("B");
                    break;

                case 2:
                    //Embestida();
                    cd_ataques = Random.Range(1, 5);
                    Debug.Log("C");
                    break;
            }
        } else
        {
            if(ataque_acabado) cd_ataques -= Time.deltaTime;
        }

        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jugador.transform.position.x*2, 0), ForceMode2D.Impulse);
    }

    public void Embestida()
    {
        Debug.Log("EA");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jugador.transform.position.x*2, 0), ForceMode2D.Impulse);

        contador += Time.deltaTime;

        if (contador >= 0.3f)
        {
            ataque2 = false;
            contador = 0;
            cd_ataques = Random.Range(1, 5);
            ataque_acabado = true;
        }
    }
}
