using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float monedas;
    private bool aux;
    
    public Text contador;

    private void Start()
    {
        monedas = 0;
        aux = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Ey");
        if (other.gameObject.tag == "Moneda")
        {
            Destroy(other.gameObject);
            //if (aux == false)
            //{
            monedas++;
                //aux = true;
            //}
            //Debug.Log("Ey");
            contador.text = monedas.ToString();
            
        }  
    }
}
