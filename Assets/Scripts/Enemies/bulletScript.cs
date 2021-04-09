using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bullet2;
    //private bool flagSuelo = false;

    void Start()
    {
        bullet2 = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bullet2.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // patata = false;
        if (collision.gameObject.tag.Equals("suelo"))
        {
            Destroy(this.gameObject);
            //Debug.Log("suelo");

        }

    }

}