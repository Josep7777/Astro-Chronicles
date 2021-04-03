using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron : MonoBehaviour
{

    public float velocidad;
    public float area;
    public float area2;
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
    private Transform enemy;
  

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
       
        if (distancia< area && distancia>areadisparo)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);
            // if(this.transform.position == A.position)
            // {
            //     flagAB = true;
            //    Debug.Log(flagAB);
            ///    Debug.Log("ALGO");
            //}
          
        }
        else if(distancia <= areadisparo ){
        

            transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);

         


            if (transform.position.x == B.position.x && transform.position.y == B.position.y) //AQUUUIIIIIIIIIIIIIIIIII
            {
                flagAB = true;
                transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);
                //  this.transform.position = new Vector2(Mathf.Lerp(B.position.x, A.position.x, Mathf.PingPong(Time.time, 1)), C);

            }
            else if(flagAB)
            {
                C = player.position.y + 2.5f;
              
                this.transform.position = new Vector2(Mathf.Lerp(A.position.x, B.position.x, Mathf.PingPong(Time.time, 1)), C);
            }
           

           // transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);

            if (distancia2 < area2)
            {
                //Debug.Log("aaaaaa1");
              //  if (flagAB == false)
               // {
                    //Debug.Log("Hola");
                // transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);
                // this.transform.position = new Vector2(posicioninicialB, this.transform.position.x);
                //  Debug.Log("a: " + this.transform.position.x);
                // Debug.Log(B.position.x);
               
              //  }


               // if (distancia3 < area2)
              // {
              //      Debug.Log("adios");
                    
                    //this.transform.position = new Vector2(posicioninicial, this.transform.position.y);
              //      transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);
              //      if (this.transform.position == A.position) flagAB = false;
              //      else flagAB = true;
              //  }
            }



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
        Gizmos.DrawWireSphere(transform.position, area2);
        Gizmos.DrawWireSphere(transform.position, area);
        Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
