using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - jugador.transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        } else transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
