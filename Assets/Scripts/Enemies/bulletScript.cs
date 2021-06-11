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
        Vector2 moveDir = new Vector2(target.transform.position.x - transform.position.x + Random.Range(-1f,1f), target.transform.position.y - transform.position.y).normalized * speed;
        bullet2.velocity = new Vector2(moveDir.x*0.3f, moveDir.y*0.3f);
        Destroy(this.gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // patata = false;
        if (collision.gameObject.tag.Equals("suelo"))
        {
            Destroy(this.gameObject);
            //Debug.Log("suelo");

        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
            //Debug.Log("suelo");

        }

    }

}