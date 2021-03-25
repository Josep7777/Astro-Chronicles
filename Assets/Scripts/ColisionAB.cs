using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAB : MonoBehaviour
{

    public float velocidad;
    public float area;
    private Transform enemy;

    private Transform A;
    private Transform B;
    private float posicioninicial;
    private bool flagAB = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemigoA").transform;
        A = GameObject.FindGameObjectWithTag("A").transform;
        B = GameObject.FindGameObjectWithTag("B").transform;
        posicioninicial = A.position.x;
    }


 

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector2.Distance(enemy.position, transform.position);
        if (distancia < area) {
            //Debug.Log("aaaaaa1");
            if (flagAB==false) {
                transform.position = Vector2.MoveTowards(this.transform.position, B.position, velocidad * Time.deltaTime);
              //  Debug.Log("a: " + this.transform.position.x);
               // Debug.Log(B.position.x);
            }
               
            
            if (this.transform.position.x == B.position.x)
            {
                Debug.Log("aaaaaa2");

                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2 (posicioninicial,this.transform.position.y), velocidad * Time.deltaTime);
                flagAB = true;

            }
        }
       
    }





    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, area);
      //  Gizmos.DrawWireSphere(transform.position, areadisparo);
      //  Gizmos.DrawWireSphere(transform.position, areadisparo);
    }
}
