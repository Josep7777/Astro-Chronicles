using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
 public float speed;
    public float area;
    public float distance;
    private Transform player;
    private bool movingRight = true;

    public Transform groundDetection;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        float distancia = Vector2.Distance(player.position, transform.position);
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

        if (distancia < area)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
       
        Gizmos.DrawWireSphere(transform.position, area);
       
    }
}
