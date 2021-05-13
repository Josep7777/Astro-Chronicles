using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
 public float speed;
    public float distance;

    private bool movingRight = true;
    private float speed2;
    public Transform groundDetection;
    private Transform player;
    public float area;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed2 = speed * 3 / 2 ;
    }

    private void Update()
    {
        float distancia = Vector2.Distance(player.position, transform.position);



        if (distancia < area)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.position.x, this.transform.position.y), speed2 * Time.deltaTime);
            //Debug.Log(this.transform.position.x-player.position.x);
            if(this.transform.position.x - player.position.x < 0)
            {
                movingRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            //transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(player.position.x, player.position.y), speed2 * Time.deltaTime);
        }
        else {        
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }else
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
    }
}
