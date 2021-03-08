using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pared : MonoBehaviour
{

    GameObject Player2;
  
  

    void Start()
    {
        Player2 = gameObject.transform.parent.gameObject;
      
    }


    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "pared")
        {
            Player2.GetComponent<CharacterController>().rebotar = true;

        }
        if (collision.collider.tag == "izquierda")
        {
            Player2.GetComponent<CharacterController>().rebotari = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "pared")
        {

            Player2.GetComponent<CharacterController>().rebotar = false;
        }
        if (collision.collider.tag == "izquierda")
        {

            Player2.GetComponent<CharacterController>().rebotari = false;
        }
    }





}
