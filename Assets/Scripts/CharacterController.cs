using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;

    public bool estaensuelo = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  if(Input.GetKey(KeyCode.LeftArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
          }
          if (Input.GetKey(KeyCode.RightArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0);
          }
          if (Input.GetKey(KeyCode.UpArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
          }
          if (Input.GetKey(KeyCode.DownArrow))
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
          }
        */
        Saltar();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * velocidad;
    }

    void Saltar()
    {
        if (Input.GetKey(KeyCode.UpArrow) &&  estaensuelo == true) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1.5f), ForceMode2D.Impulse);
        }

    }
}
