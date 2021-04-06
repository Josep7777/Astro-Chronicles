using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour {

    GameObject Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }


    void Update()
    {

    }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "suelo")
            {
                Player.GetComponent<CharacterController>().estaensuelo = true;
            }
            if (collision.collider.tag == "trampa")
            {
                Debug.Log("Daño");
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
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
