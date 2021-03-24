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

    private Transform A;
    private Transform B;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        A = GameObject.FindGameObjectWithTag("A").transform;

    }

  
    void Update()
    {

        float distancia = Vector2.Distance(player.position, transform.position);

        if(distancia< area && distancia>areadisparo)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, velocidad * Time.deltaTime);
        }
        else if(distancia <= areadisparo && tiempofire < Time.time){

            transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);

            //transform.position = Vector2.MoveTowards(this.transform.position, A.position, velocidad * Time.deltaTime);

            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            tiempofire = Time.time + fireRate;

          
        }

       
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, area);
        Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
