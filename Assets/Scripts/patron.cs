using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patron : MonoBehaviour
{

    public float velocidad;
    public float area;
    public float areadisparo;
    public float velocidadisparo;
    public float fireRate = 1f;
    private float tiempofire;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
   // private bool flagb = false;
    private Transform A;
    private Transform B;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        A = GameObject.FindGameObjectWithTag("A").transform;
        B = GameObject.FindGameObjectWithTag("B").transform;
    }


    void Update()
    {

        float distancia = Vector2.Distance(player.position, transform.position);

        if(distancia< area && distancia>areadisparo)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, velocidad * Time.deltaTime);
        }
        else if(distancia <= areadisparo){




           transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);

            //if(this.transform.position == A.position)
            // {
            //flagb = true;

            //     transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);


            // }
          

           // if (flagb)
           // {
           //     transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);
       
           // }

           // if (this.transform.position == B.position)
           // {
            //    flagb = false;
//

           // }



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
        Gizmos.DrawWireSphere(transform.position, area);
        Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
