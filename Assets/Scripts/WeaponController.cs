using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    public string arma_actual;
    public Image imagen_pistola;
    public Image imagen_escopeta;
    // Start is called before the first frame update
    void Start()
    {
        arma_actual = "Pistola";
        imagen_pistola.gameObject.SetActive(false);
        imagen_escopeta.gameObject.SetActive(false);
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
    }
}
