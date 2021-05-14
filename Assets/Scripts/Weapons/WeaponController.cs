using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour
{

    public string arma_actual;
    public Image imagen_pistola;
    public Image imagen_escopeta;
    public Image imagen_ametralladora;
    public float tiempo_cambio_arma;
    //CoinController coincontroller;
    public RectTransform panel;
    private float medida_original;
    private int medida_max = 100;
    private bool escopeta=false;
    private bool ametralladora = false;
    public GameObject cannon;
    public Sprite s_pistola;
    public Sprite s_escopeta;
    public Sprite s_metralleta;
    //private PlayerCollisionsController player_collisions;
    // Start is called before the first frame update
    void Start()
    {
        //player_collisions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionsController>();
        medida_original = panel.offsetMin.x;
        panel.gameObject.SetActive(true);
        //vector.Normalize();
        tiempo_cambio_arma = 1f;
        arma_actual = "Pistola";
        imagen_pistola.gameObject.SetActive(false);
        imagen_escopeta.gameObject.SetActive(false);
        imagen_ametralladora.gameObject.SetActive(false);
        //coincontroller = this.GetComponent<CoinController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "NIvel1")
        {
            escopeta = true;
        }

        switch (arma_actual)
        {
            case "Pistola":
                cannon.GetComponent<SpriteRenderer>().sprite = s_pistola;
                imagen_escopeta.gameObject.SetActive(false);
                imagen_pistola.gameObject.SetActive(true);
                imagen_ametralladora.gameObject.SetActive(false);
                break;

            case "Escopeta":
                escopeta = true;
                cannon.GetComponent<SpriteRenderer>().sprite = s_escopeta;
                imagen_escopeta.gameObject.SetActive(true);
                imagen_pistola.gameObject.SetActive(false);
                imagen_ametralladora.gameObject.SetActive(false);
                break;

            case "Ametralladora":
                cannon.GetComponent<SpriteRenderer>().sprite = s_metralleta;
                ametralladora = true;
                imagen_ametralladora.gameObject.SetActive(true);
                imagen_pistola.gameObject.SetActive(false);
                imagen_escopeta.gameObject.SetActive(false);
                break;

        }

        tiempo_cambio_arma -= Time.deltaTime;
        
        if (tiempo_cambio_arma>=0)
        {
            //Debug.Log(medida_original);
            //lol.gameObject.SetActive(true);
            panel.offsetMax = new Vector2(-(tiempo_cambio_arma*medida_max), panel.offsetMax.y);
            //lol.offsetMax = new Vector2(vector.x - tiempo_cambio_arma, vector.y);
        }
        

        if (Input.GetKey("1") && tiempo_cambio_arma <= 0 && arma_actual!="Pistola")
        {
            tiempo_cambio_arma = 1f;
            arma_actual = "Pistola";
            //imagen_escopeta.gameObject.SetActive(true);
            //imagen_pistola.gameObject.SetActive(false);
            panel.offsetMax = new Vector2(medida_original, panel.offsetMax.y);

        }

        if (Input.GetKey("2") && tiempo_cambio_arma<=0 && escopeta && arma_actual != "Escopeta")
        {
            tiempo_cambio_arma = 1f;
            arma_actual = "Escopeta";
            //imagen_escopeta.gameObject.SetActive(true);
            //imagen_pistola.gameObject.SetActive(false);
            panel.offsetMax = new Vector2(medida_original, panel.offsetMax.y);
        }

        if (Input.GetKey("3") && tiempo_cambio_arma <= 0 && ametralladora && arma_actual != "Ametralladora")
        {
            tiempo_cambio_arma = 1f;
            arma_actual = "Ametralladora";
            //imagen_escopeta.gameObject.SetActive(true);
            //imagen_pistola.gameObject.SetActive(false);
            panel.offsetMax = new Vector2(medida_original, panel.offsetMax.y);
        }
    }
}
