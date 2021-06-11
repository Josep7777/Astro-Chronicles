using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public float velocidad;
    private bool movingRight = true;
    private float speed2;
    public Transform groundDetection;
    private Transform player;
    public float area;
    //private Transform player;
    public float areadisparo;
    private bool flagAB = false;
    private bool flagBA = false;
    private Transform A;
    private Transform B;
    private float C;
    private float tiempofire;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private bool disparar = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed2 = speed * 3 / 2;
    }

    private void Update()
    {
        float distancia = Vector2.Distance(player.position, transform.position);

        if (distancia < areadisparo || disparar) //disparar
        {

                   

                if (tiempofire < Time.time)
                {
                    Instantiate(bullet, bulletParent.transform.position, Quaternion.Euler(0, 0, 90));
                    tiempofire = Time.time + fireRate;
                }
           


        }
         if (distancia < area) //embestir
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.position.x, this.transform.position.y), speed2 * Time.deltaTime);
            if (this.transform.position.x - player.position.x < 0)
            {
                movingRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }

        if (collision.gameObject.tag.Equals("bala"))
        {
            disparar = true;
            //Debug.Log(EnemyHealth);
        }

        if (collision.gameObject.tag == "izquierda")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, area2);
        Gizmos.DrawWireSphere(transform.position, area);
        //Gizmos.DrawWireSphere(transform.position, areadisparo);
        Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, area2);
        Gizmos.DrawWireSphere(transform.position, areadisparo);
        //Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
