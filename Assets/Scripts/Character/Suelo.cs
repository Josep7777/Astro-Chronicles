using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{

    GameObject Player;
    public PlayerHealth ph;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }


    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "suelo")
        {
            Player.GetComponent<CharacterController>().estaensuelo = true;
        }
        if (collision.collider.tag == "trampa")
        {
            //Debug.Log("Daño");
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            ph.playerHealth = ph.playerHealth - 1;
            ph.damageSoundEffect.Play();
            ph.healthBar.SetHealth(ph.playerHealth);
            ph.tiempo_inmortal = 1f;
        }
        if (collision.collider.tag == "Boss")
        {
            //Debug.Log("Daño");
            Player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
            //ph.playerHealth = ph.playerHealth - 1;
            //ph.healthBar.SetHealth(ph.playerHealth);
            //ph.tiempo_inmortal = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "suelo")
        {

            Player.GetComponent<CharacterController>().estaensuelo = false;
        }

        if (collision.collider.tag == "trampa")
        {
            //Debug.Log("Daño");
            //Player.GetComponent<CharacterController>().estaensuelo = false;
        }
    }




}
