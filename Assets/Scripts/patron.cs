using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron : MonoBehaviour
{

    public float velocidad;
    public float area;
    //public float area2;
    public float areadisparo;
    public float velocidadisparo;
    public float fireRate = 1f;
    private float tiempofire;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private float posicioninicial, posicioninicialB;
    // private bool flagb = false;
    private Transform A;
    private Transform B;
    private float C;
    private bool flagAB = false;
    private bool flagBA = false;
    private Transform enemy;
    private float cosa;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemigoA").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        A = GameObject.FindGameObjectWithTag("A").transform;
        B = GameObject.FindGameObjectWithTag("B").transform;
        posicioninicial = A.position.x;
        posicioninicialB = B.position.x;
    }


    void Update()
    {

        float distancia = Vector2.Distance(player.position, transform.position);
        float distancia2 = Vector2.Distance(A.position, transform.position);
        float distancia3 = Vector2.Distance(B.position, transform.position);

        if (distancia < area && distancia > areadisparo)
        {
            flagAB = false;
            flagBA = false;
            //transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(B.position.x, B.position.y + 2.5f), velocidad * Time.deltaTime);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velocidad * Time.deltaTime);

        }
        else if (distancia <= areadisparo)
        {


            if (flagAB == false)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(B.position.x, player.position.y + 2.5f), velocidad * Time.deltaTime);
            }

            if (transform.position.x == B.position.x || flagAB) //AQUUUIIIIIIIIIIIIIIIIII
            {
                flagAB = true;
                //transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(A.position.x, player.position.y + 2.5f), velocidad * Time.deltaTime);
                if (transform.position.x == Mathf.Lerp(A.position.x, B.position.x, 0.5f) || flagBA)
                {
                    flagBA = true;
                    C = player.position.y + 2.5f;
                    this.transform.position = new Vector2(Mathf.Lerp(A.position.x, B.position.x, Mathf.PingPong(Time.time, 1)), C);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Mathf.Lerp(A.position.x, B.position.x, 0.5f), player.position.y + 2.5f), velocidad * Time.deltaTime);
                }

                //transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);
                //  this.transform.position = new Vector2(Mathf.Lerp(B.position.x, A.position.x, Mathf.PingPong(Time.time, 1)), C);

            }
            /*
            else if(flagAB)
            {
                C = player.position.y + 2.5f;
              
                this.transform.position = new Vector2(Mathf.Lerp(A.position.x, B.position.x, Mathf.PingPong(Time.time, 1)), C);
            }*/

            // transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);

            if (tiempofire < Time.time)
            {
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                tiempofire = Time.time + fireRate;

            }
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, area2);
        Gizmos.DrawWireSphere(transform.position, area);
        Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
