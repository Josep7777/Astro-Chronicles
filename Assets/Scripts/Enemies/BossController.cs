using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private int ataque;
    public float cd_ataques = 0;
    public bool ataque1 = false;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (cd_ataques <= 0)
        {
            ataque = Random.Range(0, 3);

            switch (ataque)
            {
                case 0:
                    ataque1 = true;
                    cd_ataques = 2f;
                    Debug.Log("A");
                    break;

                case 1:
                    Embestida();
                    cd_ataques = 2f;
                    Debug.Log("B");
                    break;

                case 2:
                    //Embestida();
                    cd_ataques = 2f;
                    Debug.Log("C");
                    break;
            }
        } else
        {
            cd_ataques -= Time.deltaTime;
        }
        //Embestida();
    }

    public void Embestida()
    {
        
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jugador.transform.position.x, 0), ForceMode2D.Impulse);

    }
}
