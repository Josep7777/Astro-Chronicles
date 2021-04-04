using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    public string arma_actual;
    public Image imagen_pistola;
    public Image imagen_escopeta;
    public float tiempo_cambio_arma;
    CoinController coincontroller;
    // Start is called before the first frame update
    void Start()
    {
        tiempo_cambio_arma = 1f;
        arma_actual = "Pistola";
        imagen_pistola.gameObject.SetActive(false);
        imagen_escopeta.gameObject.SetActive(false);
        coincontroller = this.GetComponent<CoinController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (arma_actual)
        {
            case "Pistola":
                imagen_escopeta.gameObject.SetActive(false);
                imagen_pistola.gameObject.SetActive(true);
                break;

            case "Escopeta":
                imagen_escopeta.gameObject.SetActive(true);
                imagen_pistola.gameObject.SetActive(false);
                break;
        }

        tiempo_cambio_arma -= Time.deltaTime;

        if (Input.GetKey("1") && tiempo_cambio_arma <= 0)
        {
            tiempo_cambio_arma = 1f;
            arma_actual = "Pistola";
            imagen_escopeta.gameObject.SetActive(true);
            imagen_pistola.gameObject.SetActive(false);
        }   
            if (Input.GetKey("2") && tiempo_cambio_arma<=0 && coincontroller.flag_escopeta)
            {
            tiempo_cambio_arma = 1f;
            arma_actual = "Escopeta";
            imagen_escopeta.gameObject.SetActive(true);
            imagen_pistola.gameObject.SetActive(false);
            }
        }
    }
